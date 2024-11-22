using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EnergyLinkGlobalSolution.Data;
using EnergyLinkGlobalSolution.DTOs;
using EnergyLinkGlobalSolution.Models;
using System.Linq;

namespace EnergyLinkGlobalSolution.Controllers
{
    public class AuthController : Controller
    {
        private readonly dbContext _context;

        public AuthController(dbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);

            if (usuario != null)
            {
                HttpContext.Session.SetString("User", usuario.Email);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Usuário ou senha inválidos!";
            return View(login);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
    }
}
