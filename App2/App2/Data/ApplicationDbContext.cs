using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using App2.Models;

namespace App2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<App2.Models.Rubro> Rubros { get; set; }

        public DbSet<App2.Models.Subrubro> Subrubros { get; set; }

        public DbSet<App2.Models.Articulo> Articulos { get; set; }
    }
}
