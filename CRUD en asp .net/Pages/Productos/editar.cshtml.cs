using CRUD_en_asp_.net.Datos;
using CRUD_en_asp_.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_en_asp_.net.Pages.Productos
{
    public class editarModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public editarModel(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        [BindProperty]
        public Producto Producto { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task  OnGet(int id)
        {
            Producto = await _context.productos.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                var CursoDesdeDB = await _context.productos.FindAsync(Producto.Id);
                CursoDesdeDB.NombreProducto = Producto.NombreProducto;
                CursoDesdeDB.Descripcion = Producto.Descripcion;
                CursoDesdeDB.EndStock = Producto.EndStock;
                CursoDesdeDB.Precio = Producto.Precio;

                await _context.SaveChangesAsync();
                Mensaje = "Editado correctamente";
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
