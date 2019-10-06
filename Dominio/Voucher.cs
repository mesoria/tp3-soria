using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Voucher
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public bool Estado { get; set; }
        public Int64 CodeCliente { get; set; }
        public Int64 CodeProducto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
