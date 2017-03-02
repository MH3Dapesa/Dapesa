namespace Dapesa.Criptografia.Reglas
{
	interface ICifrado
	{
		#region Metodos

		byte[] Cifrar(string psEntrada);
		string Descifrar(byte[] psEntrada);
		bool Verificar(string psTextoValidar, string psTextoComparar);

		#endregion
	}
}
