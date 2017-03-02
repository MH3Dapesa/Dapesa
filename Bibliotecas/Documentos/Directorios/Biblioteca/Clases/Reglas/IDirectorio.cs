namespace Dapesa.Documentos.Directorios.Reglas
{
	interface IDirectorio
	{
		#region Propiedades

		Contenido Contenido { get; }
		string Ruta { get; set; }

		#endregion
	}
}
