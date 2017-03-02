using Dapesa.Criptografia.Comun;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace Dapesa.Criptografia.Reglas
{
	[DataContract]
	public class Cifrado : ICifrado
	{
		#region Atributos

		[DataMember]private readonly Comun.Definiciones.TipoCifrado _oAlgoritmo;
		[DataMember]private byte[] _oLlave { get; set; }
		[DataMember]private byte[] _oVectorInicializacion { get; set; }

		#endregion

		#region Constructor

		public Cifrado(Comun.Definiciones.TipoCifrado poAlgoritmo)
		{
			this._oAlgoritmo = poAlgoritmo;
		}

		#endregion

		#region Metodos

		public byte[] Cifrar(string psEntrada)
		{
			
			switch (this._oAlgoritmo)
			{
				case Definiciones.TipoCifrado.AES:
					return this.CifrarAES(psEntrada);
				case Definiciones.TipoCifrado.MD5:
					return this.CifrarMD5(psEntrada);
				case Definiciones.TipoCifrado.SHA1:
					return this.CifrarSHA1(psEntrada);
				default:
					return null;
			}
		}

		public string Descifrar(byte[] poEntrada)
		{

			switch (this._oAlgoritmo)
			{
				case Definiciones.TipoCifrado.AES:
					return this.DescifrarAES(poEntrada);
				case Definiciones.TipoCifrado.MD5:
					return this.DescifrarMD5(poEntrada);
				case Definiciones.TipoCifrado.SHA1:
					return this.DescifrarSHA1(poEntrada);
				default:
					return string.Empty;
			}
		}

		public bool Verificar(string psTextoValidar, string psTextoComparar)
		{
			StringComparer loComparador = StringComparer.OrdinalIgnoreCase;

			if (loComparador.Compare(psTextoValidar, psTextoComparar) == 0)
				return true;
				
			return false;
		}

		private byte[] CifrarAES(string psEntrada)
		{
			byte[] loBytesCifrado = null;

			if (string.IsNullOrEmpty(psEntrada))
				return null;

			using (AesCryptoServiceProvider loAES = new AesCryptoServiceProvider())
			{

				if (this._oLlave == null)
					this._oLlave = loAES.Key;

				if (this._oVectorInicializacion == null)
					this._oVectorInicializacion = loAES.IV;

				ICryptoTransform loCifrador = loAES.CreateEncryptor(this._oLlave, this._oVectorInicializacion);

				using (MemoryStream loStream = new MemoryStream())
				{
					using (CryptoStream loStreamCifrado = new CryptoStream(loStream, loCifrador, CryptoStreamMode.Write))
					{
						using (StreamWriter loEscritor = new StreamWriter(loStreamCifrado))
						{
							loEscritor.Write(psEntrada);
						}
						
						loBytesCifrado = loStream.ToArray();
					}
				}
			}

			return loBytesCifrado;
		}

		private byte[] CifrarMD5(string psEntrada)
		{
			MD5CryptoServiceProvider loHasher = new MD5CryptoServiceProvider();

			return loHasher.ComputeHash(Encoding.Default.GetBytes(psEntrada));
		}

		private byte[] CifrarSHA1(string psEntrada)
		{
			SHA1CryptoServiceProvider loHasher = new SHA1CryptoServiceProvider();

			return loHasher.ComputeHash(Encoding.Default.GetBytes(psEntrada));
		}

		private string DescifrarAES(byte[] poEntrada)
		{
			string loTextoCifrado = string.Empty;

			if (poEntrada == null || poEntrada.Length <= 0)
				return string.Empty;
			if (this._oLlave == null || this._oLlave.Length <= 0)
				throw new Excepcion("Llave no válida");
			if (this._oVectorInicializacion == null || this._oVectorInicializacion.Length <= 0)
				throw new Excepcion("Vector de inicialización no válido");

			using (AesCryptoServiceProvider loAES = new AesCryptoServiceProvider())
			{
				loAES.Key = this._oLlave;
				loAES.IV = this._oVectorInicializacion;

				ICryptoTransform loDescifrador = loAES.CreateDecryptor(this._oLlave, this._oVectorInicializacion);

				using (MemoryStream loStream = new MemoryStream(poEntrada))
				{
					using (CryptoStream loStreamCifrado = new CryptoStream(loStream, loDescifrador, CryptoStreamMode.Read))
					{
						using (StreamReader loLector = new StreamReader(loStreamCifrado))
						{
							loTextoCifrado = loLector.ReadToEnd();
						}
					}
				}
			}

			return loTextoCifrado;
		}

		private string DescifrarMD5(byte[] poEntrada)
		{
			StringBuilder loBuilder = new StringBuilder();

			for (int i = 0; i < poEntrada.Length; i++)
				loBuilder.Append(poEntrada[i].ToString("x2"));
			
			return loBuilder.ToString();
		}

		private string DescifrarSHA1(byte[] poEntrada)
		{
			StringBuilder loBuilder = new StringBuilder();

			for (int i = 0; i < poEntrada.Length; i++)
				loBuilder.Append(poEntrada[i].ToString());
				//	para devolver el valor como hexadecimal:
				//loBuilder.Append(poEntrada[i].ToString("x2"));

			return loBuilder.ToString();
		}

		#endregion
	}
}
