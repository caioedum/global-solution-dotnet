using EnergyLinkGlobalSolution.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnergyLinkGlobalSolution.DTOs
{
    public class MonitoramentoDTO
    {

        [Required]
        [ForeignKey("Entidade")]
        [Column("ID_ENTIDADE")]
        public int? IdEntidade { get; set; }

        public Entidade? Entidade { get; set; }

        [Required(ErrorMessage = "A data do monitoramento é obrigatório.")]
        [Column("DATA_MONITORAMENTO")]
        public required DateTime DataMonitoramento { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O valor da energia é obrigatório.")]
        [Column("ENERGIA")]
        public required int Energia { get; set; }

        [Required(ErrorMessage = "O tipo do monitoramento é obrigatório.")]
        [Column("TIPO_MONITORAMENTO")]
        public required string TipoMonitoramento { get; set; } = string.Empty;
    }
}
