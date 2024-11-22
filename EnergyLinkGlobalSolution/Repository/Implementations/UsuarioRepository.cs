using EnergyLinkGlobalSolution.Data;
using EnergyLinkGlobalSolution.Models;
using EnergyLinkGlobalSolution.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnergyLinkGlobalSolution.Repository.Implementations
{
    public class UsuarioRepository : IUsuarioFactory
    {
        private readonly dbContext _context;

        public UsuarioRepository(dbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Create(int idUsuario)
        {
            
            var usuarioExistente = await _context.Usuarios.FindAsync(idUsuario);
            if (usuarioExistente != null)
            {
                throw new InvalidOperationException("Usuário já existe com o ID fornecido.");
            }

         
            var novoUsuario = new Usuario
            {
                IdUsuario = idUsuario,
                Nome = "Nome Padrão",
                Sobrenome = "Sobrenome",
                CPF = "2341241",
                Telefone = "41234124",
                Senha = "sasa",
                Email = "email@exemplo.com" 
            };

            await _context.Usuarios.AddAsync(novoUsuario);
            await _context.SaveChangesAsync();

            return novoUsuario;
        }
    }
}
