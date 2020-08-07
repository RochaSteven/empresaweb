using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Empresa2.Models;

namespace Empresa2.Data
{
    public class VehiculoContext : DbContext
    {
        public VehiculoContext (DbContextOptions<VehiculoContext> options)
            : base(options)
        {
        }

        public DbSet<Empresa2.Models.Vehiculo> Vehiculo { get; set; }
    }
}
