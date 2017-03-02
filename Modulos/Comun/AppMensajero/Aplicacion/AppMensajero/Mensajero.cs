using Dapesa.Seguridad.Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comun.Pedidos.IU.AppMensajero
{
    public partial class Mensajero : Form
    {
        public Mensajero()
        {
            InitializeComponent();

        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {

            txtHora.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm:ss");

        }

        #region Metodos

        public void EnlazarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;

            try
            {
                Dapesa.Comun.Pedidos.Reglas.AppMensajero loMensajero = new Dapesa.Comun.Pedidos.Reglas.AppMensajero();
                DataTable loPedidos = loMensajero.ObtenerPedidos(((InicioSesion)this.MdiParent.Owner).Sesion, DateTime.Parse(dtpFechaInicio.Text), DateTime.Parse(dtpFechaFinal.Text), int.Parse(cbSucursal.SelectedValue.ToString()));
                rvPedidos.Reset();

                rvPedidos.LocalReport.ReportPath = "Rdl/Pedidos.rdl";
                rvPedidos.LocalReport.ReportEmbeddedResource = "Rdl/Pedidos.rdl";
                rvPedidos.LocalReport.DisplayName = "MENSAJERO PEDIDOS";
                rvPedidos.LocalReport.DataSources.Add(
                    new ReportDataSource("dsPedidos", loPedidos));
                rvPedidos.ShowToolBar = false;
                rvPedidos.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                this.Enabled = true;
            }
        }

        public void ValidarFechas()
        {
            if (dtpFechaInicio.Value > dtpFechaFinal.Value)
            {
                MessageBox.Show("Error. La fecha inicial no puede ser mayor que la fecha final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                EnlazarDatos();
            }
        }

        public void ObtenerSucursales()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;

            try
            {
                Dapesa.Comun.Pedidos.Reglas.AppMensajero loMensajero = new Dapesa.Comun.Pedidos.Reglas.AppMensajero();
                DataTable loSucursales = loMensajero.ObtenerSucursales(((InicioSesion)this.MdiParent.Owner).Sesion, ((InicioSesion)this.MdiParent.Owner).Sesion.Usuario.Id);
                cbSucursal.DataSource = loSucursales;

                if (loSucursales.Rows[0]["SUC_PREDEFINIDA"].ToString() != string.Empty)
                {
                    cbSucursal.SelectedValue = int.Parse(loSucursales.Rows[0]["SUC_PREDEFINIDA"].ToString());
                }
                    
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                this.Enabled = true;
            }

        }
        #endregion

        #region Eventos

        private void Mensajero_Shown(object sender, EventArgs e)
        {
            ObtenerSucursales();
            ValidarFechas();
            this.WindowState = FormWindowState.Maximized;        
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            ValidarFechas();
        }

        private void timerActualizar_Tick(object sender, EventArgs e)
        {
            ValidarFechas();
        }

        #endregion



    }
}