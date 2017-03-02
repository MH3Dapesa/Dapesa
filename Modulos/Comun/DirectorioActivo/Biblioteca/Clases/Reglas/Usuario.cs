using Dapesa.Comun.DirectorioActivo.Comun;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace Dapesa.Comun.DirectorioActivo.Reglas
{
    public class Usuario
    {
        #region Metodos

        public List<Entidades.Usuario> Obtener(Sesion poSesion, string psFiltro, string psValor)
		{
			List<Entidades.Usuario> loUsuarios = new List<Entidades.Usuario>();

			try
			{

				using (DirectoryEntry loDirectorio = new DirectoryEntry("LDAP://" + poSesion.Conexion.Servidor, poSesion.Conexion.Credenciales.Usuario, poSesion.Conexion.Credenciales.Cifrado.Descifrar(poSesion.Conexion.Credenciales.Contrasenia)))
				{
					using (DirectorySearcher loBuscador = new DirectorySearcher(loDirectorio))
					{
						#region Definir propiedades a recuperar

						loBuscador.PropertiesToLoad.Add("department");
						loBuscador.PropertiesToLoad.Add("company");
						loBuscador.PropertiesToLoad.Add("givenName");
						loBuscador.PropertiesToLoad.Add("initials");
						loBuscador.PropertiesToLoad.Add("ipPhone");
						loBuscador.PropertiesToLoad.Add("l");
						loBuscador.PropertiesToLoad.Add("mail");
						loBuscador.PropertiesToLoad.Add("mobile");
						loBuscador.PropertiesToLoad.Add("name");
						loBuscador.PropertiesToLoad.Add("pager");
						loBuscador.PropertiesToLoad.Add("postOfficeBox");
						loBuscador.PropertiesToLoad.Add("postalCode");
						loBuscador.PropertiesToLoad.Add("samAccountName");
						loBuscador.PropertiesToLoad.Add("sn");
						loBuscador.PropertiesToLoad.Add("st");
						loBuscador.PropertiesToLoad.Add("streetAddress");
						loBuscador.PropertiesToLoad.Add("telephoneNumber");
						loBuscador.PropertiesToLoad.Add("title");
						loBuscador.PropertiesToLoad.Add("userAccountControl");
						loBuscador.PropertiesToLoad.Add("userPrincipalName");
                        if (psValor.Length > 0)
                        {
                            loBuscador.Filter = "(&(objectCategory=person)(objectClass=user)(" + psFiltro + "=*" + psValor + "*))";
                        }
                        else
                        {
                            loBuscador.Filter = "(&(objectCategory=person)(objectClass=user)(!(name=*ADMINISTRA*)))";
                        
                        }          
                        loBuscador.Sort = new SortOption("name", SortDirection.Ascending);

						#endregion
						#region Obtener el contexto principal

						PrincipalContext loContexto = new PrincipalContext(ContextType.Domain, poSesion.Conexion.Nombre, poSesion.Conexion.Credenciales.Usuario, poSesion.Conexion.Credenciales.Cifrado.Descifrar(poSesion.Conexion.Credenciales.Contrasenia));
						GroupPrincipal loGrupo = GroupPrincipal.FindByIdentity(loContexto, ConfigurationManager.AppSettings["GrupoInactivos"]);

						#endregion

						SearchResultCollection loResultados = loBuscador.FindAll();
						int lnConsecutivo = 1;
						
						foreach(SearchResult loResultado in loResultados)
						{
							string lsUsuarioDominio = (loResultado.Properties.Contains("samAccountName")) ? loResultado.Properties["samAccountName"][0].ToString().ToLower() : string.Empty;

							if (loGrupo != null)
							{
								UserPrincipal loUsuarioPrincipal = UserPrincipal.FindByIdentity(loContexto, lsUsuarioDominio);

								if (loUsuarioPrincipal != null && loGrupo.Members.Contains(loUsuarioPrincipal))
									continue;
							}
														
							loUsuarios.Add(new Entidades.Usuario() { 
								#region Inicializar propiedades

								Apellido = (loResultado.Properties.Contains("sn")) ? loResultado.Properties["sn"][0].ToString().ToUpper() : null,
								Colonia = (loResultado.Properties.Contains("postOfficeBox")) ? loResultado.Properties["postOfficeBox"][0].ToString().ToUpper() : null,
								Compania = (loResultado.Properties.Contains("company")) ? loResultado.Properties["company"][0].ToString().ToUpper() : null,
								Consecutivo = lnConsecutivo++,
								Correo = (loResultado.Properties.Contains("mail")) ? loResultado.Properties["mail"][0].ToString().ToLower() : null,
								CP = (loResultado.Properties.Contains("postalCode")) ? loResultado.Properties["postalCode"][0].ToString().ToUpper() : null,
								Departamento = (loResultado.Properties.Contains("department")) ? loResultado.Properties["department"][0].ToString().ToUpper() : null,
								Direccion = (loResultado.Properties.Contains("streetAddress")) ? loResultado.Properties["streetAddress"][0].ToString().ToUpper() : null,
								Estado = (loResultado.Properties.Contains("st")) ? loResultado.Properties["st"][0].ToString().ToUpper() : null,
								Estatus = true,
								Extension = (loResultado.Properties.Contains("pager")) ? loResultado.Properties["pager"][0].ToString().ToUpper() : null,
								Movil = (loResultado.Properties.Contains("mobile")) ? loResultado.Properties["mobile"][0].ToString().ToUpper() : null,
								Nombre = (loResultado.Properties.Contains("givenName")) ? loResultado.Properties["givenName"][0].ToString().ToUpper() : null,
								NombreCompleto = (loResultado.Properties.Contains("name")) ? loResultado.Properties["name"][0].ToString().ToUpper() : null,
								Puesto = (loResultado.Properties.Contains("title")) ? loResultado.Properties["title"][0].ToString().ToUpper() : null,
								Radio = (loResultado.Properties.Contains("ipPhone")) ? loResultado.Properties["ipPhone"][0].ToString().ToUpper() : null,
								Sucursal = (loResultado.Properties.Contains("l")) ? loResultado.Properties["l"][0].ToString().ToUpper() : null,
								Telefono = (loResultado.Properties.Contains("telephoneNumber")) ? loResultado.Properties["telephoneNumber"][0].ToString().ToUpper() : null,
								Titulo = (loResultado.Properties.Contains("initials")) ? loResultado.Properties["initials"][0].ToString().ToUpper() : null,
								UsuarioDominio = lsUsuarioDominio,
								UsuarioPrincipal = (loResultado.Properties.Contains("userPrincipalName")) ? loResultado.Properties["userPrincipalName"][0].ToString().ToLower() : null

								#endregion
							});
						}
							
					}
				}
				return loUsuarios;
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

        public string ObtenerPropiedad(Sesion poSesion, string psPropiedad)
        {
            string lsPropiedad = string.Empty;

            try
            {

                using (DirectoryEntry loEntrada = new DirectoryEntry("LDAP://" + poSesion.Conexion.Servidor, poSesion.Conexion.Credenciales.Usuario, poSesion.Conexion.Credenciales.Cifrado.Descifrar(poSesion.Conexion.Credenciales.Contrasenia)))
                {
                    using (DirectorySearcher loBuscador = new DirectorySearcher(loEntrada))
                    {
                        loBuscador.PropertiesToLoad.Add(psPropiedad);
                        loBuscador.Filter = "(&(objectCategory=person)(objectClass=user)(samAccountName=" + poSesion.Conexion.Credenciales.Usuario + "))";

                        SearchResult loResultado = loBuscador.FindOne();

                        if (loResultado != null)
                            lsPropiedad = loResultado.Properties[psPropiedad][0].ToString().ToUpper();
                    }
                }

                return lsPropiedad;
            }
            catch (Exception ex)
            {
                throw new Excepcion(ex.Message, ex);
            }
        }

        public bool PerteneceA(Sesion poSesion, string psGrupo)
        {

            try
            {
                PrincipalContext loContexto = new PrincipalContext(ContextType.Domain, poSesion.Conexion.Nombre, poSesion.Conexion.Credenciales.Usuario, poSesion.Conexion.Credenciales.Cifrado.Descifrar(poSesion.Conexion.Credenciales.Contrasenia));
                UserPrincipal loUsuario = UserPrincipal.FindByIdentity(loContexto, poSesion.Conexion.Credenciales.Usuario);
                GroupPrincipal loGrupo = GroupPrincipal.FindByIdentity(loContexto, psGrupo);

                if (loUsuario != null && loGrupo != null)
                    return loGrupo.Members.Contains(loUsuario);

                return false;
            }
            catch (Exception ex)
            {
                throw new Excepcion(ex.Message, ex);
            }
        }

        #endregion
    }
}
