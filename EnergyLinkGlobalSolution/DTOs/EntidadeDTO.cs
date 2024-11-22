using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyLinkGlobalSolution.DTOs
{
    public class EntidadeDTO
    {
        [Required(ErrorMessage = "O nome da entidade é obrigatório.")]
        [Column("NOME_ENTIDADE")]
        public required string NomeEntidade = string.Empty;
    }
}
