using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Empresa2.Models;

namespace Empresa2
{
    public class DataMainContext : DbContext
    {
        public DataMainContext (DbContextOptions<DataMainContext> options)
            : base(options)
        {
        }

        public DbSet<Empresa2.Models.Cliente> Cliente { get; set; }

        public DbSet<Empresa2.Models.Empresa> Empresa { get; set; }

        public DbSet<Empresa2.Models.Motor> Motor { get; set; }

        public DbSet<Empresa2.Models.Vehiculo> Vehiculo { get; set; }
    }
}
