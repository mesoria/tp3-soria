﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public int ID { get; set; }
        public string DNI { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        //public bool sexo { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string CP { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
