using EnergyLinkGlobalSolution.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnergyLinkGlobalSolution.DTOs
{ 
public class CadastroDTO
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [Column("NOME_USUARIO")]
    public required string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O sobrenome é obrigatório.")]
    [Column("SOBRENOME_USUARIO")]
    public required string Sobrenome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [Column("CPF_USUARIO")]
    public required string CPF { get; set; } = string.Empty;

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [Column("EMAIL_USUARIO")]
    public required string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [Column("SENHA_USUARIO")]
    public required string Senha { get; set; } = string.Empty;

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [Column("TELEFONE_USUARIO")]
    public required string Telefone { get; set; } = string.Empty;
    }
}