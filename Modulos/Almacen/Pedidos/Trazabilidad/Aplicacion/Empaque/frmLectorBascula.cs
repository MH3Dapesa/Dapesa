using Dapesa.Almacen.Pedidos.Trazabilidad.Entidades.Empaque;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace Dapesa.Almacen.Pedidos.Trazabilidad.IU.Empaque
{
	public partial class frmLectorBascula : Form
	{
		private delegate void DataReceivedDelegate(string psDatosEntrada);
		private FormWindowState _oUltimoEstadoFormulario;
		private int _nLongitudPedido;
		private SerialPort _oPuerto;
		private Timer _oTemporizador;

		public frmLectorBascula()
		{
			InitializeComponent();
			#region Inicializar objetos

			this._oUltimoEstadoFormulario = this.WindowState;
			this._nLongitudPedido = int.Parse(ConfigurationManager.AppSettings["LongitudPedido"]);
			this._oPuerto = new SerialPort(ConfigurationManager.AppSettings["NombrePuerto"]);
			this._oPuerto.DataReceived += new SerialDataReceivedEventHandler(oPuerto_DataReceived);
			this._oPuerto.BaudRate = 9600;
			this._oPuerto.DataBits = 8;
			this._oPuerto.DtrEnable = true;
			this._oPuerto.Handshake = Handshake.None;
			this._oPuerto.Parity = Parity.None;
			this._oPuerto.ReadTimeout = 500;
			this._oPuerto.RtsEnable = true;
			this._oPuerto.StopBits = StopBits.One;
			this._oPuerto.WriteTimeout = 500;
			this._oTemporizador = new System.Windows.Forms.Timer();
			this._oTemporizador.Tick += new EventHandler(oTemporizador_Tick);
			this._oTemporizador.Interval = int.Parse(ConfigurationManager.AppSettings["Intervalo"]);

			#endregion
		}

		private void frmLectorBascula_Load(object sender, EventArgs e)
		{

			try
			{
				if (!this._oPuerto.IsOpen)
					this._oPuerto.Open();
			}
			catch (IOException)// ioex)
			{
				//todo: some action
			}
			catch (Exception)// ex)
			{
				//todo: some action
			}
			finally
			{
				this._oTemporizador.Start();
			}
		}

		private void frmLectorBascula_FormClosed(object sender, FormClosedEventArgs e)
		{
			this._oTemporizador.Stop();
			this._oPuerto.Close();
		}

		private void frmLectorBascula_Resize(object sender, EventArgs e)
		{
			
			if (this.WindowState == this._oUltimoEstadoFormulario)
				return;

			this._oUltimoEstadoFormulario = this.WindowState;
			this.FijarTamanioLetraApropiado();
		}

		private void frmLectorBascula_ResizeEnd(object sender, EventArgs e)
		{
			this.FijarTamanioLetraApropiado();
		}

		#region Eventos

		private void btnB0_Click(object sender, EventArgs e)
		{
			txtPedido.Text += "0";
		}

		private void btnB1_Click(object sender, EventArgs e)
		{
			txtPedido.Text += "1";
		}

		private void btnB2_Click(object sender, EventArgs e)
		{
			txtPedido.Text += "2";
		}

		private void btnB3_Click(object sender, EventArgs e)
		{
			txtPedido.Text += "3";
		}

		private void btnB4_Click(object sender, EventArgs e)
		{
			txtPedido.Text += "4";
		}

		private void btnB5_Click(object sender, EventArgs e)
		{
			txtPedido.Text += "5";
		}

		private void btnB6_Click(object sender, EventArgs e)
		{
			txtPedido.Text += "6";
		}

		private void btnB7_Click(object sender, EventArgs e)
		{
			txtPedido.Text += "7";
		}

		private void btnB8_Click(object sender, EventArgs e)
		{
			txtPedido.Text += "8";
		}

		private void btnB9_Click(object sender, EventArgs e)
		{
			txtPedido.Text += "9";
		}

		private void btnBorrar_Click(object sender, EventArgs e)
		{

			if (txtPedido.Text == string.Empty)
				return;

			txtPedido.Text = txtPedido.Text.Substring(0, txtPedido.Text.Length - 1);
		}

		private void btnGrabar_Click(object sender, EventArgs e)
		{

			if (txtPedido.Text.Trim() == string.Empty || txtPeso.Text.Trim() == string.Empty)
				return;

			DialogResult loRespuesta = MessageBox.Show("GUARDAR:\n\n\tPedido: " + txtPedido.Text + "\n\tPeso: " + txtPeso.Text, "Mensaje de confirmación", MessageBoxButtons.OKCancel);

			if (loRespuesta == DialogResult.Cancel)
				return;

			Reglas.Empaque loEmpaque = new Reglas.Empaque();
			Paquete loPaquete = new Paquete();

			loPaquete.ClavePersonal = 2;
			loPaquete.FolioPedido = ConfigurationManager.AppSettings["FolioSucursal"];
			loPaquete.NumeroPedido = int.Parse(txtPedido.Text);
			loPaquete.Peso = double.Parse(txtPeso.Text);

			try
			{
				loEmpaque.GuardarPaquete(loPaquete);
			}
			catch (Exception)// ex)
			{
				//todo: some action
			}
		}

		private void oPuerto_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			string lsDatosEntrada = string.Empty;

			try
			{
				lsDatosEntrada = this._oPuerto.ReadExisting().Trim();
			}
			catch (TimeoutException)// toex)
			{
				//todo: some action
			}
			catch (Exception)// ex)
			{
				//todo: some action
			}
			finally
			{

				if (lsDatosEntrada != string.Empty && !lsDatosEntrada.Contains("kg"))
					txtPeso.Invoke(new DataReceivedDelegate(this.ActualizarPeso), lsDatosEntrada);
			}
		}

		private void oTemporizador_Tick(object sender, EventArgs e)
		{

			try
			{
				this._oPuerto.Write("P");
			}
			catch (TimeoutException)// toex)
			{
				//todo: some action
			}
			catch (Exception)// ex)
			{
				//todo: some action
			}
		}

		private void txtPedido_TextChanged(object sender, EventArgs e)
		{
			TextBox loRemitente = (TextBox)sender;

			if (loRemitente.Text.Length > this._nLongitudPedido)
				loRemitente.Text = loRemitente.Text.Substring(0, this._nLongitudPedido);
		}

		#endregion

		#region Metodos

		private void ActualizarPeso(string psDatosEntrada)
		{
			txtPeso.Text = psDatosEntrada;
		}
		
		public void FijarTamanioLetraApropiado()
		{
			double lnTamanioLetraBotonNumerico = 15;
			double lnTamanioLetraBotonTexto = 9;
			double lnTamanioLetraCajaTexto = 20; 
			double lnTamanioLetraEtiquetas = 6.75;

			#region Calcular tamanio de letra

			if (this.Size.Width != this.MinimumSize.Width && this.Size.Height != this.MinimumSize.Height)
			{
				lnTamanioLetraBotonNumerico = (btnB7.Size.Width / lnTamanioLetraBotonNumerico + btnB7.Size.Height / lnTamanioLetraBotonNumerico) * 2.0;
				lnTamanioLetraBotonTexto = (btnBorrar.Size.Width / lnTamanioLetraBotonTexto + btnBorrar.Size.Height / lnTamanioLetraBotonTexto) - 3.0;
				lnTamanioLetraEtiquetas = lnTamanioLetraBotonTexto - 2.5;
				lnTamanioLetraCajaTexto = lnTamanioLetraBotonNumerico + 5.0;
			}

			#endregion
			#region Establecer tamanio de letra

			btnB0.Font = new Font("Microsoft Sans Serif", (float)lnTamanioLetraBotonNumerico, FontStyle.Bold);
			btnB1.Font = new Font("Microsoft Sans Serif", (float)lnTamanioLetraBotonNumerico, FontStyle.Bold);
			btnB2.Font = new Font("Microsoft Sans Serif", (float)lnTamanioLetraBotonNumerico, FontStyle.Bold);
			btnB3.Font = new Font("Microsoft Sans Serif", (float)lnTamanioLetraBotonNumerico, FontStyle.Bold);
			btnB4.Font = new Font("Microsoft Sans Serif", (float)lnTamanioLetraBotonNumerico, FontStyle.Bold);
			btnB5.Font = new Font("Microsoft Sans Serif", (float)lnTamanioLetraBotonNumerico, FontStyle.Bold);
			btnB6.Font = new Font("Microsoft Sans Serif", (float)lnTamanioLetraBotonNumerico, FontStyle.Bold);
			btnB7.Font = new Font("Microsoft Sans Serif", (float)lnTamanioLetraBotonNumerico, FontStyle.Bold);
			btnB8.Font = new Font("Microsoft Sans Serif", (float)lnTamanioLetraBotonNumerico, FontStyle.Bold);
			btnB9.Font = new Font("Microsoft Sans Serif", (float)lnTamanioLetraBotonNumerico, FontStyle.Bold);
			btnGrabar.Font = new Font("Microsoft Sans Serif", (float)lnTamanioLetraBotonTexto, FontStyle.Bold);
			btnBorrar.Font = new Font("Microsoft Sans Serif", (float)lnTamanioLetraBotonTexto, FontStyle.Bold);
			txtPedido.Font = new Font("Microsoft Sans Serif", (float)(lnTamanioLetraCajaTexto), FontStyle.Bold);
			txtPeso.Font = new Font("Microsoft Sans Serif", (float)(lnTamanioLetraCajaTexto), FontStyle.Bold);
			lblPedido.Font = new Font("Microsoft Sans Serif", (float)(lnTamanioLetraEtiquetas), FontStyle.Bold);
			lblPeso.Font = new Font("Microsoft Sans Serif", (float)(lnTamanioLetraEtiquetas), FontStyle.Bold);

			#endregion
		}
		
		#endregion
	}
}
