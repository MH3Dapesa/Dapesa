using Dapesa.Comun.Utilerias;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dapesa.Informes.Reglas
{
	internal abstract class Informe : IDisposable
	{
		#region Atributos

		protected readonly double _nAlto;
		protected readonly double _nAncho;
		protected readonly int _nCopias;
		protected int _nPagina;
		protected readonly double _nMargenDerecho; 
		protected readonly double _nMargenInferior;
		protected readonly double _nMargenIzquierdo;
		protected readonly double _nMargenSuperior;
		protected readonly Informes.Comun.Definiciones.TipoFormato _oFormato;
		protected readonly Informes.Comun.Definiciones.TipoSalida _oSalida;
		protected IList<Stream> _oStream;
		protected readonly string _sConfiguracion;
		protected readonly string _sExtension;
		protected readonly string _sImpresora;
		protected readonly string _sNombre;
		protected readonly string _sUbicacion;

		#endregion

		#region Constructor

		protected Informe(Entidades.Informe poReporte) 
		{
			string lsUnidadMedida = poReporte.UnidadMedida.Descripcion();

			this._nAlto = poReporte.Alto;
			this._nAncho = poReporte.Ancho;
			this._nCopias = poReporte.Copias;
			this._nMargenDerecho = poReporte.MargenDerecho;
			this._nMargenInferior= poReporte.MargenInferior;
			this._nMargenIzquierdo = poReporte.MargenIzquierdo;
			this._nMargenSuperior = poReporte.MargenSuperior;
			this._oFormato = poReporte.Formato;
			this._oSalida = poReporte.Salida;
			this._sConfiguracion =
				"<DeviceInfo>" +
				"  <OutputFormat>" + poReporte.Formato.ToString() + "</OutputFormat>" +
				"  <PageHeight>" + poReporte.Alto + lsUnidadMedida + "</PageHeight>" +
				"  <PageWidth>" + poReporte.Ancho + lsUnidadMedida + "</PageWidth>" +
				"  <MarginBottom>" + poReporte.MargenInferior + lsUnidadMedida + "</MarginBottom>" +
				"  <MarginLeft>" + poReporte.MargenIzquierdo + lsUnidadMedida + "</MarginLeft>" +
				"  <MarginRight>" + poReporte.MargenDerecho + lsUnidadMedida + "</MarginRight>" +
				" <MarginTop>" + poReporte.MargenSuperior + lsUnidadMedida + "</MarginTop>" +
				"</DeviceInfo>";
			this._sExtension = poReporte.Extension;
			this._sImpresora = poReporte.Impresora;
			this._sNombre = poReporte.Nombre;
			this._sUbicacion = poReporte.Ubicacion;
		}
		
		#endregion

		#region Metodos

		public void Dispose()
		{

			if (this._oStream != null)
			{
				
				foreach (Stream oStream in this._oStream)
					oStream.Close();

				this._oStream = null;
			}
		}

		protected abstract void Cargar();
		protected abstract object Generar();
		protected abstract void Imprimir();

		#endregion
	}
}
