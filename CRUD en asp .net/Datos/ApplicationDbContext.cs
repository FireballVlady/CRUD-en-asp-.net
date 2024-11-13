using CRUD_en_asp_.net.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_en_asp_.net.Datos
{
    public class ApplicationDbContext: DbContext
    {
        //constructor para la base de datos
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        { 
        }
        //poner los modelos de la base de datos

        public DbSet<Producto> productos { get; set; }

    }
}
