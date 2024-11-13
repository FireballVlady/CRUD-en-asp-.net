using CRUD_en_asp_.net.Datos;
using CRUD_en_asp_.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD_en_asp_.net.Pages.Productos
{
    public class crearModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public crearModel(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        [BindProperty]
        public Producto Producto { get; set; }
        public void OnGet()
        {
        }
        
        [TempData]
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnPost() 
        {

            if (!ModelState.IsValid) 
            {
                return Page();
            }

            Producto.FechaCreacion = DateTime.Now;
            _context.Add(Producto);
            await _context.SaveChangesAsync();
            Mensaje = "producto creado correctamente";
            return RedirectToPage("Index");
        }
    }
}
