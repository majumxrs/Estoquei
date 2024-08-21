using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estoquei.Models;

namespace Estoquei.Controllers
{
    public class TipoMovimentacaoController : Controller
    {
        private readonly Contexto _context;

        public TipoMovimentacaoController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoMovimentacao
        public async Task<IActionResult> Index()
        {
              return _context.TipoMovimentacao != null ? 
                          View(await _context.TipoMovimentacao.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoMovimentacao'  is null.");
        }

        // GET: TipoMovimentacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoMovimentacao == null)
            {
                return NotFound();
            }

            var tipoMovimentacao = await _context.TipoMovimentacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMovimentacao == null)
            {
                return NotFound();
            }

            return View(tipoMovimentacao);
        }

        // GET: TipoMovimentacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMovimentacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeTipoMovimentacao")] TipoMovimentacao tipoMovimentacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMovimentacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMovimentacao);
        }

        // GET: TipoMovimentacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoMovimentacao == null)
            {
                return NotFound();
            }

            var tipoMovimentacao = await _context.TipoMovimentacao.FindAsync(id);
            if (tipoMovimentacao == null)
            {
                return NotFound();
            }
            return View(tipoMovimentacao);
        }

        // POST: TipoMovimentacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeTipoMovimentacao")] TipoMovimentacao tipoMovimentacao)
        {
            if (id != tipoMovimentacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMovimentacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMovimentacaoExists(tipoMovimentacao.Id))
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
            return View(tipoMovimentacao);
        }

        // GET: TipoMovimentacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoMovimentacao == null)
            {
                return NotFound();
            }

            var tipoMovimentacao = await _context.TipoMovimentacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMovimentacao == null)
            {
                return NotFound();
            }

            return View(tipoMovimentacao);
        }

        // POST: TipoMovimentacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoMovimentacao == null)
            {
                return Problem("Entity set 'Contexto.TipoMovimentacao'  is null.");
            }
            var tipoMovimentacao = await _context.TipoMovimentacao.FindAsync(id);
            if (tipoMovimentacao != null)
            {
                _context.TipoMovimentacao.Remove(tipoMovimentacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMovimentacaoExists(int id)
        {
          return (_context.TipoMovimentacao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
