using System.Data;

namespace Dapesa.Comun.Informes.Reglas
{
	public class Comun
	{
		#region Metodos

		public DataTable ObtenerEncabezado(string psDescripcion, string psPeriodo)
		{
			DataTable loEncabezado = new DataTable() {
				Columns = {
					new DataColumn("DESCRIPCION", typeof(string)),
					new DataColumn("PERIODO", typeof(string))
				}
			};

			loEncabezado.Rows.Add(new object[] { psDescripcion, psPeriodo });
			return loEncabezado;
		}

		#endregion
	}
}
