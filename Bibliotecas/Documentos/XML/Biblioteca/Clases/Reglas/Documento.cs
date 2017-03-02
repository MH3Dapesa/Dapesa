namespace Dapesa.Documentos.XML.Reglas
{
	public abstract class Documento
	{
		#region Atributos

		protected readonly string _sDocumento;

		#endregion

		#region Constructor

		protected Documento(string psDocumento)
		{
			this._sDocumento = psDocumento;
		}

		#endregion
	}
}
