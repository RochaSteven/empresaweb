using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empresa2.Models
{
    public class Cliente:Persona
    {
        
        public string Direccion { get; set; }
        public ICollection<Cliente_vehiculo> Cliente_vehiculo { get; set; }



    }
}
