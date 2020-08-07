

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empresa2.Models
{
    public class Motor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMotor { get; set; }
        public string Marca { get; set; }
        public string TipoDeMotor { get; set; }

        public ICollection <Vehiculo> Vehiculo { get; set; }
      
    }
}
