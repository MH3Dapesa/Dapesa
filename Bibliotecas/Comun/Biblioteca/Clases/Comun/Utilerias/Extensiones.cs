using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace Dapesa.Comun.Utilerias
{
	public static class Extensiones
	{
		#region Metodos

		public static void BufferDoble(this DataGridView poGrid, bool pbBufferDoble)
		{
			PropertyInfo poInformacionPropiedad = poGrid.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

			poInformacionPropiedad.SetValue(poGrid, pbBufferDoble, null);
		}

		public static string Descripcion(this Enum poEnumeracion)
		{
			FieldInfo loInformacionElemento = poEnumeracion.GetType().GetField(poEnumeracion.ToString());
			var loDescripcion = (DescriptionAttribute[])loInformacionElemento.GetCustomAttributes(typeof(DescriptionAttribute), false);

			if (loDescripcion.Length > 0)
				return loDescripcion[0].Description;

			return poEnumeracion.ToString();
		}

		public static DateTime InicioSemana(this DateTime poFecha, DayOfWeek poDiaInicio)
		{
			int lnDiferencia = poFecha.DayOfWeek - poDiaInicio;

			if (lnDiferencia < 0)
				lnDiferencia += 7;

			return poFecha.AddDays(-1 * lnDiferencia).Date;
		}

		#endregion
	}
}
