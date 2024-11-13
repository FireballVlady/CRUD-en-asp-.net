using CRUD_en_asp_.net.Datos;
using CRUD_en_asp_.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD_en_asp_.net.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Producto> Productos { get; set; }

        [TempData]
        public string Mensaje { get; set; }
        public async Task OnGet()
        {
            Productos = await _context.productos.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id) 
        {
            var producto = await _context.productos.FindAsync(id);
            if (producto == null)
            { 
                return NotFound();
            }
            _context.productos.Remove(producto);
            await _context.SaveChangesAsync();
            Mensaje = "Borrado Correctamente";
            return RedirectToPage("Index");
        }
    }
}
