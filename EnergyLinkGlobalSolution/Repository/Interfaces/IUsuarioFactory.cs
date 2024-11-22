using EnergyLinkGlobalSolution.Models;

namespace EnergyLinkGlobalSolution.Repository.Interfaces
{
    public interface IUsuarioFactory
    {

        Task<Usuario> Create(int IdUsuario);
        
    }
}
