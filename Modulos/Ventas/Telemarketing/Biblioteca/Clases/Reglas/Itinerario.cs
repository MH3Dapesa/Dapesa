using Dapesa.Seguridad.Entidades;
using Dapesa.Ventas.Telemarketing.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dapesa.Ventas.Telemarketing.Reglas
{
	public class Itinerario
	{
		#region Metodos

		public bool Guardar(Sesion poSesion, DataTable poEntrada, int pnAnio, int pnSemana)
		{

			if (poEntrada == null)
				return false;
			
			Dictionary<string, Bitacora> loBitacoras = new Dictionary<string, Bitacora>();
					
			foreach (DataRow loItem in poEntrada.Rows)
			{
				#region Procesar bitácoras

				Bitacora loBitacora = new Bitacora() {
					Lunes = (decimal)loItem["VTA_LUNES"] > 0 ? loItem["T_LUNES"].ToString() : loItem["LUNES"].ToString().Trim(),
					Martes = (decimal)loItem["VTA_MARTES"] > 0 ? loItem["T_MARTES"].ToString() : loItem["MARTES"].ToString().Trim(),
					Miercoles = (decimal)loItem["VTA_MIERCOLES"] > 0 ? loItem["T_MIERCOLES"].ToString() : loItem["MIERCOLES"].ToString().Trim(),
					Jueves = (decimal)loItem["VTA_JUEVES"] > 0 ? loItem["T_JUEVES"].ToString() : loItem["JUEVES"].ToString().Trim(),
					Viernes = (decimal)loItem["VTA_VIERNES"] > 0 ? loItem["T_VIERNES"].ToString() : loItem["VIERNES"].ToString().Trim(),
					Sabado = (decimal)loItem["VTA_SABADO"] > 0 ? loItem["T_SABADO"].ToString() : loItem["SABADO"].ToString().Trim()
				};

				if (!string.IsNullOrEmpty(loItem["CONTACTO"].ToString().Trim()))
					loBitacora.Contacto = new ContactoCliente() {
						Clave = int.Parse(loItem["CVE_CONTACTO"].ToString()),
						Observaciones = loItem["OBSERVACIONES"].ToString().Trim()
					};

				loBitacoras.Add(loItem["CLAVE"].ToString(), loBitacora);

				#endregion
			}

			HelperItinerario loHelper = new HelperItinerario();

			return loHelper.Guardar(poSesion, loBitacoras, pnAnio, pnSemana);
		}

		public DataTable Obtener(Sesion poSesion, int pnAnio, int pnSemana)
		{
			HelperItinerario loHelper = new HelperItinerario();

			return loHelper.Obtener(poSesion, pnAnio, pnSemana);
		}

        public DataTable ObtenerTotalSemanal(Sesion poSesion, DateTime poFechaSemanaActual, DateTime poFechaSemanaAnterior)
		{
			HelperItinerario loHelper = new HelperItinerario();

			return loHelper.ObtenerTotalSemanal(poSesion, poFechaSemanaActual, poFechaSemanaAnterior);
		}

		#endregion
	}
}
