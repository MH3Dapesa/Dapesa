namespace Dapesa.Almacen.Pedidos.Trazabilidad.Reglas
{
	public interface IDocumentacion
	{
		#region Metodos

		void ActualizarConsignatario();
		void EstablecerConsignatario();
		void LimpiarConsignatario();

		#endregion
	}
}
