using Microsoft.AspNetCore.Mvc;
using EnergyLinkGlobalSolution.Models;
using Microsoft.EntityFrameworkCore;
using EnergyLinkGlobalSolution.Data;
using EnergyLinkGlobalSolution.DTOs;

namespace EnergyLinkGlobalSolution.Controllers
{
    public class MonitoramentoController : Controller
    {
        private readonly dbContext _context;

        public MonitoramentoController(dbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var monitoramentos = await _context.Monitoramentos.Include(m => m.Entidade).ToListAsync();

            return View(monitoramentos);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEntidade, DataMonitoramento, Energia, TipoMonitoramento")] Monitoramento monitoramentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monitoramentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monitoramentos);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitoramento = await _context.Monitoramentos
                .Include(m => m.Entidade)
                .FirstOrDefaultAsync(m => m.IdEntidade == id);

            if (monitoramento == null)
            {
                return NotFound();
            }

            var monitoramentoDTO = new MonitoramentoDTO
            {
                IdEntidade = monitoramento.IdEntidade,
                Entidade = monitoramento.Entidade,
                DataMonitoramento = monitoramento.DataMonitoramento,
                Energia = monitoramento.Energia,
                TipoMonitoramento = monitoramento.TipoMonitoramento
            };

            return View(monitoramentoDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEntidade,DataMonitoramento,Energia,TipoMonitoramento")] MonitoramentoDTO monitoramentoDTO)
        {
            if (id != monitoramentoDTO.IdEntidade)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var monitoramento = await _context.Monitoramentos.FindAsync(id);

                    if (monitoramento == null)
                    {
                        return NotFound();
                    }

                    monitoramento.DataMonitoramento = monitoramentoDTO.DataMonitoramento;
                    monitoramento.Energia = monitoramentoDTO.Energia;
                    monitoramento.TipoMonitoramento = monitoramentoDTO.TipoMonitoramento;

                    _context.Update(monitoramento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Monitoramentos.Any(e => e.IdEntidade == monitoramentoDTO.IdEntidade))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(monitoramentoDTO);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitoramento = await _context.Monitoramentos
                .Include(m => m.Entidade)
                .FirstOrDefaultAsync(m => m.IdMonitoramento == id);

            if (monitoramento == null)
            {
                return NotFound();
            }

            return View(monitoramento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monitoramento = await _context.Monitoramentos.FindAsync(id);
            if (monitoramento != null)
            {
                _context.Monitoramentos.Remove(monitoramento);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
