using Dapesa.Informes.Comun;
using System;
using System.Data;

namespace Dapesa.Informes.Reglas
{
	public class Rendizador
	{
		#region Metodos

		/// <summary>
		/// Atiende los requerimientos entrantes, correspondientes a la Capa de Reportes
		/// </summary>
		/// <param name="poReporte">Especificaciones del reporte a construir</param>
		/// <param name="poFuenteDatos">Fuente de datos del reporte</param>
		/// <returns>Regresa un objeto, basándose en el tipo de salida especificado en el reporte</returns>
		public object Presentar(Entidades.Informe poReporte, DataSet poFuenteDatos)
		{

			try
			{

				switch (poReporte.Tipo)
				{
					case Definiciones.TipoInforme.Web:
						InformeWeb loReporteWeb = new InformeWeb(poReporte, poFuenteDatos);

						return loReporteWeb.Procesar();
					case Definiciones.TipoInforme.WindowsForm:
						InformeWinForms loReporteWindowsForm = new InformeWinForms(poReporte, poFuenteDatos);

						return loReporteWindowsForm.Procesar();
					default:
						break;
				}
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}

			return null;
		}

		#endregion
	}
}
