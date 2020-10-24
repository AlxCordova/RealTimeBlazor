using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealTime.Shared
{
    public class Productos
    {
        [Key]
        public int idProducto { get; set; }
        public string producto { get; set; }
        public int idMarca { get; set; }
        public string descripcion { get; set; }
        public decimal precio_costo { get; set; }
        public decimal precio_venta { get; set; }
        public int existencia { get; set; }
    }
}
