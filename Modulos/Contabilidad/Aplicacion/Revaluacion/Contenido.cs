using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Contabilidad.IU.Revaluacion
{
    public partial class Contenido : Form
    {
        private int lnQuedanPzasdeFacturaRestarCompra;
        private string lsConcatenarOrnesComprasConFactura;
        private string lsConcatenarFechaOrdenCompraConFactura;
        private string lsConcatenarCostoOrdenCompraConFactura;
        private string lsConcatenarPzasOrdenCompraAFacuta;
        private string[] loSplitConcatenarOrnesComprasConFactura;
        private int lncontadorRenglonesMax = 1;
        private int lnContadorArchivosCSV = 1;
        private DataTable poINPC;

        public Contenido()
        {
            InitializeComponent();
        }

        #region Eventos

        private void btnInicarRevaluacion_Click(object sender, EventArgs e)
        {
            Revaluacion();
        }

        private void btnCargarArticulos_Click(object sender, EventArgs e)
        {
            CargarArticulos();
        }

        #endregion

        #region Metodos
        private void Revaluacion()
        {
            //Se crea un DataTabla para almacenar las piezas restantes por surtir de una salida, cuando no existe piezas disponibles para entregar.
            DataTable loSalidasPiezasRestantes = new DataTable("PiezasRestantes");
            loSalidasPiezasRestantes.Columns.Add("ID", typeof(int));
            loSalidasPiezasRestantes.Columns.Add("NUM_MOVTO_ALMACEN", typeof(string));
            loSalidasPiezasRestantes.Columns.Add("TIPO_MOVTO", typeof(string));
            loSalidasPiezasRestantes.Columns.Add("ART_CLAVE", typeof(string));
            loSalidasPiezasRestantes.Columns.Add("PZAS_RESTANTES", typeof(int));
            loSalidasPiezasRestantes.Columns.Add("FECHA_SALIDA", typeof(DateTime));

            DataRow loFilaSalidasPiezasRestantes;
            // Se crear DataTable para almacenar las salidas conformadas por entradas.
            DataTable loRevaluacion = new DataTable("Revaluacion");
            loRevaluacion.Columns.Add("ID", typeof(string));
            loRevaluacion.Columns.Add("NUM_MOVTO_ALMACEN", typeof(string));
            loRevaluacion.Columns.Add("TIPO_MOVTO", typeof(string));
            loRevaluacion.Columns.Add("ART_CLAVE", typeof(string));
            loRevaluacion.Columns.Add("REF_COMPRA", typeof(string));
            loRevaluacion.Columns.Add("FECHA_ENTRADA", typeof(DateTime));
            loRevaluacion.Columns.Add("COSTO_COMPRA", typeof(string));
            loRevaluacion.Columns.Add("REF_CON_PZAS", typeof(string));
            loRevaluacion.Columns.Add("FECHA_SALIDA", typeof(DateTime));
            loRevaluacion.Columns.Add("INPC_ENTRADA", typeof(string));
            loRevaluacion.Columns.Add("INPC_SALIDA", typeof(string));
            DataRow loFilaRevaluacion;

            int lnEsNull = 0;

            pbProgreso.Minimum = 0;
            pbProgreso.Maximum = gvContenido.Rows.Count;////(gvContenido.Rows.Count - 1)
            int loTotal = gvContenido.Rows.Count;
            for (int pnCiclo = 0; pnCiclo <= (gvContenido.Rows.Count - 1); pnCiclo++) // Primer Ciclo Recorrer todos los articulos cargados en el gridview.
            {
                gvContenido.Rows[pnCiclo].Selected = true;
                gvContenido.CurrentCell = gvContenido.Rows[pnCiclo].Cells[0];
                gvContenido.Refresh();
                pbProgreso.Value = pnCiclo + 1;
                lblContadorArticulo.Text = (pnCiclo + 1) + " / " + loTotal;
                lblContadorArticulo.Refresh();
                Reglas.Revaluar loObtener = new Reglas.Revaluar();
                DataTable loArticulos = loObtener.ObtenerAgrupadoArticulo(((InicioSesion)this.MdiParent.Owner).Sesion, gvContenido.Rows[pnCiclo].Cells[0].Value.ToString());
               
                //////string a =loArticulos.Rows[0]["FECHA_MOV_ALMACEN"].ToString().Substring(0,10);
                //limpiar columnas de revaluacion
                for (int pnLimpiarColumnas = 0; pnLimpiarColumnas < loArticulos.Rows.Count; pnLimpiarColumnas++)
                {
                    loArticulos.Rows[pnLimpiarColumnas]["REF_COMPRA"] = DBNull.Value;
                        loArticulos.Rows[pnLimpiarColumnas]["FECHA_COMPRA"] = DBNull.Value;
                        loArticulos.Rows[pnLimpiarColumnas]["COSTO_COMPRA"] = DBNull.Value;
                        loArticulos.Rows[pnLimpiarColumnas]["CONTEO"] = DBNull.Value;
                        loArticulos.Rows[pnLimpiarColumnas]["REFERENCIA_CON_PZAS"] = DBNull.Value;
                }
                for (int pnCiclo1 = 0; pnCiclo1 < loArticulos.Rows.Count; pnCiclo1++) // Segundo Ciclo recorer todos los movimientos por articulos ordenados por fecha de movimiento almacen
                {
                    lblContadorRevaluacionArticulo.Text = (pnCiclo1 + 1) + " / " + loArticulos.Rows.Count;
                    lblContadorRevaluacionArticulo.Refresh();
                    pbRevaluacion.Minimum = 0;
                    pbRevaluacion.Maximum = loArticulos.Rows.Count;
                    pbRevaluacion.Value = pnCiclo1 + 1;

                    if (loArticulos.Rows[pnCiclo1]["TIPO_MOVTO"].ToString() == "E" && loArticulos.Rows[pnCiclo1]["NUM_MOVTO_ALM_DEV"].ToString() == string.Empty)
                    {
                        //SI ES ENTRADA 
                        loArticulos.Rows[pnCiclo1]["REF_COMPRA"] = loArticulos.Rows[pnCiclo1]["NUM_MOVTO_ALMACEN"].ToString();
                        loArticulos.Rows[pnCiclo1]["FECHA_COMPRA"] = loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString().Substring(0, 10); // se agrego .Substring(0,10)
                        loArticulos.Rows[pnCiclo1]["COSTO_COMPRA"] = loArticulos.Rows[pnCiclo1]["ULT_COSTO"].ToString();
                        loArticulos.Rows[pnCiclo1]["CONTEO"] = loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString();



                    }
                    else if (loArticulos.Rows[pnCiclo1]["TIPO_MOVTO"].ToString() == "S")
                    {
                        //if (loArticulos.Rows[pnCiclo1]["id"].ToString() == "17525226")
                        //{
                        //    MessageBox.Show("11518652", "alert", MessageBoxButtons.OK);
                        //}
                        lnQuedanPzasdeFacturaRestarCompra = 0;

                        for (int pnCiclo2 = 0; pnCiclo2 < loArticulos.Rows.Count; pnCiclo2++) // Segundo Ciclo recorer todos los movimientos por articulos ordenados por fecha de movimiento almacen
                        {   //EN EL SIGUIENTE IF SE AGREGO UN TRYPARSE POR QUE SE RECORREN VALORES NULL QUE NO PUEDEN SER CONVERTIDOS A CERO.
                            lnEsNull = 0;
                            if (loArticulos.Rows[pnCiclo2]["TIPO_MOVTO"].ToString() == "E" && loArticulos.Rows[pnCiclo2]["NUM_MOVTO_ALM_DEV"].ToString() == string.Empty && ((int.TryParse(loArticulos.Rows[pnCiclo2]["CONTEO"].ToString(), out lnEsNull)) ? lnEsNull : 0) > 0)
                            {
                                if (int.Parse(loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString()) > int.Parse(loArticulos.Rows[pnCiclo2]["CONTEO"].ToString()))
                                {
                                    lsConcatenarPzasOrdenCompraAFacuta = lsConcatenarPzasOrdenCompraAFacuta + loArticulos.Rows[pnCiclo2]["NUM_MOVTO_ALMACEN"].ToString() + "/" + loArticulos.Rows[pnCiclo2]["CONTEO"].ToString() + ",";
                                    lsConcatenarOrnesComprasConFactura = lsConcatenarOrnesComprasConFactura + loArticulos.Rows[pnCiclo2]["NUM_MOVTO_ALMACEN"].ToString() + ",";
                                    lsConcatenarFechaOrdenCompraConFactura = lsConcatenarFechaOrdenCompraConFactura + loArticulos.Rows[pnCiclo2]["NUM_MOVTO_ALMACEN"].ToString() + "/" + loArticulos.Rows[pnCiclo2]["FECHA_MOV_ALMACEN"].ToString().Substring(0, 10) + ","; // se agrego .Substring(0,10)
                                    lsConcatenarCostoOrdenCompraConFactura = lsConcatenarCostoOrdenCompraConFactura + loArticulos.Rows[pnCiclo2]["NUM_MOVTO_ALMACEN"].ToString() + "/" + loArticulos.Rows[pnCiclo2]["ULT_COSTO"].ToString() + ",";
                                    lnQuedanPzasdeFacturaRestarCompra = int.Parse(loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString()) - int.Parse(loArticulos.Rows[pnCiclo2]["CONTEO"].ToString());
                                    

                                    ///////////COLOCAR TABLA DE SALIDA
                                    //////////////////////////

                                    loFilaRevaluacion = loRevaluacion.NewRow();
                                    loFilaRevaluacion["ID"] = loArticulos.Rows[pnCiclo1]["ID"].ToString();
                                    loFilaRevaluacion["NUM_MOVTO_ALMACEN"] = loArticulos.Rows[pnCiclo1]["NUM_MOVTO_ALMACEN"].ToString();
                                    loFilaRevaluacion["TIPO_MOVTO"] = loArticulos.Rows[pnCiclo1]["TIPO_MOVTO"].ToString();
                                    loFilaRevaluacion["ART_CLAVE"] = loArticulos.Rows[pnCiclo1]["ART_CLAVE"].ToString();
                                    loFilaRevaluacion["REF_COMPRA"] = loArticulos.Rows[pnCiclo2]["NUM_MOVTO_ALMACEN"].ToString();
                                    loFilaRevaluacion["FECHA_ENTRADA"] = DateTime.Parse(loArticulos.Rows[pnCiclo2]["FECHA_MOV_ALMACEN"].ToString());
                                    loFilaRevaluacion["COSTO_COMPRA"] = loArticulos.Rows[pnCiclo2]["ULT_COSTO"].ToString();
                                    loFilaRevaluacion["REF_CON_PZAS"] = int.Parse(loArticulos.Rows[pnCiclo2]["CONTEO"].ToString());

                                    loFilaRevaluacion["FECHA_SALIDA"] = DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString());

                                    for (int ln_j = 0; ln_j < poINPC.Rows.Count; ln_j++)
                                    {
                                        if (DateTime.Parse(loArticulos.Rows[pnCiclo2]["FECHA_MOV_ALMACEN"].ToString()).Month == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Month
                                            && DateTime.Parse(loArticulos.Rows[pnCiclo2]["FECHA_MOV_ALMACEN"].ToString()).Year == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Year)
                                        {
                                            loFilaRevaluacion["INPC_ENTRADA"] = poINPC.Rows[ln_j]["INPC"].ToString();
                                        }
                                        if (DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString()).Month == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Month
                                            && DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString()).Year == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Year)
                                        {
                                            loFilaRevaluacion["INPC_SALIDA"] = poINPC.Rows[ln_j]["INPC"].ToString();
                                        }
                                    }


                                    loRevaluacion.Rows.Add(loFilaRevaluacion);

                                    /////////////////////////////

                                    loArticulos.Rows[pnCiclo2]["CONTEO"] = "0";

                                    for (int pnCiclo3 = 0; pnCiclo3 < loArticulos.Rows.Count; pnCiclo3++) /////////////////////////////////////
                                    {  // SE AGREGO UN TRYPARSE POR QUE NO SE PUEDE CONVERTI NULL A CERO int.Parse(loArticulos.Rows[pnCiclo3]["CONTEO"].ToString())
                                        lnEsNull = 0;
                                        if (loArticulos.Rows[pnCiclo3]["TIPO_MOVTO"].ToString() == "E" && loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALM_DEV"].ToString() == string.Empty && ((int.TryParse(loArticulos.Rows[pnCiclo3]["CONTEO"].ToString(), out lnEsNull)) ? lnEsNull : 0) > 0)
                                        {
                                            if (lnQuedanPzasdeFacturaRestarCompra > int.Parse(loArticulos.Rows[pnCiclo3]["CONTEO"].ToString()))
                                            {
                                                lsConcatenarPzasOrdenCompraAFacuta = lsConcatenarPzasOrdenCompraAFacuta + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() + "/" + loArticulos.Rows[pnCiclo3]["CONTEO"].ToString() + ",";
                                                //loArticulos.Rows[pnCiclo3]["CONTEO"] = "0";

                                                lsConcatenarOrnesComprasConFactura = lsConcatenarOrnesComprasConFactura + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() + ",";
                                                lsConcatenarFechaOrdenCompraConFactura = lsConcatenarFechaOrdenCompraConFactura + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() + "/" + loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString().Substring(0, 10) + ","; // se agrego .Substring(0,10)
                                                lsConcatenarCostoOrdenCompraConFactura = lsConcatenarCostoOrdenCompraConFactura + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() + "/" + loArticulos.Rows[pnCiclo3]["ULT_COSTO"].ToString() + ",";
                                                lnQuedanPzasdeFacturaRestarCompra = lnQuedanPzasdeFacturaRestarCompra - int.Parse(loArticulos.Rows[pnCiclo3]["CONTEO"].ToString());
                                                

                                                //////////////////////////

                                                loFilaRevaluacion = loRevaluacion.NewRow();
                                                loFilaRevaluacion["ID"] = loArticulos.Rows[pnCiclo1]["ID"].ToString();
                                                loFilaRevaluacion["NUM_MOVTO_ALMACEN"] = loArticulos.Rows[pnCiclo1]["NUM_MOVTO_ALMACEN"].ToString();
                                                loFilaRevaluacion["TIPO_MOVTO"] = loArticulos.Rows[pnCiclo1]["TIPO_MOVTO"].ToString();
                                                loFilaRevaluacion["ART_CLAVE"] = loArticulos.Rows[pnCiclo1]["ART_CLAVE"].ToString();
                                                loFilaRevaluacion["REF_COMPRA"] = loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString();
                                                loFilaRevaluacion["FECHA_ENTRADA"] = DateTime.Parse(loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString());
                                                loFilaRevaluacion["COSTO_COMPRA"] = loArticulos.Rows[pnCiclo3]["ULT_COSTO"].ToString();
                                                loFilaRevaluacion["REF_CON_PZAS"] = int.Parse(loArticulos.Rows[pnCiclo3]["CONTEO"].ToString());


                                                loFilaRevaluacion["FECHA_SALIDA"] = DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString());

                                                for (int ln_j = 0; ln_j < poINPC.Rows.Count; ln_j++)
                                                {
                                                    if (DateTime.Parse(loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString()).Month == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Month
                                                        && DateTime.Parse(loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString()).Year == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Year)
                                                    {
                                                        loFilaRevaluacion["INPC_ENTRADA"] = poINPC.Rows[ln_j]["INPC"].ToString();
                                                    }
                                                    if (DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString()).Month == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Month
                                                        && DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString()).Year == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Year)
                                                    {
                                                        loFilaRevaluacion["INPC_SALIDA"] = poINPC.Rows[ln_j]["INPC"].ToString();
                                                    }
                                                }

                                                loRevaluacion.Rows.Add(loFilaRevaluacion);

                                                /////////////////////////////

                                                loArticulos.Rows[pnCiclo3]["CONTEO"] = "0";

                                            }
                                            else
                                            {
                                                loArticulos.Rows[pnCiclo1]["REFERENCIA_CON_PZAS"] = lsConcatenarPzasOrdenCompraAFacuta + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() + "/" + lnQuedanPzasdeFacturaRestarCompra;
                                                loArticulos.Rows[pnCiclo1]["REF_COMPRA"] = lsConcatenarOrnesComprasConFactura + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString();
                                                loArticulos.Rows[pnCiclo1]["FECHA_COMPRA"] = lsConcatenarFechaOrdenCompraConFactura + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() + "/" + loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString().Substring(0, 10); // se agrego .Substring(0,10)
                                                loArticulos.Rows[pnCiclo1]["COSTO_COMPRA"] = lsConcatenarCostoOrdenCompraConFactura + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() + "/" + loArticulos.Rows[pnCiclo3]["ULT_COSTO"].ToString();
                                                loArticulos.Rows[pnCiclo3]["CONTEO"] = int.Parse(loArticulos.Rows[pnCiclo3]["CONTEO"].ToString()) - lnQuedanPzasdeFacturaRestarCompra;
                                                loArticulos.Rows[pnCiclo1]["CONTEO"] = loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString();

                                                /////////////////////////

                                                loFilaRevaluacion = loRevaluacion.NewRow();
                                                loFilaRevaluacion["ID"] = loArticulos.Rows[pnCiclo1]["ID"].ToString();
                                                loFilaRevaluacion["NUM_MOVTO_ALMACEN"] = loArticulos.Rows[pnCiclo1]["NUM_MOVTO_ALMACEN"].ToString();
                                                loFilaRevaluacion["TIPO_MOVTO"] = loArticulos.Rows[pnCiclo1]["TIPO_MOVTO"].ToString();
                                                loFilaRevaluacion["ART_CLAVE"] = loArticulos.Rows[pnCiclo1]["ART_CLAVE"].ToString();
                                                loFilaRevaluacion["REF_COMPRA"] = loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString();
                                                loFilaRevaluacion["FECHA_ENTRADA"] = DateTime.Parse(loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString());
                                                loFilaRevaluacion["COSTO_COMPRA"] = loArticulos.Rows[pnCiclo3]["ULT_COSTO"].ToString();
                                                loFilaRevaluacion["REF_CON_PZAS"] = lnQuedanPzasdeFacturaRestarCompra;

                                                loFilaRevaluacion["FECHA_SALIDA"] = DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString());

                                                for (int ln_j = 0; ln_j < poINPC.Rows.Count; ln_j++)
                                                {
                                                    if (DateTime.Parse(loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString()).Month == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Month
                                                        && DateTime.Parse(loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString()).Year == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Year)
                                                    {
                                                        loFilaRevaluacion["INPC_ENTRADA"] = poINPC.Rows[ln_j]["INPC"].ToString();
                                                    }
                                                    if (DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString()).Month == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Month
                                                        && DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString()).Year == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Year)
                                                    {
                                                        loFilaRevaluacion["INPC_SALIDA"] = poINPC.Rows[ln_j]["INPC"].ToString();
                                                    }
                                                }
                                                
                                                loRevaluacion.Rows.Add(loFilaRevaluacion);


                                                /////////////////////////////

                                                lsConcatenarPzasOrdenCompraAFacuta = "";
                                                lsConcatenarOrnesComprasConFactura = "";
                                                lsConcatenarFechaOrdenCompraConFactura = "";
                                                lsConcatenarCostoOrdenCompraConFactura = "";
                                                lnQuedanPzasdeFacturaRestarCompra = 0;
                                                break; //Exit For
                                            }
                                        }
                                        //continue;
                                    }
                                    break; // salir
                                }
                                else
                                {
                                    loArticulos.Rows[pnCiclo1]["REFERENCIA_CON_PZAS"] = loArticulos.Rows[pnCiclo2]["NUM_MOVTO_ALMACEN"].ToString() + "/" + loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString();
                                    loArticulos.Rows[pnCiclo2]["CONTEO"] = int.Parse(loArticulos.Rows[pnCiclo2]["CONTEO"].ToString()) - int.Parse(loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString());
                                    loArticulos.Rows[pnCiclo1]["REF_COMPRA"] = loArticulos.Rows[pnCiclo2]["NUM_MOVTO_ALMACEN"].ToString();
                                    loArticulos.Rows[pnCiclo1]["FECHA_COMPRA"] = loArticulos.Rows[pnCiclo2]["FECHA_MOV_ALMACEN"].ToString().Substring(0, 10); // se agrego .Substring(0,10)
                                    loArticulos.Rows[pnCiclo1]["COSTO_COMPRA"] = loArticulos.Rows[pnCiclo2]["ULT_COSTO"].ToString();
                                    loArticulos.Rows[pnCiclo1]["CONTEO"] = loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString();



                                    //////////////////////////

                                    loFilaRevaluacion = loRevaluacion.NewRow();
                                    loFilaRevaluacion["ID"] = loArticulos.Rows[pnCiclo1]["ID"].ToString();
                                    loFilaRevaluacion["NUM_MOVTO_ALMACEN"] = loArticulos.Rows[pnCiclo1]["NUM_MOVTO_ALMACEN"].ToString();
                                    loFilaRevaluacion["TIPO_MOVTO"] = loArticulos.Rows[pnCiclo1]["TIPO_MOVTO"].ToString();
                                    loFilaRevaluacion["ART_CLAVE"] = loArticulos.Rows[pnCiclo1]["ART_CLAVE"].ToString();
                                    loFilaRevaluacion["REF_COMPRA"] = loArticulos.Rows[pnCiclo2]["NUM_MOVTO_ALMACEN"].ToString();
                                    loFilaRevaluacion["FECHA_ENTRADA"] = DateTime.Parse(loArticulos.Rows[pnCiclo2]["FECHA_MOV_ALMACEN"].ToString());
                                    loFilaRevaluacion["COSTO_COMPRA"] = loArticulos.Rows[pnCiclo2]["ULT_COSTO"].ToString();
                                    loFilaRevaluacion["REF_CON_PZAS"] = loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString();


                                    loFilaRevaluacion["FECHA_SALIDA"] = DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString());
        
                                    for (int ln_j = 0; ln_j < poINPC.Rows.Count; ln_j++)
                                    {
                                        if (DateTime.Parse(loArticulos.Rows[pnCiclo2]["FECHA_MOV_ALMACEN"].ToString()).Month == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Month
                                            && DateTime.Parse(loArticulos.Rows[pnCiclo2]["FECHA_MOV_ALMACEN"].ToString()).Year == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Year)
                                        {
                                            loFilaRevaluacion["INPC_ENTRADA"] = poINPC.Rows[ln_j]["INPC"].ToString();
                                        }
                                        if (DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString()).Month == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Month
                                            && DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString()).Year == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Year)
                                        {
                                            loFilaRevaluacion["INPC_SALIDA"] = poINPC.Rows[ln_j]["INPC"].ToString();
                                        }
                                    }
                                    
                                    loRevaluacion.Rows.Add(loFilaRevaluacion);

                                    /////////////////////////////


                                    lsConcatenarPzasOrdenCompraAFacuta = "";
                                    lsConcatenarOrnesComprasConFactura = "";
                                    lsConcatenarFechaOrdenCompraConFactura = "";
                                    lsConcatenarCostoOrdenCompraConFactura = "";
                                    lnQuedanPzasdeFacturaRestarCompra = 0;
                                    break;
                                }
                            }
                            if (pnCiclo2 == loArticulos.Rows.Count - 1 && lnQuedanPzasdeFacturaRestarCompra == 0 && string.IsNullOrEmpty(loArticulos.Rows[pnCiclo1]["CONTEO"].ToString()))
                            {
                                lnQuedanPzasdeFacturaRestarCompra = int.Parse(loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString());
                            }
                        }
                    }
                    else if (loArticulos.Rows[pnCiclo1]["TIPO_MOVTO"].ToString() == "E" && loArticulos.Rows[pnCiclo1]["NUM_MOVTO_ALM_DEV"].ToString() != string.Empty)
                    {
                        if ("17525336" == loArticulos.Rows[pnCiclo1]["ID"].ToString())
                        {
                            
                        }
                        for (int pnCiclo2 = 0; pnCiclo2 < loArticulos.Rows.Count; pnCiclo2++) // Segundo Ciclo recorer todos los movimientos por articulos ordenados por fecha de movimiento almacen
                        {
                            if (loArticulos.Rows[pnCiclo2]["TIPO_MOVTO"].ToString() == "S" && loArticulos.Rows[pnCiclo1]["NUM_MOVTO_ALM_DEV"].ToString() == loArticulos.Rows[pnCiclo2]["NUM_MOVTO_ALMACEN"].ToString())
                            {
                                loSplitConcatenarOrnesComprasConFactura = loArticulos.Rows[pnCiclo2]["REF_COMPRA"].ToString().Split(new Char[] { ',' });
                                for (int lnContadorOrdesCompraEnVenta = 0; lnContadorOrdesCompraEnVenta < loSplitConcatenarOrnesComprasConFactura.Length; lnContadorOrdesCompraEnVenta++)
                                {
                                    for (int pnCiclo3 = 0; pnCiclo3 < loArticulos.Rows.Count; pnCiclo3++)
                                    {
                                        if (loArticulos.Rows[pnCiclo3]["TIPO_MOVTO"].ToString() == "E" && loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALM_DEV"].ToString() == string.Empty && loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() == loSplitConcatenarOrnesComprasConFactura[lnContadorOrdesCompraEnVenta])
                                        {
                                            if ((int.Parse(loArticulos.Rows[pnCiclo3]["CANTIDAD"].ToString()) - int.Parse(loArticulos.Rows[pnCiclo3]["CONTEO"].ToString())) >= (int.Parse(loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString())) - lnQuedanPzasdeFacturaRestarCompra)
                                            {
                                               

                                                loArticulos.Rows[pnCiclo1]["REFERENCIA_CON_PZAS"] = lsConcatenarPzasOrdenCompraAFacuta + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() + "/" + (int.Parse(loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString()) - lnQuedanPzasdeFacturaRestarCompra);
                                                loArticulos.Rows[pnCiclo3]["CONTEO"] = int.Parse(loArticulos.Rows[pnCiclo3]["CONTEO"].ToString()) + (int.Parse(loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString()) - lnQuedanPzasdeFacturaRestarCompra);
                                                loArticulos.Rows[pnCiclo1]["REF_COMPRA"] = lsConcatenarOrnesComprasConFactura + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString();
                                                loArticulos.Rows[pnCiclo1]["FECHA_COMPRA"] = lsConcatenarFechaOrdenCompraConFactura + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() + "/" + loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString().Substring(0, 10);  // se agrego .Substring(0,10)
                                                loArticulos.Rows[pnCiclo1]["COSTO_COMPRA"] = lsConcatenarCostoOrdenCompraConFactura + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() + "/" + loArticulos.Rows[pnCiclo3]["ULT_COSTO"].ToString();
                                                loArticulos.Rows[pnCiclo1]["CONTEO"] = lnQuedanPzasdeFacturaRestarCompra + (int.Parse(loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString()) - lnQuedanPzasdeFacturaRestarCompra);


                                                 
                                                /////////////////////////

                                                loFilaRevaluacion = loRevaluacion.NewRow();
                                                loFilaRevaluacion["ID"] = loArticulos.Rows[pnCiclo1]["ID"].ToString();
                                                loFilaRevaluacion["NUM_MOVTO_ALMACEN"] = loArticulos.Rows[pnCiclo1]["NUM_MOVTO_ALMACEN"].ToString();
                                                loFilaRevaluacion["TIPO_MOVTO"] = loArticulos.Rows[pnCiclo1]["TIPO_MOVTO"].ToString();
                                                loFilaRevaluacion["ART_CLAVE"] = loArticulos.Rows[pnCiclo1]["ART_CLAVE"].ToString();
                                                loFilaRevaluacion["REF_COMPRA"] = loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString();
                                                loFilaRevaluacion["FECHA_ENTRADA"] = DateTime.Parse(loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString());
                                                loFilaRevaluacion["COSTO_COMPRA"] = loArticulos.Rows[pnCiclo3]["ULT_COSTO"].ToString();
                                                loFilaRevaluacion["REF_CON_PZAS"] = (int.Parse(loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString()) - lnQuedanPzasdeFacturaRestarCompra);


                                                loFilaRevaluacion["FECHA_SALIDA"] =  DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString());

                                                for (int ln_j = 0; ln_j < poINPC.Rows.Count; ln_j++)
                                                {
                                                    if (DateTime.Parse(loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString()).Month == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Month
                                                        && DateTime.Parse(loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString()).Year == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Year)
                                                    {
                                                        loFilaRevaluacion["INPC_ENTRADA"] =poINPC.Rows[ln_j]["INPC"].ToString();
                                                    }
                                                    if (DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString()).Month == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Month
                                                        && DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString()).Year == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Year)
                                                    {
                                                        loFilaRevaluacion["INPC_SALIDA"] = poINPC.Rows[ln_j]["INPC"].ToString();
                                                    }
                                                }

                                                loRevaluacion.Rows.Add(loFilaRevaluacion);


                                                /////////////////////////////

                                                
                                                lsConcatenarPzasOrdenCompraAFacuta = "";
                                                lsConcatenarOrnesComprasConFactura = "";
                                                lsConcatenarFechaOrdenCompraConFactura = "";
                                                lsConcatenarCostoOrdenCompraConFactura = "";
                                                lnQuedanPzasdeFacturaRestarCompra = 0;
                                                break;
                                            }
                                            else
                                            {
          

                                                lnQuedanPzasdeFacturaRestarCompra = lnQuedanPzasdeFacturaRestarCompra + (int.Parse(loArticulos.Rows[pnCiclo3]["CANTIDAD"].ToString()) - int.Parse(loArticulos.Rows[pnCiclo3]["CONTEO"].ToString()));
                                                lsConcatenarPzasOrdenCompraAFacuta = lsConcatenarPzasOrdenCompraAFacuta + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() + "/" + (int.Parse(loArticulos.Rows[pnCiclo3]["CANTIDAD"].ToString()) - int.Parse(loArticulos.Rows[pnCiclo3]["CONTEO"].ToString())) + ",";
                                                lsConcatenarOrnesComprasConFactura = lsConcatenarOrnesComprasConFactura + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() + ",";
                                                lsConcatenarFechaOrdenCompraConFactura = lsConcatenarFechaOrdenCompraConFactura + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() + "/" + loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString().Substring(0, 10) + ","; ///se agrego .Substring(0,10)
                                                lsConcatenarCostoOrdenCompraConFactura = lsConcatenarCostoOrdenCompraConFactura + loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString() + "/" + loArticulos.Rows[pnCiclo3]["ULT_COSTO"].ToString() + ",";


                                                /////////////////////////

                                                loFilaRevaluacion = loRevaluacion.NewRow();
                                                loFilaRevaluacion["ID"] = loArticulos.Rows[pnCiclo1]["ID"].ToString();
                                                loFilaRevaluacion["NUM_MOVTO_ALMACEN"] = loArticulos.Rows[pnCiclo1]["NUM_MOVTO_ALMACEN"].ToString();
                                                loFilaRevaluacion["TIPO_MOVTO"] = loArticulos.Rows[pnCiclo1]["TIPO_MOVTO"].ToString();
                                                loFilaRevaluacion["ART_CLAVE"] = loArticulos.Rows[pnCiclo1]["ART_CLAVE"].ToString();
                                                loFilaRevaluacion["REF_COMPRA"] = loArticulos.Rows[pnCiclo3]["NUM_MOVTO_ALMACEN"].ToString();
                                                loFilaRevaluacion["FECHA_ENTRADA"] = DateTime.Parse(loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString());
                                                loFilaRevaluacion["COSTO_COMPRA"] = loArticulos.Rows[pnCiclo3]["ULT_COSTO"].ToString();
                                                loFilaRevaluacion["REF_CON_PZAS"] = (int.Parse(loArticulos.Rows[pnCiclo3]["CANTIDAD"].ToString()) - int.Parse(loArticulos.Rows[pnCiclo3]["CONTEO"].ToString()));


                                                loFilaRevaluacion["FECHA_SALIDA"] =  DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString());

                                                for (int ln_j = 0; ln_j < poINPC.Rows.Count; ln_j++)
                                                {
                                                    if (DateTime.Parse(loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString()).Month == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Month
                                                        && DateTime.Parse(loArticulos.Rows[pnCiclo3]["FECHA_MOV_ALMACEN"].ToString()).Year == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Year)
                                                    {
                                                        loFilaRevaluacion["INPC_ENTRADA"] =poINPC.Rows[ln_j]["INPC"].ToString();
                                                    }
                                                    if (DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString()).Month == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Month
                                                        && DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString()).Year == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Year)
                                                    {
                                                        loFilaRevaluacion["INPC_SALIDA"] = poINPC.Rows[ln_j]["INPC"].ToString();
                                                    }
                                                }

                                                loRevaluacion.Rows.Add(loFilaRevaluacion);

                                                loArticulos.Rows[pnCiclo3]["CONTEO"] = loArticulos.Rows[pnCiclo3]["CANTIDAD"].ToString();

                                                /////////////////////////////

                                            }
                                        }
                                    }
                                    if (loArticulos.Rows[pnCiclo1]["CONTEO"].ToString() == loArticulos.Rows[pnCiclo1]["CANTIDAD"].ToString())
                                    {
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }

                    if (lnQuedanPzasdeFacturaRestarCompra > 0 && loArticulos.Rows[pnCiclo1]["TIPO_MOVTO"].ToString() == "S")
                    {

                        loFilaSalidasPiezasRestantes = loSalidasPiezasRestantes.NewRow();
                        loFilaSalidasPiezasRestantes["ID"] = loArticulos.Rows[pnCiclo1]["ID"].ToString();
                        loFilaSalidasPiezasRestantes["NUM_MOVTO_ALMACEN"] = loArticulos.Rows[pnCiclo1]["NUM_MOVTO_ALMACEN"].ToString();
                        loFilaSalidasPiezasRestantes["TIPO_MOVTO"] = loArticulos.Rows[pnCiclo1]["TIPO_MOVTO"].ToString();
                        loFilaSalidasPiezasRestantes["ART_CLAVE"] = loArticulos.Rows[pnCiclo1]["ART_CLAVE"].ToString();
                        loFilaSalidasPiezasRestantes["PZAS_RESTANTES"] = lnQuedanPzasdeFacturaRestarCompra;
                        loFilaSalidasPiezasRestantes["FECHA_SALIDA"] = DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString());
                        loSalidasPiezasRestantes.Rows.Add(loFilaSalidasPiezasRestantes);
                    }

                    if (loArticulos.Rows[pnCiclo1]["TIPO_MOVTO"].ToString() == "E" && loSalidasPiezasRestantes.Rows.Count > 0)
                    {

                            for (int lnContadorPiezasRestantes = 0; lnContadorPiezasRestantes < loSalidasPiezasRestantes.Rows.Count; lnContadorPiezasRestantes++)
                            {
                                //////////////////////////
                                //if (int.Parse(loArticulos.Rows[pnCiclo1]["CONTEO"].ToString()) > 0)
                                //{


                                    loFilaRevaluacion = loRevaluacion.NewRow();
                                    loFilaRevaluacion["ID"] = loSalidasPiezasRestantes.Rows[lnContadorPiezasRestantes]["ID"].ToString();
                                    loFilaRevaluacion["NUM_MOVTO_ALMACEN"] = loSalidasPiezasRestantes.Rows[lnContadorPiezasRestantes]["NUM_MOVTO_ALMACEN"].ToString();
                                    loFilaRevaluacion["TIPO_MOVTO"] = loSalidasPiezasRestantes.Rows[lnContadorPiezasRestantes]["TIPO_MOVTO"].ToString();
                                    loFilaRevaluacion["ART_CLAVE"] = loSalidasPiezasRestantes.Rows[lnContadorPiezasRestantes]["ART_CLAVE"].ToString();
                                    loFilaRevaluacion["REF_COMPRA"] = loArticulos.Rows[pnCiclo1]["NUM_MOVTO_ALMACEN"].ToString();
                                    loFilaRevaluacion["FECHA_ENTRADA"] = DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString());
                                    loFilaRevaluacion["COSTO_COMPRA"] = loArticulos.Rows[pnCiclo1]["ULT_COSTO"].ToString();

                                    if (int.Parse(loArticulos.Rows[pnCiclo1]["CONTEO"].ToString()) > int.Parse(loSalidasPiezasRestantes.Rows[lnContadorPiezasRestantes]["PZAS_RESTANTES"].ToString()))
                                    {
                                        loFilaRevaluacion["REF_CON_PZAS"] = int.Parse(loArticulos.Rows[pnCiclo1]["CONTEO"].ToString()) - int.Parse(loSalidasPiezasRestantes.Rows[lnContadorPiezasRestantes]["PZAS_RESTANTES"].ToString());
                                        loSalidasPiezasRestantes.Rows[lnContadorPiezasRestantes]["PZAS_RESTANTES"] = 0;
                                        loArticulos.Rows[pnCiclo1]["CONTEO"] = int.Parse(loArticulos.Rows[pnCiclo1]["CONTEO"].ToString()) - int.Parse(loSalidasPiezasRestantes.Rows[lnContadorPiezasRestantes]["PZAS_RESTANTES"].ToString());
                                    }
                                    else
                                    {
                                        loFilaRevaluacion["REF_CON_PZAS"] = int.Parse(loArticulos.Rows[pnCiclo1]["CONTEO"].ToString());
                                        loSalidasPiezasRestantes.Rows[lnContadorPiezasRestantes]["PZAS_RESTANTES"] = int.Parse(loSalidasPiezasRestantes.Rows[lnContadorPiezasRestantes]["PZAS_RESTANTES"].ToString()) - int.Parse(loArticulos.Rows[pnCiclo1]["CONTEO"].ToString());
                                        loArticulos.Rows[pnCiclo1]["CONTEO"] = 0;
                                    }


                                    loFilaRevaluacion["FECHA_SALIDA"] = DateTime.Parse(loSalidasPiezasRestantes.Rows[lnContadorPiezasRestantes]["FECHA_SALIDA"].ToString());

                                    for (int ln_j = 0; ln_j < poINPC.Rows.Count; ln_j++)
                                    {
                                        if (DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString()).Month == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Month
                                            && DateTime.Parse(loArticulos.Rows[pnCiclo1]["FECHA_MOV_ALMACEN"].ToString()).Year == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Year)
                                        {
                                            loFilaRevaluacion["INPC_ENTRADA"] = poINPC.Rows[ln_j]["INPC"].ToString();
                                        }
                                        if (DateTime.Parse(loSalidasPiezasRestantes.Rows[lnContadorPiezasRestantes]["FECHA_SALIDA"].ToString()).Month == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Month
                                            && DateTime.Parse(loSalidasPiezasRestantes.Rows[lnContadorPiezasRestantes]["FECHA_SALIDA"].ToString()).Year == DateTime.Parse(poINPC.Rows[ln_j]["FECHA"].ToString()).Year)
                                        {
                                            loFilaRevaluacion["INPC_SALIDA"] = poINPC.Rows[ln_j]["INPC"].ToString();
                                        }
                                    }

                                    loRevaluacion.Rows.Add(loFilaRevaluacion);

                                //}
                                //else
                                //{
                                //    break;
                                //}
                                /////////////////////////////
                            }
                        

                    }
                    
                }

                //Reglas.Revaluar loRevaluacion = new Reglas.Revaluar();
                //loRevaluacion.ActualizarCompraVenta(((InicioSesion)this.MdiParent.Owner).Sesion, loArticulos);
                CargarTxt(loArticulos, loRevaluacion);
                tableLayoutPanel1.Refresh();
            }
            MessageBox.Show("¡PROCESO TERMINADO!", "RESPUESTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CargarArticulos()
        {
            try
            {
                lnQuedanPzasdeFacturaRestarCompra = 0;
                lsConcatenarOrnesComprasConFactura = "";
                lsConcatenarFechaOrdenCompraConFactura = "";
                lsConcatenarCostoOrdenCompraConFactura = "";
                lsConcatenarPzasOrdenCompraAFacuta = "";

                Reglas.Revaluar loObtener = new Reglas.Revaluar();
                gvContenido.DataSource = loObtener.Obtener(((InicioSesion)this.MdiParent.Owner).Sesion, 1);
                gvContenido.Refresh();

                poINPC = loObtener.ObtenerINPC();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Cursor.Current = Cursors.Default;
                //this.Enabled = true;
            }
        }

        private void CargarTxt(DataTable poArticulos, DataTable loRevaluacion)
        {
            try
            {
                poArticulos.Clear(); // SE LIMPIA TABLA PARA LIBERAR MEMORIA PERO SI SE REQUIERE SE ELIMINA LA LINEA.
                if (!Directory.Exists(ConfigurationManager.AppSettings["RutaArchivo"]))
                {
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["RutaArchivo"]);
                }

                if(lncontadorRenglonesMax >  1000000)
                {
                    lnContadorArchivosCSV = lnContadorArchivosCSV+1;
                    lncontadorRenglonesMax = 0;
                }
                StreamWriter loArchivo = File.AppendText(ConfigurationManager.AppSettings["RutaArchivo"] + @"\Articulos"+lnContadorArchivosCSV.ToString()+".csv");

                for (int lnFila = 0; lnFila < loRevaluacion.Rows.Count; lnFila++)
                {
                    //SI SE REQUIERE ANEXAR EN OTRAS COLUMNAS COMO SE COMPORTO LA COMPRA Y SALIDA.
                    //loArchivo.WriteLine(poArticulos.Rows[lnFila]["id"].ToString() + ";" + poArticulos.Rows[lnFila]["NUMERO"].ToString() + ";" + poArticulos.Rows[lnFila]["ART_CLAVE"].ToString() + ";" + poArticulos.Rows[lnFila]["CONCEPTO_MOV_ALMACEN"].ToString() + ";" + poArticulos.Rows[lnFila]["TIPO_MOVTO"].ToString() + ";" + poArticulos.Rows[lnFila]["FECHA_MOV_ALMACEN"].ToString() + ";" + poArticulos.Rows[lnFila]["NUM_MOVTO_ALMACEN"].ToString() + ";" + poArticulos.Rows[lnFila]["CANTIDAD"].ToString() + ";" + poArticulos.Rows[lnFila]["ULT_COSTO"].ToString() + ";" + poArticulos.Rows[lnFila]["CLAVE_ALMACEN"].ToString() + ";" +
                    //    poArticulos.Rows[lnFila]["NUM_MOVTO_ALM_DEV"].ToString() + ";" + poArticulos.Rows[lnFila]["CXC"].ToString() + ";" + poArticulos.Rows[lnFila]["REF_COMPRA"].ToString() + ";" + poArticulos.Rows[lnFila]["FECHA_COMPRA"].ToString() + ";" + poArticulos.Rows[lnFila]["COSTO_COMPRA"].ToString() + ";" + poArticulos.Rows[lnFila]["CONTEO"].ToString() + ";" + poArticulos.Rows[lnFila]["REFERENCIA_CON_PZAS"].ToString());
                    //lncontadorRenglonesMax = lncontadorRenglonesMax + 1;

                    if (lncontadorRenglonesMax <= 1000000)
                    {
                        DateTime loFechaEntrada = DateTime.Parse(loRevaluacion.Rows[lnFila]["FECHA_ENTRADA"].ToString());
                        string lsFechaEntrada = loFechaEntrada.ToString("yyy/MM/dd HH:mm:ss");
                        DateTime loFechaSalida = DateTime.Parse(loRevaluacion.Rows[lnFila]["FECHA_SALIDA"].ToString());
                        string lsFechaSalida = loFechaSalida.ToString("yyy/MM/dd HH:mm:ss");
                        loArchivo.WriteLine(
                            loRevaluacion.Rows[lnFila]["ID"].ToString() + ";" +
                            loRevaluacion.Rows[lnFila]["NUM_MOVTO_ALMACEN"].ToString() + ";" +
                            loRevaluacion.Rows[lnFila]["TIPO_MOVTO"].ToString() + ";" +
                            loRevaluacion.Rows[lnFila]["ART_CLAVE"].ToString() + ";" +
                            loRevaluacion.Rows[lnFila]["REF_COMPRA"].ToString() + ";" +
                            lsFechaEntrada + ";" +
                            loRevaluacion.Rows[lnFila]["COSTO_COMPRA"].ToString() + ";" +
                            loRevaluacion.Rows[lnFila]["REF_CON_PZAS"].ToString() + ";" +
                            lsFechaSalida + ";" +
                            loRevaluacion.Rows[lnFila]["INPC_ENTRADA"].ToString() + ";" +
                            loRevaluacion.Rows[lnFila]["INPC_SALIDA"].ToString());
                        lncontadorRenglonesMax = lncontadorRenglonesMax + 1;
                    }
                    else 
                    {

                        loArchivo.Close();

                        //Reglas.Revaluar loEjecutarQuery = new Reglas.Revaluar();
                        //bool loRespuesta = loEjecutarQuery.Revaluacion(((InicioSesion)this.MdiParent.Owner).Sesion, (ConfigurationManager.AppSettings["RutaArchivo"] + @"\Articulos" + lnContadorArchivosCSV.ToString() + ".csv"));

                        //if (!loRespuesta)
                        //{
                        //    MessageBox.Show("Ocurrio un problema al Ejecutar el Archivo. <<" + (ConfigurationManager.AppSettings["RutaArchivo"] + @"\Articulos" + lnContadorArchivosCSV.ToString() + ".csv") + ">> ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        //else
                        //{
                        //    File.Delete((ConfigurationManager.AppSettings["RutaArchivo"] + @"\Articulos" + lnContadorArchivosCSV.ToString() + ".csv"));
                        //}

                        lnContadorArchivosCSV = lnContadorArchivosCSV + 1;
                        loArchivo = File.AppendText(ConfigurationManager.AppSettings["RutaArchivo"] + @"\Articulos" + lnContadorArchivosCSV.ToString() + ".csv");
                        lncontadorRenglonesMax = 0;


                        DateTime loFechaEntrada = DateTime.Parse(loRevaluacion.Rows[lnFila]["FECHA_ENTRADA"].ToString());
                        string lsFechaEntrada = loFechaEntrada.ToString("yyy/MM/dd HH:mm:ss");
                        DateTime loFechaSalida = DateTime.Parse(loRevaluacion.Rows[lnFila]["FECHA_SALIDA"].ToString());
                        string lsFechaSalida = loFechaSalida.ToString("yyy/MM/dd HH:mm:ss");
                        loArchivo.WriteLine(
                            loRevaluacion.Rows[lnFila]["ID"].ToString() + ";" +
                            loRevaluacion.Rows[lnFila]["NUM_MOVTO_ALMACEN"].ToString() + ";" +
                            loRevaluacion.Rows[lnFila]["TIPO_MOVTO"].ToString() + ";" +
                            loRevaluacion.Rows[lnFila]["ART_CLAVE"].ToString() + ";" +
                            loRevaluacion.Rows[lnFila]["REF_COMPRA"].ToString() + ";" +
                            lsFechaEntrada + ";" +
                            loRevaluacion.Rows[lnFila]["COSTO_COMPRA"].ToString() + ";" +
                            loRevaluacion.Rows[lnFila]["REF_CON_PZAS"].ToString() + ";" +
                            lsFechaSalida + ";" +
                            loRevaluacion.Rows[lnFila]["INPC_ENTRADA"].ToString() + ";" +
                            loRevaluacion.Rows[lnFila]["INPC_SALIDA"].ToString());
                        lncontadorRenglonesMax = lncontadorRenglonesMax + 1;
                    }

                    // colocar un if con el rango de un millon para que nose sobrepase la memoria.
                }

                loRevaluacion.Clear();
                loArchivo.Close();
                //loArchivo.Flush();
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnEjecutarTxt_Click(object sender, EventArgs e)
        {
            //int counter = 0;
            //string line;
            //Reglas.Revaluar loRevaluacion = new Reglas.Revaluar();

            //System.IO.StreamReader file =
            //    new System.IO.StreamReader(ConfigurationManager.AppSettings["RutaArchivo"] + @"\Articulos.txt");
            //while ((line = file.ReadLine()) != null)
            //{

            //    bool loRespuesta = loRevaluacion.ActualizarCompraVenta(((InicioSesion)this.MdiParent.Owner).Sesion, line);

            //    if (!loRespuesta)
            //    {
            //        MessageBox.Show(counter.ToString() + " -- " + line, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    counter++;
            //    lblContadorActualizacion.Text = counter.ToString();
            //    lblContadorActualizacion.Update();
            //}

            //file.Close();
            //GC.Collect();

        }

      

    }
}
