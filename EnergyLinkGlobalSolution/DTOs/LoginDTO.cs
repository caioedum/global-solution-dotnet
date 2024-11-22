using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyLinkGlobalSolution.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [Column("EMAIL_USUARIO")]
        [StringLength(100)]
        public required string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "A senha é obrigatória.")]
        [Column("SENHA_USUARIO")]
        [StringLength(100)]
        public required string Senha { get; set; } = string.Empty;
    }
}
