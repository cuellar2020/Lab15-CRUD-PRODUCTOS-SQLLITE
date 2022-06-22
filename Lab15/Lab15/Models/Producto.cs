using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab15.Models
{
    public class Producto
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string Precio { get; set; }
    }
}
