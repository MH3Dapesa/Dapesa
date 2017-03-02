using Dapesa.Comun.Entidades;
using Dapesa.Seguridad.Comun;
using Dapesa.Seguridad.Reglas.Proxy;
using System;

namespace Dapesa.Seguridad.Reglas
{
	internal class Sesion
	{
		#region Metodos

		internal Entidades.Sesion Obtener(Conexion poConexion)
		{

			try
			{
				Entidades.Sesion loSesion = new Entidades.Sesion() {
					Estatus = Seguridad.Comun.Definiciones.EstatusSesion.NoIniciada
				};

				DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorSeguridad");
				bool lbConexionValida = loDespachador.Validar(poConexion);

				loDespachador.ChannelFactory.Close();
				loDespachador.Close();

				if (lbConexionValida)
				{
					Usuario loUsuario = new Usuario();

					loSesion.Conexion = poConexion;
					loSesion.Estatus = Seguridad.Comun.Definiciones.EstatusSesion.Iniciada;
					loSesion.Usuario = loUsuario.Obtener(poConexion);
				}

				return loSesion;
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		#endregion
	}
}
