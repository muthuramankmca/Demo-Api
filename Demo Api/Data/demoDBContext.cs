using Demo_Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Demo_Api.Data
{
    public class demoDBContext:DbContext
    {


       public demoDBContext(DbContextOptions dbContextOptions):base (dbContextOptions) 
        { 


        }

        public DbSet<Product> Products { get; set; }
    }
}
