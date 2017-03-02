using Dapesa.Compras.OrdenCompra.Reglas;
using Dapesa.Compras.OrdenCompra.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dapesa.Compras.OrdenCompra.IU.EDI
{
    public partial class Contenido : Form
    {
        public Contenido()
        {
            InitializeComponent();
            toolTip.SetToolTip(btnConsultar, "Buscar ordenes de compra sin recepción");
            toolTip.SetToolTip(btnGenerar, "Generar archivo txt para las ordenes de compra");
        }
        private void Contenido_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnGenerar.Enabled = false;
            gvResultado.ReadOnly = true;
            this.ObtenerSucursal(cbSucursal, ((InicioSesion)this.MdiParent.Owner).Sesion.Usuario.Id.ToString());
            this.ObtenerProveedores(cbProveedor);
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.BuscarOrdenCompra(txtOrdenCompra.Text.ToUpper(), int.Parse(cbSucursal.SelectedValue.ToString()));
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int lnFila = gvResultado.GetCellCount(DataGridViewElementStates.Selected);
            DataGridViewRow loFila = this.gvResultado.Rows[lnFila-1];

            if (lnFila > 0)
            {
                if (loFila.Cells["PERSONAL"].Value.ToString() != string.Empty)
                {
                    this.GenerarOrdenCompra(loFila.Cells["FOLOC_FOLIO"].Value.ToString(), int.Parse(loFila.Cells["NUMERO"].Value.ToString()));
                }
                else
                {
                    MessageBox.Show("No existe un usuario asignado a la orden de compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        #region Metodos   
        private void ObtenerSucursal(ComboBox poCombo, string psClavePersonal)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CompraOrden loLayout = new CompraOrden();

                poCombo.DataSource = loLayout.ObtenerSucursal(
                    ((InicioSesion)this.MdiParent.Owner).Sesion, psClavePersonal
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ObtenerProveedores(ComboBox poCombo)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CompraOrden loLayout = new CompraOrden();

                poCombo.DataSource = loLayout.ObtenerProveedores(
                    ((InicioSesion)this.MdiParent.Owner).Sesion
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        protected void BuscarOrdenCompra(string psFolioOrdenCompra, int pnSucursal)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;

            try
            {
                CompraOrden loOrdenesCompra = new CompraOrden();

                DataTable loResultado = loOrdenesCompra.Obtener(((InicioSesion)this.MdiParent.Owner).Sesion, psFolioOrdenCompra, pnSucursal);
                gvResultado.DataSource = loResultado;

                btnGenerar.Enabled = false;
                if(loResultado.Rows.Count>0)
                {
                    btnGenerar.Enabled = true;
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

        protected void GenerarOrdenCompra(string psFolioOrdenCompra, int pnNumeroOrdenCompra)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;

            try
            {
                CompraOrden loOrdenesCompra = new CompraOrden();
                Marcas.Interfil loInterfil = new Marcas.Interfil();
                DataTable loResultado = loOrdenesCompra.ObtenerDatosOrdenCompra(((InicioSesion)this.MdiParent.Owner).Sesion, psFolioOrdenCompra,pnNumeroOrdenCompra, int.Parse(cbSucursal.SelectedValue.ToString()));
                
                if(loInterfil.Generartxt(loResultado, int.Parse(cbSucursal.SelectedValue.ToString())))
                {         
                    MessageBox.Show("Archivo creado con exito.", "Creación de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                }
                else
                {
                    MessageBox.Show("Hubo un error al generar el archivo.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);         
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


    }
}
