namespace Dapesa.Comunicaciones.Mensajeria.Reglas
{
	interface IMensaje
	{
		#region Metodos

		bool Enviar();
		void EstablecerContenido(string psContenido);

		#endregion
	}
}
