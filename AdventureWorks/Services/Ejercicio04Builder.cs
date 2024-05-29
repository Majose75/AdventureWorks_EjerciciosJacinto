using AdventureWorks.Models;
using System.Drawing;

namespace AdventureWorks.Services
{
    public class Ejercicio04Builder: IProductSpecification, IProductoQuery
    {
        private IProductSpecification especificacion;

        public Ejercicio04Builder()
        {
            IProductSpecification PorInicio = new NameComienzaSpecification()
            {
                letras = ["A","B","C"]
            };
            IProductSpecification PorColor = new ProductColorSpecification()
            {
                colores = ["RED", "BLUE", "BLACK"]
            };
            IProductSpecification PorPrecio = new ListPriceSpecification()
            {
                Price = 3
            };
            IProductSpecification And01 = new AndSpecification()
            {
                Spec1 = PorInicio,
                Spec2 = PorColor
            };
            this.especificacion = new AndSpecification()
            {
                Spec1 = And01,
                Spec2 = PorPrecio
            };
        }

        public IEnumerable<Product> dameProductos(IEnumerable<Product> products)
        {
            return products.Where(x => especificacion.isValid(x)).OrderBy(x => x.Name);
        }
        public bool isValid(Product _producto)
        {
            return especificacion.isValid(_producto);
        }

    }
}
