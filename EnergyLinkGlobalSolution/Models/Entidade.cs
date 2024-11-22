using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyLinkGlobalSolution.Models
{
    [Table("ENTIDADE_BASE")]
    public class Entidade
    {
        [Key]
        [Column("ID_ENTIDADE")]
        public int IdEntidade { get; set; }

        [Column("NOME_ENTIDADE")]
        public required string NomeEntidade = string.Empty;
    }
}
