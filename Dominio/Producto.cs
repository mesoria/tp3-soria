﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public Int64 ID { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string URLImagen { get; set; }
    }
}
