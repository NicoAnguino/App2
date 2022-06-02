using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App2.Models
{
    public class Rubro
    {
        [Key]
        public int RubroID { get; set; }
        public string Descripcion { get; set; }
        public bool Eliminado { get; set; }
        public byte[] Img { get; set; }
        public string TipoImg { get; set; }

        public virtual ICollection<Subrubro> Subrubros { get; set; }

    }
}
