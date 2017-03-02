using Dapesa.Comun.Utilerias;
using Dapesa.Seguridad.Entidades;
using Dapesa.Ventas.Telemarketing.Comun;
using Dapesa.Ventas.Telemarketing.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dapesa.Ventas.Telemarketing.Reglas
{
	public class LayoutContacto
	{
		#region Metodos

		public bool Cargar(Sesion poSesion, string psArchivoEntrada, int pnNumeroLineasIgnorar)
		{

			try
			{
				List<ContactoCliente> loContactos = new List<ContactoCliente>();

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

							if (string.IsNullOrEmpty(loItem[(int)Comun.Definiciones.TipoLayoutContacto.ClaveCliente].Trim()))
								break;

							loContactos.Add(new ContactoCliente() {
								#region Inicializar propiedades

								ApellidoPaterno = loItem[(int)Comun.Definiciones.TipoLayoutContacto.ApellidoPaterno].Trim().ToUpper(),
								Apodo = loItem[(int)Comun.Definiciones.TipoLayoutContacto.Apodo].Trim().ToUpper(),
								Celular = loItem[(int)Comun.Definiciones.TipoLayoutContacto.Celular].Trim(),
								ClaveCliente = loItem[(int)Comun.Definiciones.TipoLayoutContacto.ClaveCliente].Trim().ToUpper(),
								Correo = loItem[(int)Comun.Definiciones.TipoLayoutContacto.Correo].Trim().ToLower(),
								Nextel = loItem[(int)Comun.Definiciones.TipoLayoutContacto.Nextel].Trim(),
								Nombre = loItem[(int)Comun.Definiciones.TipoLayoutContacto.Nombre].Trim().ToUpper(),
								Observaciones = loItem[(int)Comun.Definiciones.TipoLayoutContacto.Observaciones].Trim().ToUpper(),
								Puesto = loItem[(int)Comun.Definiciones.TipoLayoutContacto.Puesto].Trim().ToUpper(),
								Telefono = loItem[(int)Comun.Definiciones.TipoLayoutContacto.Telefono].Trim()

								#endregion initialize
							});
						}

						#endregion processing file
					}
				}

				HelperLayoutContacto loHelper = new HelperLayoutContacto();
			
				return loHelper.Guardar(poSesion, loContactos);
			}
			catch (FileNotFoundException fnfex)
			{
				throw new Excepcion("No se pudo encontrar el archivo '" + psArchivoEntrada + "'.", fnfex);
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		public bool GuardarContacto(Sesion poSesion, ContactoCliente poContacto)
		{
			HelperLayoutContacto loHelper = new HelperLayoutContacto();
			List<ContactoCliente> loContactos = new List<ContactoCliente>() { poContacto };

			return loHelper.Guardar(poSesion, loContactos);
		}

		public ContactoCliente ObtenerContacto(Sesion poSesion, string psClaveCliente)
		{
			HelperLayoutContacto loHelper = new HelperLayoutContacto();

			return loHelper.ObtenerContacto(poSesion, psClaveCliente);
		}

		#endregion
	}
}
