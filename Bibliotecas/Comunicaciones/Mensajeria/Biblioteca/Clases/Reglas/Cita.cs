using Microsoft.Office.Interop.Outlook;
using System;
using System.Runtime.InteropServices;

namespace Dapesa.Comunicaciones.Mensajeria.Reglas
{
	public abstract class Cita : IDisposable
	{
		#region Atributos

		protected readonly Application _oAplicacion;
		protected AppointmentItem _oCita;
		protected MailItem _oMensaje;
		protected readonly bool _bMostrar;

		#endregion

		#region Constructor

		protected Cita(Entidades.Cita poCita)
		{
			this._oAplicacion = new Application();
			this._oCita = (AppointmentItem)this._oAplicacion.CreateItem(OlItemType.olAppointmentItem);
			this._bMostrar = poCita.Mostrar;

			if (_oCita != null)
			{
				this._oCita.AllDayEvent = poCita.EventoTodoDia;
				this._oCita.Body = poCita.Contenido;
				this._oCita.Importance = poCita.Prioridad;
				this._oCita.ReminderSet = poCita.Recordatorio;
				this._oCita.Subject = poCita.Asunto;

				if (poCita.Inicio != null)
					this._oCita.Start = (DateTime)poCita.Inicio;

				if (poCita.Fin != null)
					this._oCita.End = (DateTime)poCita.Fin;
				
				if (poCita.Mensaje && !string.IsNullOrEmpty(poCita.Destinatario))
				{
					this._oMensaje = this._oCita.ForwardAsVcal();
					this._oMensaje.To = poCita.Destinatario;
				}

				if (poCita.Recordatorio)
					this._oCita.ReminderMinutesBeforeStart = poCita.RecordatorioMinutosAntesComienzo;

				if (poCita.Ubicacion != null)
					this._oCita.Location = poCita.Ubicacion;
			}
		}

		#endregion

		#region Metodos

		public void Dispose()
		{

			if (this._oMensaje != null) Marshal.ReleaseComObject(this._oMensaje);
			if (this._oCita != null) Marshal.ReleaseComObject(this._oCita);
			if (this._oAplicacion != null) Marshal.ReleaseComObject(this._oAplicacion);
		}

		#endregion
	}
}
