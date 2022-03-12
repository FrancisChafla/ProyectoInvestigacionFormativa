using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigacion_Formativa
{
    public class Producto
    {
        public string Nombre { set; get; }
        public string Articulo { set; get; }
        public int Codigo { set; get; }
        public int Cantidad { set; get; }

        public Producto()
        {

        }

        public Producto(string nombre, string direccion, string articulo, int codigo, int cantidad)
        {
            Nombre = nombre;
            Articulo = articulo;
            Codigo = codigo;
            Cantidad = cantidad;
        }
    }
}
