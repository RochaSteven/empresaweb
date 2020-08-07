using System;
using System.Collections.Generic;
using System.Text;
using Empresa2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Empresa2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)

        {
        }
        public DbSet <Cliente> Clientes { get; set; }
        public DbSet <Motor> Motors { get; set; }
        public DbSet <Vehiculo> Vehiculos { get; set; }
        public DbSet <Empresa> Empresas { get; set; }
        public DbSet <Cliente_vehiculo> Cliente_Vehiculos { get; set;}


    }
}
