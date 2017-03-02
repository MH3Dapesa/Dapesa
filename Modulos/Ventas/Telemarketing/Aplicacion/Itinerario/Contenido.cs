using Dapesa.Comun.Utilerias;
using Dapesa.Comunicaciones.Mensajeria.Entidades;
using Dapesa.Ventas.Telemarketing.Comun;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Dapesa.Ventas.Telemarketing.IU.Itinerario
{
	public partial class Contenido : Form, IMessageFilter
	{
		#region Atributos

		private readonly int _nAnio;
		private readonly int _nSemanaActual;
		private int _nSemanaMostrada;
		private DateTime _oInicioSemana;
        private DateTime _oFechaSemanaActual = DateTime.Now;
        private DateTime _oFechaSemanaAnterior = DateTime.Now.AddDays(-7);

		#endregion

		#region Constructor
		
		public Contenido()
		{
			InitializeComponent();
			Application.AddMessageFilter(this);
			ttInformacion.SetToolTip(btnActualizar, "Actualizar información (F5)");
			ttInformacion.SetToolTip(btnAnterior, "Retroceder semana (F10)"); 
			ttInformacion.SetToolTip(btnGuardar, "Guardar información (Ctrl+G)");
			ttInformacion.SetToolTip(btnSiguiente, "Avanzar semana (F8)");
			#region Determinar mes/año actuales

			CultureInfo loCultureInfo = new CultureInfo("es-MX");

			this._nAnio = DateTime.Now.Year;
            //agregado
            this._oFechaSemanaActual = DateTime.Now;
            this._oFechaSemanaAnterior = DateTime.Now.AddDays(-7);
            //fin

            DateTime loFecha = DateTime.Now;
            DayOfWeek loDia = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(loFecha);
            if (loDia >= DayOfWeek.Monday && loDia <= DayOfWeek.Wednesday)
            {
                loFecha = loFecha.AddDays(3);
            }

            // Retorna dia de la semana Ajustado cambio de año y Bisiesto
            this._nSemanaActual = this._nSemanaMostrada = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(loFecha, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);




            //this._nSemanaActual = this._nSemanaMostrada = loCultureInfo.Calendar.GetWeekOfYear(
            //    DateTime.Now, loCultureInfo.DateTimeFormat.CalendarWeekRule, loCultureInfo.DateTimeFormat.FirstDayOfWeek
            //);
			this._oInicioSemana = DateTime.Now.InicioSemana(DayOfWeek.Monday);
			ttInformacion.SetToolTip(btnSemanaActual, "Mostrar semana actual: SEMANA " + this._nSemanaActual +" (Ctrl+H)");

			#endregion
		}

		#endregion

		#region Eventos

		private void btnActualizar_Click(object sender, EventArgs e)
		{
			this.ActualizarItinerario();
		}

		private void btnAnterior_Click(object sender, EventArgs e)
		{
			this.RetrocederSemana();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			this.GuardarItinerario(this._nAnio, this._nSemanaMostrada);
		}

		private void btnSemanaActual_Click(object sender, EventArgs e)
		{
			this.MostrarSemanaActual();
		}

		private void btnSiguiente_Click(object sender, EventArgs e)
		{
			this.AvanzarSemana();
		}
		
		private void celdaActual_TextoModificado(object sender, ArgumentosEvento e)
		{
			dgvItinerario.CurrentCell.Value = e.Texto;
		}

		private void Contenido_Load(object sender, EventArgs e)
		{
			this.EnlazarDatos(this._nAnio, this._nSemanaActual, false);
		}

		private void Contenido_Shown(object sender, EventArgs e)
		{
			((Contenedor)this.MdiParent).Semana = "SEMANA: " + this._nSemanaActual;
			this.WindowState = FormWindowState.Maximized;
			dgvItinerario.BufferDoble(true);
			dgvTotales.ClearSelection();
		}

		private void cliente_Buscar(object sender, ArgumentosEvento e)
		{
			bool lbEncontrado = false;
			string lsValor = e.Texto;

			foreach (DataGridViewRow loFila in dgvItinerario.Rows)
				#region Buscar coincidencias

				if (loFila.Cells["dgvtbcClave"].Value.ToString().ToUpper() == lsValor.ToUpper())
				{
					dgvItinerario.ClearSelection();
					dgvItinerario.FirstDisplayedScrollingRowIndex = loFila.Index;
					loFila.Selected = true;
					lbEncontrado = true;
					break;
				}

				#endregion

			if (!lbEncontrado)
				MessageBox.Show("No existe un cliente con la clave suministrada.\r\nIntente una nueva búsqueda proporcionando otro valor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void clienteActual_ContactoAgregado(object sender, EventArgs e)
		{
			this.EnlazarDatos(this._nAnio, this._nSemanaMostrada, true);
		}

		private void dgvItinerario_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{

			//Si el cliente está INACTIVO, salir
			if (((DataTable)bsItinerario.DataSource).Rows[e.RowIndex]["STATUS"].ToString() == Telemarketing.Comun.Definiciones.TipoEstatusCliente.Inactivo.Descripcion())
				e.Cancel = true;
			else
			{
				//Celda: CONTACTO
				if (((DataGridView)sender).CurrentCell.ColumnIndex == ((DataGridView)sender).Columns["dgvtbcContacto"].Index)
					#region Editar contacto
				{
					e.Cancel = true;

					//Si el cliente ya tiene un contacto asociado, establecer su información
					if (!string.IsNullOrEmpty(((DataTable)bsItinerario.DataSource).Rows[e.RowIndex]["CONTACTO"].ToString().Trim()))
					{
						Tooltip loEmergente = new Tooltip() {
							#region Inicializar propiedades

							ControlBox = false,
							FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow,
							MinimizeBox = false,
							Owner = this,
							ShowIcon = false,
							ShowInTaskbar = false,
							StartPosition = FormStartPosition.CenterScreen,
							TextoInformativo =
								((DataTable)bsItinerario.DataSource).Rows[e.RowIndex]["CONTACTO"].ToString() + "\r\n\r\nINFORMACIÓN DE CONTACTO\r\n" + ((DataTable)bsItinerario.DataSource).Rows[e.RowIndex]["TOOLTIP"].ToString(),
							WindowState = FormWindowState.Normal

							#endregion
						};

						loEmergente.ShowDialog();
					}
					//Si no, crear contacto
					else
					{
						EditorContacto loContacto = new EditorContacto()
						{
							#region Inicializar propiedades

							ClaveCliente = ((DataTable)bsItinerario.DataSource).Rows[e.RowIndex]["CLAVE"].ToString().Trim(),
							ControlBox = true,
							Cliente = ((DataTable)bsItinerario.DataSource).Rows[e.RowIndex]["NOMBRE"].ToString().Trim(),
							FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle,
							MinimizeBox = false,
							Owner = this,
							ShowIcon = true,
							ShowInTaskbar = false,
							StartPosition = FormStartPosition.CenterScreen,
							WindowState = FormWindowState.Normal

							#endregion
						};

						loContacto.ContactoAgregadoEvento += new Comun.Definiciones.ContactoAgregadoManejadorEvento(
							this.clienteActual_ContactoAgregado
						);
						loContacto.ShowDialog();
					}
				}
					#endregion
				else
					#region Editar observaciones/texto itinerario
				{
					//Si es la celda: OBSERVACIONES
					if (((DataGridView)sender).CurrentCell.ColumnIndex == ((DataGridView)sender).Columns["dgvtbcObservaciones"].Index)
					{
						e.Cancel = true;				

						//Si el cliente tiene un contacto asociado
						if (!string.IsNullOrEmpty(((DataTable)bsItinerario.DataSource).Rows[e.RowIndex]["CONTACTO"].ToString().Trim()))
						{
							EditorObservaciones loObservaciones = new EditorObservaciones() {
								#region Inicializar propiedades

								ControlBox = true,
								FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle,
								MinimizeBox = false,
								Owner = this,
								ShowIcon = true,
								ShowInTaskbar = false,
								StartPosition = FormStartPosition.CenterScreen,
								Texto = ((DataGridView)sender).CurrentCell.Value.ToString(),
								WindowState = FormWindowState.Normal

								#endregion
							};

							loObservaciones.TextoModificadoEvento += new Comun.Definiciones.TextoModificadoManejadorEvento(
								this.celdaActual_TextoModificado
							);
							loObservaciones.ShowDialog();
						}
					}
					//Si no, validar/proteger montos
					else 
						#region Validar/proteger montos
					{

						//Si la fecha es menor al día de hoy
						if (DateTime.Now.Date > DateTime.Parse(
							((DataGridView)sender).Columns[((DataGridView)sender).CurrentCell.ColumnIndex].HeaderText.Split(' ')[1]))
							e.Cancel = true;
						//Si no, si es un monto
						else if (
							(decimal)((DataTable)bsItinerario.DataSource).Rows[e.RowIndex]["VTA_" + ((DataGridView)sender).Columns[((DataGridView)sender).CurrentCell.ColumnIndex].DataPropertyName] > 0)
							e.Cancel = true;
					}

						#endregion
				}
					#endregion
			}
		}

		private void dgvItinerario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			#region Formatear celdas

			//Si cliente está asignado temporalmente, cambiar color de celda y clave de cliente
			if (((DataGridView)sender).Rows[e.RowIndex].Cells["dgvtbcTipo"].Value.ToString() == Telemarketing.Comun.Definiciones.TipoAsignacion.Temporal.Descripcion())
			{
				((DataGridView)sender).Rows[e.RowIndex].Cells["dgvtbcClave"].Style.BackColor = Color.WhiteSmoke;
				((DataGridView)sender).Rows[e.RowIndex].Cells["dgvtbcClave"].Style.Font = new Font(((DataGridView)sender).Font, FontStyle.Bold);
				((DataGridView)sender).Rows[e.RowIndex].Cells["dgvtbcClave"].Style.ForeColor = Color.Green;
			}

			//Si cliente está inactivo, cambiar color de fila y fuente
			if (e.ColumnIndex == ((DataGridView)sender).Columns["dgvtbcStatus"].Index && e.Value.ToString() == Telemarketing.Comun.Definiciones.TipoEstatusCliente.Inactivo.Descripcion())
			{
				((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gold;
				((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
			}

			//Si el crédito disponible del cliente, es negativo, cambiar color de fuente
			if (e.ColumnIndex == ((DataGridView)sender).Columns["dgvtbcCredDisp"].Index)
				((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor =
					(decimal)((DataTable)bsItinerario.DataSource).Rows[e.RowIndex]["CREDITO_DISPONIBLE"] < 0 ? Color.Red : Color.Black;

			//Si se tiene una fecha de última compra del cliente, cambiar color de fuente
			if (e.ColumnIndex == ((DataGridView)sender).Columns["dgvtbcFecUltVta"].Index &&
			   ((DataTable)bsItinerario.DataSource).Rows[e.RowIndex]["FECHA_ULT_VTA"] != DBNull.Value)
			{
				DateTime loUltimaCompra = (DateTime)((DataTable)bsItinerario.DataSource).Rows[e.RowIndex]["FECHA_ULT_VTA"];
				TimeSpan loDiferencia = DateTime.Now - loUltimaCompra;

				((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor =
					//Si es igual al año/mes actual
					((loUltimaCompra.Year == DateTime.Now.Year && loUltimaCompra.Month == DateTime.Now.Month) ? Color.RoyalBlue :
					//Si no, si la fecha de última compra del cliente tiene más de 90 días, cambiar color de fuente a ROJO
					(loDiferencia.Days > 90) ? Color.Red : Color.Black);
			}

			//Si la columna actual es LUNES, agregar fecha al encabezado de las columnas de los días de la semana
			if (e.ColumnIndex == ((DataGridView)sender).Columns["dgvtbcLunes"].Index &&
			   ((DataGridView)sender).Columns[e.ColumnIndex].HeaderText.ToUpper() ==
				 CultureInfo.GetCultureInfo("es-MX").DateTimeFormat.DayNames[(int)DayOfWeek.Monday].ToUpper())
			{
				((DataGridView)sender).Columns[e.ColumnIndex+0].HeaderText = "LUNES " + this._oInicioSemana.AddDays((int)DayOfWeek.Monday - 1).ToString("dd/MM/yyy");
				((DataGridView)sender).Columns[e.ColumnIndex+1].HeaderText = "MARTES " + this._oInicioSemana.AddDays((int)DayOfWeek.Tuesday - 1).ToString("dd/MM/yyy");
				((DataGridView)sender).Columns[e.ColumnIndex+2].HeaderText = "MIÉRCOLES " + this._oInicioSemana.AddDays((int)DayOfWeek.Wednesday - 1).ToString("dd/MM/yyy");
				((DataGridView)sender).Columns[e.ColumnIndex+3].HeaderText = "JUEVES " + this._oInicioSemana.AddDays((int)DayOfWeek.Thursday - 1).ToString("dd/MM/yyy");
				((DataGridView)sender).Columns[e.ColumnIndex+4].HeaderText = "VIERNES " + this._oInicioSemana.AddDays((int)DayOfWeek.Friday - 1).ToString("dd/MM/yyy");
				((DataGridView)sender).Columns[e.ColumnIndex+5].HeaderText = "SÁBADO " + this._oInicioSemana.AddDays((int)DayOfWeek.Saturday - 1).ToString("dd/MM/yyy");
			}

			#endregion
		}

		private void dgvItinerario_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{

			if (e.ColumnIndex != -1 && e.RowIndex != -1 && 
				e.Button == MouseButtons.Right)
			{
				((DataGridView)sender).CurrentCell = ((DataGridView)sender)[e.ColumnIndex, e.RowIndex];

				this.ValidarRecordatorio(
					((DataGridView)sender).CurrentCell, 
					e.ColumnIndex, e.RowIndex, e.X, e.Y, false
				);
			}
		}

		private void dgvItinerario_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{

			if (e.Control is TextBox)
			{
				((TextBox)e.Control).CharacterCasing = CharacterCasing.Upper;
				((TextBox)e.Control).MaxLength = 128;
				e.Control.ContextMenu = new ContextMenu();
			}
		}

		private void tsmiCita_Click(object sender, EventArgs e)
		{
			this.AgregarRecordatorio();
		}

		#endregion

		#region Metodos

		private void ActualizarEncabezados()
		{
			dgvItinerario.Columns["dgvtbcLunes"].HeaderText = "LUNES " + this._oInicioSemana.AddDays((int)DayOfWeek.Monday - 1).ToString("dd/MM/yyy");
			dgvItinerario.Columns["dgvtbcMartes"].HeaderText = "MARTES " + this._oInicioSemana.AddDays((int)DayOfWeek.Tuesday - 1).ToString("dd/MM/yyy");
			dgvItinerario.Columns["dgvtbcMiercoles"].HeaderText = "MIÉRCOLES " + this._oInicioSemana.AddDays((int)DayOfWeek.Wednesday - 1).ToString("dd/MM/yyy");
			dgvItinerario.Columns["dgvtbcJueves"].HeaderText = "JUEVES " + this._oInicioSemana.AddDays((int)DayOfWeek.Thursday - 1).ToString("dd/MM/yyy");
			dgvItinerario.Columns["dgvtbcViernes"].HeaderText = "VIERNES " + this._oInicioSemana.AddDays((int)DayOfWeek.Friday - 1).ToString("dd/MM/yyy");
			dgvItinerario.Columns["dgvtbcSabado"].HeaderText = "SÁBADO " + this._oInicioSemana.AddDays((int)DayOfWeek.Saturday - 1).ToString("dd/MM/yyy");
		}

		private void ActualizarItinerario()
		{
			if ((DataTable)this.CambiosPorAplicar != null &&
				 DialogResult.Cancel == MessageBox.Show("Existen cambios en el itinerario sin guardar.\n\rSi continúa con la actualización, perderá los cambios realizados.",
					"Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
				) return;
            //agregado
            _oFechaSemanaActual = DateTime.Now;
            _oFechaSemanaAnterior = DateTime.Now.AddDays(-7);
            //fin
            //this.EnlazarDatos(this._nAnio, this._nSemanaMostrada, true);

            this.EnlazarDatos(this._nAnio, this._nSemanaMostrada, true);
		}

		private void AgregarRecordatorio()
		{
			Recordatorio loRecordatorio = new Recordatorio() {
				#region Inicializar propiedades

				Cita = new Cita() {
					#region Inicializar propiedades

					Asunto =
						((DataTable)bsItinerario.DataSource).Rows[dgvItinerario.CurrentCell.RowIndex]["CLAVE"].ToString() + "- " +
						((DataTable)bsItinerario.DataSource).Rows[dgvItinerario.CurrentCell.RowIndex]["NOMBRE"].ToString(),
					Contenido =
						dgvItinerario.CurrentCell.Value.ToString()

					#endregion
				},
				ControlBox = true,
				Fecha = dgvItinerario.Columns[dgvItinerario.CurrentCell.ColumnIndex].HeaderText.Split(' ')[1],
				FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle,
				MinimizeBox = false,
				Owner = this,
				ShowIcon = true,
				ShowInTaskbar = false,
				StartPosition = FormStartPosition.CenterScreen,
				WindowState = FormWindowState.Normal

				#endregion
			};

			loRecordatorio.ShowDialog();
		}

		private void AvanzarSemana()
		{

			if ((DataTable)this.CambiosPorAplicar != null &&
				 DialogResult.Cancel == MessageBox.Show("Existen cambios en el itinerario sin guardar.\n\rSi continúa con el avance de semana, perderá los cambios realizados.",
					"Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
				) return;

			this._oInicioSemana = this._oInicioSemana.AddDays(7);
            //Controlar Semana por fecha 
            _oFechaSemanaActual = _oFechaSemanaActual.AddDays(7);
            _oFechaSemanaAnterior = _oFechaSemanaAnterior.AddDays(7);
            //
			if (this._nSemanaMostrada < this._nSemanaActual + 1)
			{
				this.EnlazarDatos(this._nAnio, ++this._nSemanaMostrada, true);
				this.ActualizarEncabezados();
			}

			if (this._nSemanaMostrada == this._nSemanaActual + 1)
				btnSiguiente.Enabled = false;
			else
				btnAnterior.Enabled = true;

			((Contenedor)this.MdiParent).Semana = "SEMANA: " + this._nSemanaMostrada;
			dgvItinerario.ReadOnly = this._nSemanaMostrada < this._nSemanaActual;
			btnActualizar.Enabled = this._nSemanaMostrada >= this._nSemanaActual;
			btnGuardar.Enabled = this._nSemanaMostrada >= this._nSemanaActual;
		}

		private void BuscarCliente()
		{
			Buscador loBuscador = new Buscador() {
				#region Inicializar propiedades

				ControlBox = true,
				FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle,
				MinimizeBox = false,
				Owner = this,
				ShowIcon = true,
				ShowInTaskbar = false,
				StartPosition = FormStartPosition.CenterScreen,
				WindowState = FormWindowState.Normal

				#endregion
			};

			loBuscador.TextoModificadoEvento += new Comun.Definiciones.TextoModificadoManejadorEvento(
					this.cliente_Buscar
				);
			loBuscador.ShowDialog();
		}

		private void EnlazarDatos(int pnAnio, int pnSemana, bool pbActualizarFechaHora)
		{
			Cursor.Current = Cursors.WaitCursor;
			this.Enabled = false;
			
			try
			{
				Reglas.Itinerario loItinerario = new Reglas.Itinerario();

				bsItinerario.DataSource = loItinerario.Obtener(
					((InicioSesion)this.MdiParent.Owner).Sesion, pnAnio, pnSemana
				);
				bsTotales.DataSource = loItinerario.ObtenerTotalSemanal(
					((InicioSesion)this.MdiParent.Owner).Sesion, _oFechaSemanaActual, _oFechaSemanaAnterior
				);

				if (dgvItinerario.Rows.Count > 0)
				{
					dgvItinerario.FirstDisplayedScrollingColumnIndex =
						dgvItinerario.Rows[dgvItinerario.CurrentCell.RowIndex].Cells["dgvtbcVendedor"].ColumnIndex;
				}

				btnAnterior.Enabled = btnSemanaActual.Enabled = btnSiguiente.Enabled =
					btnGuardar.Enabled = btnActualizar.Enabled = dgvItinerario.Rows.Count > 0;
				dgvTotales.ClearSelection();
				
				if (pbActualizarFechaHora)
					((Contenedor)this.MdiParent).UltimaActualizacion = "ÚLTIMA ACTUALIZACIÓN: " +
						DateTime.Now.ToString("dddd, dd/MM/yyyy HH:mm:ss").ToUpper();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				this.Enabled = true;
				Cursor.Current = Cursors.Default;
				dgvItinerario.Focus();
			}
		}

		private void GuardarItinerario(int pnAnio, int pnSemana)
		{
			Cursor.Current = Cursors.WaitCursor;
			this.Enabled = false;

			try
			{
				Reglas.Itinerario loItinerario = new Reglas.Itinerario();
                //agregado
                _oFechaSemanaActual = DateTime.Now;
                _oFechaSemanaAnterior = DateTime.Now.AddDays(-7);
                //fin
				if (loItinerario.Guardar(
						((InicioSesion)this.MdiParent.Owner).Sesion, 
						  this.CambiosPorAplicar, pnAnio, pnSemana))
					this.EnlazarDatos(pnAnio, pnSemana, true);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				this.Enabled = true;
				Cursor.Current = Cursors.Default;
				dgvItinerario.Update();
				dgvItinerario.Focus();
			}
		}

		private void MostrarSemanaActual()
		{

			if ((DataTable)this.CambiosPorAplicar != null &&
				 DialogResult.Cancel == MessageBox.Show("Existen cambios en el itinerario sin guardar.\n\rSi cambia a la semana actual (SEMANA " + this._nSemanaActual + "), perderá los cambios realizados.",
					"Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
				) return;
            //agregado
            _oFechaSemanaActual = DateTime.Now;
            _oFechaSemanaAnterior = DateTime.Now.AddDays(-7);
            //fin
			this._oInicioSemana = DateTime.Now.InicioSemana(DayOfWeek.Monday);
			this._nSemanaMostrada = this._nSemanaActual;
			this.EnlazarDatos(this._nAnio, this._nSemanaMostrada, true);
			this.ActualizarEncabezados();

			btnSiguiente.Enabled = true;
			btnAnterior.Enabled = true;
			
			((Contenedor)this.MdiParent).Semana = "SEMANA: " + this._nSemanaMostrada;
			dgvItinerario.ReadOnly = false;
			btnActualizar.Enabled = true;
			btnGuardar.Enabled = true;
		}

		public bool PreFilterMessage(ref Message poMensajeWindows)
		{
			Keys loCodigo = (Keys)(int)poMensajeWindows.WParam & Keys.KeyCode;

			if (loCodigo == Keys.Snapshot)
			{
				Clipboard.Clear();
				return true;
			}

			return false;
		}

		protected override bool ProcessCmdKey(ref Message poMensajeWindows, Keys poOpcion)
		{

			switch (poOpcion)
			{
				case Keys.F5:
					this.ActualizarItinerario();
					return true;
				case Keys.F8:
					this.AvanzarSemana();
					return true;
				case Keys.F10:
					this.RetrocederSemana();
					return true;
				case (Keys.Control | Keys.B):
					this.BuscarCliente();
					return true;
				case (Keys.Control | Keys.G):
					
					if (!btnGuardar.Enabled)
						return false;

					this.GuardarItinerario(this._nAnio, this._nSemanaActual);
					return true;
				case (Keys.Control | Keys.H):
					this.MostrarSemanaActual();
					return true;
				case (Keys.Control | Keys.Q):
					this.ValidarRecordatorio(
						dgvItinerario.CurrentCell, dgvItinerario.CurrentCell.ColumnIndex, -1, -1, -1, true
					);
					return true;
				default:
					return base.ProcessCmdKey(ref poMensajeWindows, poOpcion);
			}
		}

		private void RetrocederSemana()
		{

			if ((DataTable)this.CambiosPorAplicar != null && 
				 DialogResult.Cancel == MessageBox.Show("Existen cambios en el itinerario sin guardar.\n\rSi continúa el retroceso de semana, perderá los cambios realizados.",
					"Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
				) return;

			this._oInicioSemana = this._oInicioSemana.AddDays(-7);
            //agregado
                _oFechaSemanaActual = _oFechaSemanaActual.AddDays(-7);
                _oFechaSemanaAnterior =_oFechaSemanaAnterior.AddDays(-7);
            //fin
			if (this._nSemanaMostrada > this._nSemanaActual - 4)
			{
                //this.EnlazarDatos(this._nAnio, --this._nSemanaMostrada, true);
                this.EnlazarDatos(this._nAnio, --this._nSemanaMostrada, true);
                this.ActualizarEncabezados();
			}

			if (this._nSemanaMostrada == this._nSemanaActual - 4)
				btnAnterior.Enabled = false;
			else
				btnSiguiente.Enabled = true;

			((Contenedor)this.MdiParent).Semana = "SEMANA: " + this._nSemanaMostrada;
			dgvItinerario.ReadOnly = this._nSemanaMostrada < this._nSemanaActual;
			btnActualizar.Enabled = this._nSemanaMostrada >= this._nSemanaActual;
			btnGuardar.Enabled = this._nSemanaMostrada >= this._nSemanaActual;
		}

		private void ValidarRecordatorio(DataGridViewCell poCeldaActual, int pnColumnaActual, int pnFilaActual, int pnCoordenadaX, int pnCoordenadaY, bool pbEsAtajo)
		{
			#region Validar celda

			//Si la celda está en modo edición y su contenido nulo, 
			//	o la celda no es L,Ma,Mi,J o V,
			//	o la fecha es menor al día de hoy: SALIR
			if (poCeldaActual.IsInEditMode ||
				string.IsNullOrEmpty(poCeldaActual.Value.ToString().Trim()) || !(
				pnColumnaActual == dgvItinerario.Columns["dgvtbcLunes"].Index ||
				pnColumnaActual == dgvItinerario.Columns["dgvtbcMartes"].Index ||
				pnColumnaActual == dgvItinerario.Columns["dgvtbcMiercoles"].Index ||
				pnColumnaActual == dgvItinerario.Columns["dgvtbcJueves"].Index ||
				pnColumnaActual == dgvItinerario.Columns["dgvtbcViernes"].Index ||
				pnColumnaActual == dgvItinerario.Columns["dgvtbcSabado"].Index) ||
				DateTime.Now.Date > DateTime.Parse(
					dgvItinerario.Columns[poCeldaActual.ColumnIndex].HeaderText.Split(' ')[1]))
				return;

			#endregion

			if (!pbEsAtajo)
			{
				Rectangle loRectangulo = poCeldaActual.DataGridView.GetCellDisplayRectangle(pnColumnaActual, pnFilaActual, false);
				Point loPunto = new Point(loRectangulo.X + pnCoordenadaX, loRectangulo.Y + pnCoordenadaY);

				cmsCita.Show(poCeldaActual.DataGridView, loPunto);
			}
			else
			{
				this.AgregarRecordatorio();
			}
		}

		#endregion

		#region Propiedades

		internal DataTable CambiosPorAplicar
		{
			get
			{
				DataTable loCambios =
					((DataTable)bsItinerario.DataSource).GetChanges(DataRowState.Modified);

				return loCambios;
			}
		}

		#endregion
	}
}
