using Dapesa.Comun.Utilerias;
using Dapesa.Informes.Comun;
using Dapesa.Seguridad.Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Web;

namespace Dapesa.Informes.Reglas
{
	internal class InformeWinForms : Informe, IInforme
	{
		#region Atributos

		private LocalReport _oInforme;

		#endregion

		#region Constructor

		internal InformeWinForms(Entidades.Informe poInforme, DataSet poFuenteDatos)
			: base(poInforme)
		{
			this._oInforme = new LocalReport();
			this._oInforme.ReportPath = poInforme.Ubicacion + poInforme.Nombre + "." + poInforme.Extension;

			foreach (DataTable oTabla in poFuenteDatos.Tables)
				this._oInforme.DataSources.Add(new ReportDataSource(oTabla.TableName, oTabla));
		}

		#endregion

		#region Metodos

		private Stream CargarEnMemoria(string psNombre, string psExtension, Encoding poCodificacion, string psMimeType, bool pbBuscar)
		{
			Stream loStream = new MemoryStream();

			base._oStream.Add(loStream);
			return loStream;
		}

		private void ImprimirPagina(object sender, PrintPageEventArgs e)
		{
			Metafile loPagina = new Metafile(base._oStream[base._nPagina]);
			Rectangle loRectangulo = new Rectangle(
				e.PageBounds.Left-(int)e.PageSettings.HardMarginX,
				e.PageBounds.Top-(int)e.PageSettings.HardMarginY,
				e.PageBounds.Width,
				e.PageBounds.Height
			);

			e.Graphics.FillRectangle(Brushes.White, loRectangulo);
			e.Graphics.DrawImage(loPagina, loRectangulo);
			base._nPagina++;
			e.HasMorePages = base._nPagina < base._oStream.Count;
		}

		protected override void Cargar()
		{
			Warning[] loAdvertencia;

			base._oStream = new List<Stream>();
			this._oInforme.Render(
				base._oFormato.Descripcion(),
				base._sConfiguracion,
				this.CargarEnMemoria,
				out loAdvertencia
			);

			foreach (Stream oStream in this._oStream)
				oStream.Position = 0;
		}

		protected override object Generar()
		{

			try
			{

			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
			finally
			{
				base.Dispose();
			}

			return null;
		}

		protected override void Imprimir()
		{

			try
			{
				this.Cargar();

				if (base._oStream == null || base._oStream.Count == 0)
					return;

				PrintDocument loImpresora = new PrintDocument();

				if (!string.IsNullOrEmpty(base._sImpresora))
					loImpresora.PrinterSettings.PrinterName = base._sImpresora;
				else
					loImpresora.PrinterSettings.PrinterName = ConfigurationManager.AppSettings[base._sNombre + ((Sesion)HttpContext.Current.Session["Sesion"]).Usuario.Sucursal[0].Clave];


				if (!loImpresora.PrinterSettings.IsValid)
					throw new Excepcion("Debe especificar una impresora válida.");
				else
				{

					foreach (PaperSize oPagina in loImpresora.PrinterSettings.PaperSizes)
					{
						if (oPagina.PaperName.ToLower() != base._sNombre.ToLower())
							continue;

						loImpresora.PrinterSettings.DefaultPageSettings.PaperSize = oPagina;
						loImpresora.PrinterSettings.DefaultPageSettings.Margins = new Margins((int)(10 * base._nMargenIzquierdo), (int)(10 * base._nMargenDerecho), (int)(10 * base._nMargenSuperior), (int)(10 * base._nMargenInferior));
						loImpresora.DefaultPageSettings.Margins = new Margins((int)(10 * base._nMargenIzquierdo), (int)(10 * base._nMargenDerecho), (int)(10 * base._nMargenSuperior), (int)(10 * base._nMargenInferior));
						loImpresora.DefaultPageSettings.PaperSize = oPagina;
						break;
					}

					base._nPagina = 0;
					loImpresora.PrinterSettings.Copies = (short)base._nCopias;
					loImpresora.DocumentName = base._sNombre;
					loImpresora.PrintPage += new PrintPageEventHandler(ImprimirPagina);
					loImpresora.Print();
				}
			}
			catch (ConfigurationException cex)
			{
				throw new Excepcion("Error al cargar la configuración de la impresora.", cex);
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
			finally
			{
				base.Dispose();
			}
		}

		public object Procesar()
		{

			switch (base._oSalida)
			{
				case Informes.Comun.Definiciones.TipoSalida.Archivo:
					return this.Generar();
				case Informes.Comun.Definiciones.TipoSalida.Impresion:
					this.Imprimir();
					break;
				default:
					break;
			}

			return null;
		}

		#endregion
	}
}
