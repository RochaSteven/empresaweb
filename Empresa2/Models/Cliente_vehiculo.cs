using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa2.Models
{
    public class Cliente_vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idClienteVehiculo { get; set; }
        public int IdCliente { get; set; }
        public int IdVehiculo { get; set; }
        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }



    }
}
