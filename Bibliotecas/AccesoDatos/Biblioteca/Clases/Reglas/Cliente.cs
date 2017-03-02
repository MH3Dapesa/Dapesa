using Dapesa.AccesoDatos.Entidades;
using System.Data;

namespace Dapesa.AccesoDatos.Reglas
{
	internal abstract class Cliente
	{
		#region Atributos

		protected readonly string _sCadenaConexion;

		#endregion

		#region Constructor

		protected Cliente(string psCadenaConexion)
		{
			this._sCadenaConexion = psCadenaConexion;
		}

		#endregion

		#region Metodos

		protected abstract bool Conectar();
		protected abstract void CrearComando(Sentencia poSentencia);
		protected abstract bool Desconectar();
		protected abstract object EjecutarEscalar();
		protected abstract int EjecutarNoQuery();
		protected abstract DataTable EjecutarQuery();
		protected abstract object ObtenerParametro(string psNombreParametro);

		#endregion
	}
}
