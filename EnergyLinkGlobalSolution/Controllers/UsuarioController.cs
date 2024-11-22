using EnergyLinkGlobalSolution.Data;
using EnergyLinkGlobalSolution.Models;
using EnergyLinkGlobalSolution.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EnergyLinkGlobalSolution.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly dbContext _context;

        public UsuarioController(dbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CadastroDTO cadastroDTO)
        {
            if (ModelState.IsValid)
            {
                var usuarioExistente = _context.Usuarios
                    .FirstOrDefault(u => u.CPF == cadastroDTO.CPF || u.Email == cadastroDTO.Email || u.Telefone == cadastroDTO.Telefone);

                if (usuarioExistente != null)
                {
                    if (usuarioExistente.CPF == cadastroDTO.CPF)
                    {
                        ModelState.AddModelError("CPF", "Este CPF já está cadastrado.");
                    }

                    if (usuarioExistente.Email == cadastroDTO.Email)
                    {
                        ModelState.AddModelError("Email", "Este E-mail já está cadastrado.");
                    }

                    if (usuarioExistente.Telefone == cadastroDTO.Telefone)
                    {
                        ModelState.AddModelError("Telefone", "Este Telefone já está cadastrado.");
                    }

                    return View(cadastroDTO);
                }

                var usuario = new Usuario
                {
                    Nome = cadastroDTO.Nome,
                    Sobrenome = cadastroDTO.Sobrenome,
                    CPF = cadastroDTO.CPF,
                    Email = cadastroDTO.Email,
                    Senha = cadastroDTO.Senha,
                    Telefone = cadastroDTO.Telefone
                };

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return RedirectToAction("Login", "Auth");
            }

            return View(cadastroDTO);
        }
    }
}
