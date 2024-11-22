using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyLinkGlobalSolution.Models
{
    [Table("MONITORAMENTO_ENERGIA")]
    public class Monitoramento
    {
        [Key]
        [Column("ID_MONITORAMENTO")]
        public int IdMonitoramento { get; set; }

        [Required]
        [ForeignKey("Entidade")]
        [Column("ID_ENTIDADE")]
        public int? IdEntidade { get; set; }

        public Entidade? Entidade { get; set; }

        [Column("DATA_MONITORAMENTO")]
        public required DateTime DataMonitoramento { get; set; } = DateTime.Now;

        [Column("ENERGIA")]
        public required int Energia { get; set; }

        [Column("TIPO_MONITORAMENTO")]
        public required string TipoMonitoramento { get; set; } = string.Empty;
    }
}
