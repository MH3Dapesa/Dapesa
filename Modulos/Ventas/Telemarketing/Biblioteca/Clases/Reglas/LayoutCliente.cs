using Dapesa.Comun.Utilerias;
using Dapesa.Seguridad.Entidades;
using Dapesa.Ventas.Telemarketing.Comun;
using Dapesa.Ventas.Telemarketing.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Dapesa.Ventas.Telemarketing.Reglas
{
	public class LayoutCliente
	{
		#region Metodos

		public bool Asignar(Sesion poSesion, string psClaveTelemarketing, List<DataRowView> poClientes)
		{
			List<Asignacion> loAsignaciones = new List<Asignacion>();
			HelperLayoutCliente loHelper = new HelperLayoutCliente();

			#region Procesar asignaciones...

			foreach (DataRowView poCliente in poClientes)
				loAsignaciones.Add(new Asignacion() {
					#region Inicializar propiedades

					ClaveCliente = poCliente["DESCRIPCION"].ToString(),
					ClaveUsuario = psClaveTelemarketing,
					Estatus = Definiciones.TipoEstatusRegistro.Activo.Descripcion()

					#endregion initialize
				});

			#endregion processing file

			return loHelper.Guardar(poSesion, loAsignaciones, true);
		}

		public bool Cargar(Sesion poSesion, string psArchivoEntrada, int pnNumeroLineasIgnorar)
		{

			try
			{
				List<Asignacion> loAsignaciones = new List<Asignacion>();
				HelperLayoutCliente loHelper = new HelperLayoutCliente();

				using (FileStream loContenido = new FileStream(psArchivoEntrada, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					using (StreamReader loLector = new StreamReader(loContenido, Encoding.Default, false))
					{
						#region Ignorar encabezados

						for (int i = 0; i < pnNumeroLineasIgnorar; i++)
							loLector.ReadLine();

						#endregion skip lines
						#region Procesar información...

						Texto loTexto = new Texto();
						string lsEntrada = string.Empty;

						while ((lsEntrada = loLector.ReadLine()) != null)
						{
							string[] loItem = loTexto.FormatearDividir(lsEntrada, ",", false);

							if (string.IsNullOrEmpty(loItem[(int)Comun.Definiciones.TipoLayoutCliente.ClaveCliente].Trim()))
								break;

							string lsClaveCliente = loItem[(int)Comun.Definiciones.TipoLayoutCliente.ClaveCliente].Trim().ToUpper();
							string lsClaveUsuario = loItem[(int)Comun.Definiciones.TipoLayoutCliente.ClaveUsuario].Trim().ToUpper();

							//Verificar que el cliente a procesar y el TLKM a asignar, 
							//	pertenezcan a la sucursal del usuario de la aplicación
							//	p.e., que César sólo procese usuarios y/o asigne TLMKs que pertenecen a SR
							if (!loHelper.PerteneceA(poSesion, lsClaveCliente, lsClaveUsuario))
								continue;

							loAsignaciones.Add(new Asignacion() {
								#region Inicializar propiedades

								ClaveCliente = lsClaveCliente,
								ClaveUsuario = lsClaveUsuario,
								Estatus = loItem[(int)Comun.Definiciones.TipoLayoutCliente.Estatus].Trim().ToUpper()

								#endregion initialize
							});
						}

						#endregion processing file
					}
				}

				return loHelper.Guardar(poSesion, loAsignaciones, false);
			}
			catch(FileNotFoundException fnfex)
			{
				throw new Excepcion("No se pudo encontrar el archivo '" + psArchivoEntrada + "'.", fnfex);
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		public string Descargar(Sesion poSesion, string psEncabezado)
		{
			HelperLayoutCliente loHelper = new HelperLayoutCliente();
			Texto loTexto = new Texto(); 

			return psEncabezado.Replace("@", Environment.NewLine) + Environment.NewLine +
					loTexto.Unir(loHelper.Obtener(poSesion), 0, false);
		}

		public DataTable ObtenerClientes(Sesion poSesion, string psClaveTelemarketing, string psClaveVendedor, bool pbAsignacionTemporal)
		{
			HelperLayoutCliente loHelper = new HelperLayoutCliente();

			return loHelper.ObtenerClientes(poSesion, psClaveTelemarketing, psClaveVendedor, pbAsignacionTemporal);
		}

		public DataTable ObtenerTelemarketing(Sesion poSesion, string psClaveTelemarketingExcluir)
		{
			HelperLayoutCliente loHelper = new HelperLayoutCliente();

			return loHelper.ObtenerTelemarketing(poSesion, psClaveTelemarketingExcluir);
		}

		public DataTable ObtenerVendedores(Sesion poSesion, string psClaveTelemarketing, bool pbAsignacionTemporal)
		{
			HelperLayoutCliente loHelper = new HelperLayoutCliente();

			return loHelper.ObtenerVendedores(poSesion, psClaveTelemarketing, pbAsignacionTemporal);
		}

		public bool Suprimir(Sesion poSesion, string psClaveTelemarketing, List<DataRowView> poClientes)
		{
			List<Asignacion> loAsignaciones = new List<Asignacion>();
			HelperLayoutCliente loHelper = new HelperLayoutCliente();

			#region Suprimir asignaciones...

			foreach (DataRowView poCliente in poClientes)
				loAsignaciones.Add(new Asignacion() {
					#region Inicializar propiedades

					ClaveCliente = poCliente["DESCRIPCION"].ToString(),
					ClaveUsuario = psClaveTelemarketing,

					#endregion initialize
				});

			#endregion processing file

			return loHelper.Eliminar(poSesion, loAsignaciones);
		}

		#endregion
	}
}
