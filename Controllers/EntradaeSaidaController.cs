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
    public class EntradaeSaidaController : Controller
    {
        private readonly Contexto _context;

        public EntradaeSaidaController(Contexto context)
        {
            _context = context;
        }

        // GET: EntradaeSaida
        public async Task<IActionResult> Index()
        {
            var contexto = _context.EntradaeSaida.Include(e => e.Produto).Include(e => e.TipoMovimentacao);
            return View(await contexto.ToListAsync());
        }

        // GET: EntradaeSaida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EntradaeSaida == null)
            {
                return NotFound();
            }

            var entradaeSaida = await _context.EntradaeSaida
                .Include(e => e.Produto)
                .Include(e => e.TipoMovimentacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradaeSaida == null)
            {
                return NotFound();
            }

            return View(entradaeSaida);
        }

        // GET: EntradaeSaida/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "NomeProduto");
            ViewData["TipoMovimentacaoId"] = new SelectList(_context.TipoMovimentacao, "Id", "NomeTipoMovimentacao");
            return View();
        }

        // POST: EntradaeSaida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,QuantidadeMovimentacao,TipoMovimentacaoId,DataMovimentacao")] EntradaeSaida entradaeSaida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entradaeSaida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "NomeProduto", entradaeSaida.ProdutoId);
            ViewData["TipoMovimentacaoId"] = new SelectList(_context.TipoMovimentacao, "Id", "NomeTipoMovimentacao", entradaeSaida.TipoMovimentacaoId);
            return View(entradaeSaida);
        }

        // GET: EntradaeSaida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EntradaeSaida == null)
            {
                return NotFound();
            }

            var entradaeSaida = await _context.EntradaeSaida.FindAsync(id);
            if (entradaeSaida == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "NomeProduto", entradaeSaida.ProdutoId);
            ViewData["TipoMovimentacaoId"] = new SelectList(_context.TipoMovimentacao, "Id", "NomeTipoMovimentacao", entradaeSaida.TipoMovimentacaoId);
            return View(entradaeSaida);
        }

        // POST: EntradaeSaida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProdutoId,QuantidadeMovimentacao,TipoMovimentacaoId,DataMovimentacao")] EntradaeSaida entradaeSaida)
        {
            if (id != entradaeSaida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entradaeSaida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaeSaidaExists(entradaeSaida.Id))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "NomeProduto", entradaeSaida.ProdutoId);
            ViewData["TipoMovimentacaoId"] = new SelectList(_context.TipoMovimentacao, "Id", "NomeTipoMovimentacao", entradaeSaida.TipoMovimentacaoId);
            return View(entradaeSaida);
        }

        // GET: EntradaeSaida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EntradaeSaida == null)
            {
                return NotFound();
            }

            var entradaeSaida = await _context.EntradaeSaida
                .Include(e => e.Produto)
                .Include(e => e.TipoMovimentacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradaeSaida == null)
            {
                return NotFound();
            }

            return View(entradaeSaida);
        }

        // POST: EntradaeSaida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EntradaeSaida == null)
            {
                return Problem("Entity set 'Contexto.EntradaeSaida'  is null.");
            }
            var entradaeSaida = await _context.EntradaeSaida.FindAsync(id);
            if (entradaeSaida != null)
            {
                _context.EntradaeSaida.Remove(entradaeSaida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaeSaidaExists(int id)
        {
          return (_context.EntradaeSaida?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
