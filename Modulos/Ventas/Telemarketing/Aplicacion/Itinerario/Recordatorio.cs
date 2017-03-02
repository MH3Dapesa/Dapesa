using Dapesa.Comunicaciones.Mensajeria.Reglas;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Dapesa.Ventas.Telemarketing.IU.Itinerario
{
	public partial class Recordatorio : Form
	{
		#region Atributos

		private Comunicaciones.Mensajeria.Entidades.Cita _oCita;
		private string _sFecha;

		#endregion

		#region Constructor

		public Recordatorio()
		{
			InitializeComponent();
			dtpHora.Format = DateTimePickerFormat.Custom;
			dtpHora.ShowUpDown = true;
			dtpHora.CustomFormat = "HH:mm";
		}

		#endregion

		#region Eventos

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			this.AgregarRecordatorio();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Recordatorio_Load(object sender, EventArgs e)
		{
			lblCita.Text = this._sFecha;
			dtpHora.Value = this.EstablecerFechaHora();
			dtpHora.Focus();
		}

		#endregion

		#region Metodos

		private void AgregarRecordatorio()
		{
			this._oCita.Inicio = dtpHora.Value;
			this._oCita.Contenido += "\r\n" + txtObservaciones.Text.ToUpper().Trim();
			this._oCita.Fin = dtpHora.Value.AddMinutes(int.Parse(ConfigurationManager.AppSettings["CitaMinutosDuracion"]));
			this._oCita.RecordatorioMinutosAntesComienzo = int.Parse(ConfigurationManager.AppSettings["CitaAlertaMinutosAntesComienzo"]);

			try
			{
				CitaOutlook loCita = new CitaOutlook(this._oCita);

				loCita.Enviar();
				this.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private DateTime EstablecerFechaHora()
		{
			int lnHora = 0;
			int lnMinuto = 0;
			string[] lsFecha = this._sFecha.Split('/');

			if (DateTime.Now.Minute < 30)
			{
				lnHora = DateTime.Now.Hour;
				lnMinuto = 30;
			}
			else
				lnHora = DateTime.Now.AddHours(1).Hour;

			return new DateTime(
				int.Parse(lsFecha[2]), int.Parse(lsFecha[1]), int.Parse(lsFecha[0]), lnHora, lnMinuto, 0
			);
		}

		#endregion

		#region Propiedades

		internal Comunicaciones.Mensajeria.Entidades.Cita Cita
		{
			set
			{
				this._oCita = value;
			}
		}

		internal string Fecha
		{
			set
			{
				this._sFecha = value;
			}
		}

		#endregion
	}
}
