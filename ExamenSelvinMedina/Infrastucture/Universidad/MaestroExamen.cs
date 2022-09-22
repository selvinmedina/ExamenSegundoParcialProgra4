using System.ComponentModel;

namespace ExamenSelvinMedina.Infrastucture.Universidad
{
    public partial class MaestroExamen
    {
        [DisplayName("Número de cuenta")]
        public int Ncuenta { get; set; }

        [DisplayName("Nombre Completo")]
        public string? NombreCompleto { get; set; }

        [DisplayName("Profesión")]
        public string? Profesion { get; set; }
        public string? Carrera { get; set; }
        public int? Edad { get; set; }
    }
}
