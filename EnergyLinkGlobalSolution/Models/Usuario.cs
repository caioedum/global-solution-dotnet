using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyLinkGlobalSolution.Models
{
    [Table("USUARIO_ENERGYLINK")]
    public class Usuario
    {
        [Key]
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Column("NOME_USUARIO")]
        public required string Nome { get; set; } = string.Empty;

        [Column("SOBRENOME_USUARIO")]
        public required string Sobrenome { get; set; } = string.Empty;

        [Column("CPF_USUARIO")]
        public required string CPF {  get; set; } = string.Empty;

        [Column("EMAIL_USUARIO")]
        public required string Email { get; set; } = string.Empty;

        [Column("SENHA_USUARIO")]
        public required string Senha { get; set; } = string.Empty;

        [Column("TELEFONE_USUARIO")]
        public required string Telefone { get; set; } = string.Empty;
    }
}
