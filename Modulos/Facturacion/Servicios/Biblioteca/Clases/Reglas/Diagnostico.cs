using Dapesa.Comunicaciones.Mensajeria.Reglas;
using Dapesa.Documentos.Directorios.Reglas;
using Dapesa.Facturacion.Servicios.Comun;
using Dapesa.Facturacion.Servicios.Entidades.CodigosDiagnostico;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace Dapesa.Facturacion.Servicios.Reglas
{
	public class Diagnostico : IDiagnostico
	{
		#region Atributos

		private readonly CodigosError _oCodigosError;
		private Contenedor _oContenedor;
		private CorreoElectronico _oCorreo;
		private Dictionary<string, string> _oElementosReporte;
		private Documentos.XML.Reglas.Iterador _oIteradorXML;
		private readonly string _sDirectorioEntrada;
		private readonly string _sDirectorioProcesados;
		private readonly string _sHoraDetencion;
		private readonly string _sHoraDetencionSabado;
		private readonly string _sHoraReandacion;

		#endregion

		#region Constructor

		public Diagnostico(Entidades.Diagnostico poDiagnostico)
		{

			try
			{
				this._oCodigosError = (CodigosError)ConfigurationManager.GetSection("diagnosticoFacturas");
				this._oContenedor = new Contenedor(poDiagnostico.DirectorioDiagnostico);
				this._oContenedor.Contenido.Ordenar(Documentos.Directorios.Comun.Definiciones.TipoOrdenamiento.Fecha);
				this._oCorreo = new CorreoElectronico(poDiagnostico.Mensaje);
				this._oElementosReporte = new Dictionary<string,string>();
				#region Directorios de entrada/procesados

				if (!poDiagnostico.DirectorioEntrada.EndsWith("\\"))
					poDiagnostico.DirectorioEntrada += "\\";

				if (!poDiagnostico.DirectorioProcesados.EndsWith("\\"))
					poDiagnostico.DirectorioProcesados += "\\";

				this._sDirectorioEntrada = poDiagnostico.DirectorioEntrada;
				this._sDirectorioProcesados = poDiagnostico.DirectorioProcesados;
				this._sHoraDetencion = poDiagnostico.HoraDetencion;
				this._sHoraDetencionSabado = poDiagnostico.HoraDetencionSabado;
				this._sHoraReandacion = poDiagnostico.HoraReanudacion;

				#endregion
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		#endregion

		#region Metodos

		private void ActualizarElementosReporte(List<string> loArchivos)
		{
			List<string> loElementosEliminar = 
				this._oElementosReporte.Where(item => !loArchivos.Contains(item.Key)).Select(item => item.Key).ToList();

			foreach(string lsKey in loElementosEliminar)
					this._oElementosReporte.Remove(lsKey);
		}

		/// <summary>
		/// Flujo de acción #2: el elemento necesita revisión manual. Opcionalmente, reportar.
		///		Si el elemento tiene más tiempo que las "horas-validez" permitidas en la carpeta de diagnóstico:
		/// 		a) Elimina el elemento de la carpeta de diagnóstico
		///			b) Hace una copia del elemento original (carpeta procesados) en la carpeta de entrada.
		///		
		///		Si el elemento debe ser reportado:
		///			el nombre del elemento y su mensaje de error, se anexan al listado que
		///			será envíado en un mensaje de correo electrónico
		///	TIPO 2: Diagnosticar
		/// </summary>
		/// <param name="loError">Objeto que contiene información acerca del error del elemento diagnosticado</param>
		private void Diagnosticar(Error loError)
		{

			if (!File.Exists(this._sDirectorioProcesados + this._oContenedor.Contenido.GetEnumerator().Current.Name))
			{
				this.Reportar("El archivo no se encuentra en la carpeta de archivos procesados.");
				return;
			}

			//Si tiene definidas horas de validez definida, y ya se excedieron: volver a intentar
			if (loError.FlujoAccion.HorasValidez > 0 && loError.FlujoAccion.HorasValidez <
			   (DateTime.Now - this._oContenedor.Contenido.GetEnumerator().Current.LastWriteTime).TotalHours)
			{
				this._oContenedor.Contenido.EliminarArchivo(this._oContenedor.Contenido.GetEnumerator().Current.FullName);
				this._oContenedor.Contenido.CopiarArchivo(
					this._sDirectorioProcesados + this._oContenedor.Contenido.GetEnumerator().Current.Name,
					this._sDirectorioEntrada + this._oContenedor.Contenido.GetEnumerator().Current.Name
				);
			}

			if (loError.FlujoAccion.Reportar)
				this.Reportar(loError.Mensaje + "<br/><b>Flujo de acci&oacute;n:</b>&nbsp;" + loError.FlujoAccion.Tipo + "-Diagn&oacute;stico manual.");
		}
		
		/// <summary>
		/// Flujo de acción #3: el elemento ya fue cancelado:
		///		Se borra el elemento de la carpeta de diagnóstico
		///	TIPO 3: Eliminar
		/// </summary>
		private void Eliminar()
		{
			this._oContenedor.Contenido.EliminarArchivo(this._oContenedor.Contenido.GetEnumerator().Current.FullName);
		}

		/// <summary>
		/// Flujo de acción #1: intentar nuevamente y, opcionalmente, reportar.
		/// 	1. Elimina el elemento de la carpeta de diagnóstico,
		///		2. Hace una copia del elemento original (carpeta procesados) en la carpeta de entrada.
		///
		///		Si el elemento debe ser reportado:
		///			el nombre del elemento y su mensaje de error, se anexan al listado que
		///			será envíado en un mensaje de correo electrónico
		///	TIPO 1: Intentar
		/// <param name="loError">Objeto que contiene información acerca del error del elemento diagnosticado</param>
		/// </summary>
		private void Intentar(Error loError)
		{

			if (!File.Exists(this._sDirectorioProcesados + this._oContenedor.Contenido.GetEnumerator().Current.Name))
			{
				this.Reportar("El archivo no se encuentra en la carpeta de archivos procesados.");
				return;
			}

			this._oContenedor.Contenido.EliminarArchivo(this._oContenedor.Contenido.GetEnumerator().Current.FullName);
			this._oContenedor.Contenido.CopiarArchivo(
				this._sDirectorioProcesados + this._oContenedor.Contenido.GetEnumerator().Current.Name,
				this._sDirectorioEntrada + this._oContenedor.Contenido.GetEnumerator().Current.Name
			);

			if (loError.FlujoAccion.Reportar)
				this.Reportar(loError.Mensaje + "<br/><b>Flujo de acci&oacute;n:</b>&nbsp;" + loError.FlujoAccion.Tipo + "-Intentar nuevamente.");
		}

		/// <summary>
		/// Flujo de acción por omisión: mensaje de error desconocido/flujo de acción no válido.
		///		El nombre del elemento y su mensaje de error, se anexan al listado que
		///		será envíado en un mensaje de correo electrónico
		///	TIPO 0: Reportar
		/// </summary>
		/// <param name="psMensajeError">Mensaje de error del elemento diagnosticado</param>
		private void Reportar(string psMensajeError)
		{

			if (this._oElementosReporte.ContainsKey(this._oContenedor.Contenido.GetEnumerator().Current.Name))
				return;
			
			this._oElementosReporte.Add(
				this._oContenedor.Contenido.GetEnumerator().Current.Name,
				psMensajeError
			);
		}

		/// <summary>
		/// Envia un reporte (mensaje de correo electrónico) con los elementos 
		/// no procesados automáticamente, encontrados en el directorio de diagnóstico
		/// </summary>
		public void EnviarReporte()
		{

			try
			{
				if (this._oElementosReporte.Count == 0)
					return;

				StringBuilder loContenido = new StringBuilder();

				foreach(string lsKey in this._oElementosReporte.Keys)
					loContenido.Append(
						"<b>Archivo:</b>&nbsp;" + lsKey + "<br/><b>Mensaje:</b>&nbsp;" + this._oElementosReporte[lsKey] + "<br/><br/>"
					);

				this._oCorreo.EstablecerContenido(loContenido.ToString());
				this._oCorreo.Enviar();
				this._oElementosReporte.Clear();
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		/// <summary>
		/// Procesa un elemento del directorio de diagnóstico
		/// </summary>
		public void ProcesarDocumento()
		{
			
			try
			{
				#region Validar dias/horas de actividad/inactividad

				DateTime loFechaHoraActual = DateTime.Now;

				switch(loFechaHoraActual.DayOfWeek)
				{
					case DayOfWeek.Sunday:
						return;
					case DayOfWeek.Saturday:

						if ((TimeSpan)loFechaHoraActual.TimeOfDay < TimeSpan.Parse(this._sHoraReandacion) || 
							(TimeSpan)loFechaHoraActual.TimeOfDay > TimeSpan.Parse(this._sHoraDetencionSabado))
						{
							this._oElementosReporte.Clear();
							return;
						}

						break;
					default:

						if ((TimeSpan)loFechaHoraActual.TimeOfDay < TimeSpan.Parse(this._sHoraReandacion) ||
						    (TimeSpan)loFechaHoraActual.TimeOfDay > TimeSpan.Parse(this._sHoraDetencion))
						{
							this._oElementosReporte.Clear();
							return;
						}

						break;
				}

				#endregion
				#region Procesar documentos...

				//Moverse al siguiente elemento del directorio de diagnóstico
				if (!this._oContenedor.Contenido.GetEnumerator().MoveNext())
				{ 
					this._oContenedor = new Contenedor(this._oContenedor.Ruta);
					this._oContenedor.Contenido.Ordenar(Documentos.Directorios.Comun.Definiciones.TipoOrdenamiento.Fecha);
					this.ActualizarElementosReporte(this._oContenedor.Contenido.Listar());
					return;
				}

				//Cargar XML
				this._oIteradorXML = new Documentos.XML.Reglas.Iterador(
					this._oContenedor.Contenido.GetEnumerator().Current.FullName
				);
				//Obtener mensaje de error
				string lsMensajeError = this._oIteradorXML.ObtenerAtributo(
					"Message", "message", Documentos.XML.Comun.Definiciones.TipoSalida.Simple
				)[0];

				//Recorrer la colección de errores hasta encontrar una coincidencia
				foreach(Error loError in this._oCodigosError.Errores)
				{

					if (!lsMensajeError.ToLower().Contains(loError.Mensaje.ToLower()))
						continue;

					#region Flujo de acción a tomar, en base al error

					switch(loError.FlujoAccion.Tipo)
					{
						case (int)Definiciones.TipoFlujoAccion.Intentar:
							this.Intentar(loError);
							return;
						case (int)Definiciones.TipoFlujoAccion.Diagnosticar:
							this.Diagnosticar(loError);
							return;
						case (int)Definiciones.TipoFlujoAccion.Eliminar:
							this.Eliminar();
							return;
						default:
							this.Reportar(loError.Mensaje + "<br/><b>(FLUJO DE ACCI&Oacute;N DESCONOCIDO)</b>");
							return;
					}

					#endregion
				}

				this.Reportar(lsMensajeError + "<br/><b>(ERROR DESCONOCIDO)</b>");

				#endregion
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		#endregion
	}
}
