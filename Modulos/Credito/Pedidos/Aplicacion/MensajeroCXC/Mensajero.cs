using Dapesa.Credito.Pedidos.Reglas;
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

namespace Dapesa.Credito.Pedidos.IU.MensajeroCXC
{
    public partial class Mensajero : Form
    {
        DateTime _loFechaInicio = DateTime.Now;
        DateTime _loFechaFin = DateTime.Now;
        int _lnSucursal = -1;
        Sesion _loSesion;
        public Mensajero(Sesion losesion, DateTime loFechaInicio, DateTime loFechaFin, int lnSucursal)
        {          
            InitializeComponent();
            _loFechaInicio = loFechaInicio;
            _loFechaFin = loFechaFin;
            _lnSucursal = lnSucursal;
            _loSesion = losesion;
        }

        #region Eventos

        private void Mensajero_Load(object sender, EventArgs e)
        {
            EnlazarDatos();
        }
        private void Mensajero_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Invalidate(true);
            this.Owner.Refresh();
            this.Owner.Update();
            this.Owner.Show();
        }
        private void timerActualizar_Tick(object sender, EventArgs e)
        {
            EnlazarDatos();
        }

        #endregion

        #region Métodos
        private void EnlazarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;

            try
            {
                Dapesa.Credito.Pedidos.Reglas.MensajeroCXC loMensajero = new Dapesa.Credito.Pedidos.Reglas.MensajeroCXC();
                DataTable loPedidos = loMensajero.ObtenerPedidos(_loSesion, _loFechaInicio, _loFechaFin, _lnSucursal);
                rvPedidos.Reset();

                rvPedidos.LocalReport.ReportPath = "Rdl/ResumenPedidos.rdl";
                rvPedidos.LocalReport.ReportEmbeddedResource = "Rdl/ResumenPedidos.rdl";
                rvPedidos.LocalReport.DisplayName = "MENSAJERO PEDIDOS";
                rvPedidos.LocalReport.DataSources.Add(
                    new ReportDataSource("dsPedidos", loPedidos));
                rvPedidos.ShowToolBar = false;
                //rvPedidos.AutoSize = true;
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
        #endregion
        
    }
}
