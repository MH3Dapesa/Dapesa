using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Dapesa.Credito.Pedidos.IU.MensajeroCXC
{
    public partial class MensajesPop : Form
    {
        public MensajesPop(bool loAuxiliarCliente, bool loMisPedidos, string lsTextoEncabezado, string lsContenido)
        {
            //loAuxiliarCliente indica si el cliente del pedido esta dentro de la cartera del auxiliar CXC.
            InitializeComponent();
            lblEncabezado.Text = lsTextoEncabezado;
            lblContenido.Text = (lsContenido.Length <= 47 ? lsContenido : lsContenido.Substring(0, 47));
            if(loAuxiliarCliente)
            {
                if (lsTextoEncabezado.Contains("NUEVO PEDIDO POR AUTORIZAR"))
                    this.lblContenido.ForeColor = Color.White;
                    this.lblEncabezado.ForeColor = Color.White;
                    this.tblContenido.BackColor = Color.Maroon;
                    
                if (lsTextoEncabezado.Contains("PEDIDO AUTORIZADO"))
                    this.tblContenido.BackColor = Color.DarkSeaGreen;
            }
            else
            {
                if(!loMisPedidos)
                    this.tblContenido.BackColor = Color.Yellow;
            }
            this.Opacity = 0;
        }

        #region Eventos
        private void MensajesPop_Shown(object sender, EventArgs e)
        {
            int loAlto = Screen.PrimaryScreen.Bounds.Height;
            int loAncho = Screen.PrimaryScreen.Bounds.Width;
            this.Location = new Point(loAncho - this.Width, loAlto - this.Height);
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timerActualizar_Tick(object sender, EventArgs e)
        {
            while (this.Opacity != 1)
            {
                this.Opacity += 0.00001;
            }

        }
        private void timerCerrar_Tick(object sender, EventArgs e)
        {
            if (lblEncabezado.Text.Contains("PEDIDO AUTORIZADO"))
            {
                this.Close();
            }
            else
            {
                timerCerrar.Stop();
            }
        }
        #endregion

        

    }
}
