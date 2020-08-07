

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.ComTypes;

namespace Empresa2.Models
{
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Propietario { get; set; }
        public ICollection<Vehiculo> Vehiculo { get; set; }


    }

    
}
