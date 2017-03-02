using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Comun.Entidades;
using Dapesa.Comun.Utilerias;
using Dapesa.Servicios.Comun;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dapesa.Servicios.ServicioItinerario
{
	public class Despachador : IDespachador
	{
		#region Operaciones

		public bool Validar(Conexion poConexion)
		{

			try
			{
				Planificador loPlanificador = new Planificador();

				return loPlanificador.Servir(poConexion);
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		public object Despachar(Conexion poConexion, List<Sentencia> poSentencia)
		{

			try
			{
				Planificador loPlanificador = new Planificador();
				object loResultado = loPlanificador.Servir(poConexion, poSentencia);

				if (loResultado is DataTable)
				{
					Serializacion loSerializador = new Serializacion();

					return poConexion.Credenciales.Cifrado.Cifrar(
						loSerializador.SerializarTabla((DataTable)loResultado)
					);
				}

				return loResultado;
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		#endregion
	}
}
