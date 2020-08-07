
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empresa2.Models
{
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVehiculo { get; set; }
        public string Modelo { get; set; }  
        public string Color {  get; set; }

        public int IdMotor { get; set; }
        public Motor Motor { get; set; }
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
        public ICollection<Cliente_vehiculo> Cliente_vehiculo { get; set; }
    }
}
