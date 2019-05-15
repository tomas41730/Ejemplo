using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Producto
    {
        public int codigo;
        public string nombre;
        public string descripcion;
        public double precio;
        public int stock;
        public string IMGpath;

        public Producto(int codigo, string nombre, string descripcion, double precio, int stock, string IMGpath)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
            this.IMGpath = IMGpath;
        }

        public Producto()
        {
        }

        public override string ToString()
        {
            return "Codigo: " + codigo+"\n"
                 + "Nombre: " + nombre + "\n" 
                 + "Descripcion: " + descripcion + "\n" 
                 + "Precio: " + precio + "\n" 
                 + "Stock: " + stock;
        }

 
    }

 
}
