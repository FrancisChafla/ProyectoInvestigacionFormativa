using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigacion_Formativa
{
    public class ListaProductos
    {
        public List<Producto> ListProductos { set; get; }
        public ListaProductos()
        {
            ListProductos = new List<Producto>();
        }
        public void AgregarProduct(Producto producto)
        {
            ListProductos.Add( producto );
        }

    }
}
