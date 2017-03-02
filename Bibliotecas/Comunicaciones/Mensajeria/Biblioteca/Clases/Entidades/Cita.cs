using Microsoft.Office.Interop.Outlook;
using System;

namespace Dapesa.Comunicaciones.Mensajeria.Entidades
{
	public class Cita
	{
		#region Atributos

		private OlImportance _oPrioridad = OlImportance.olImportanceNormal;
		private bool _bRecordatorio = true;

		#endregion

		#region Propiedades

		public string Asunto { get; set; }
		public string Contenido { get; set; }
		public string Destinatario { get; set; }
		public bool EventoTodoDia { get; set; }
		public DateTime? Fin { get; set; }
		public bool Mensaje { get; set; }
		public bool Mostrar { get; set; }
		public OlImportance Prioridad
		{
			get
			{
				return this._oPrioridad;
			}
			set
			{
				this._oPrioridad = value;
			}
		}
		public DateTime? Inicio { get; set; }
		public bool Recordatorio 
		{ 
			get
			{
				return this._bRecordatorio;
			}
			set
			{
				this._bRecordatorio = value;
			}
		}
		public int RecordatorioMinutosAntesComienzo { get; set; }
		public string Ubicacion { get; set; }

		#endregion
	}
}
