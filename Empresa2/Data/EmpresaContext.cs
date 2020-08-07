using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Empresa2.Models;

namespace Empresa2.Data
{
    public class EmpresaContext : DbContext
    {
        public EmpresaContext (DbContextOptions<EmpresaContext> options)
            : base(options)
        {
        }

        public DbSet<Empresa2.Models.Empresa> Empresa { get; set; }
    }
}
