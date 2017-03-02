namespace Dapesa.Tesoreria.Bancos.Comun
{
    public class RegistroCobro
    {
        public string NumTransaccion { get; set; }
        public string RefNumerica { get; set; }
        public string RefAlfanumerica { get; set; }
        public decimal Abono { get; set; }
        public int FormaPago { get; set; }
        public int Banco { get; set; }
        public string Archivo { get; set; }
        public string FechaAbono { get; set; }
        public string SucBanco { get; set; }
        public string StatusTransaccion { get; set; }
    }
}
