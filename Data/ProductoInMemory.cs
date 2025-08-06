using Domain.Model;

namespace Data
{
    public static class ProductoInMemory
    {
        public static List<Producto> Productos;

        static ProductoInMemory()
        {
            Productos = new List<Producto>
            {
                new Producto(1, "Procesador Ryzen 5 5600X", "6 núcleos, 12 hilos, 3.7 GHz", 90000, 15, 1, 1),
                new Producto(2, "Motherboard B550", "Chipset B550, AM4", 75000, 10, 2, 2),
                new Producto(3, "Memoria RAM 16GB DDR4", "3200MHz CL16", 40000, 30, 3, 3)
            };
        }
    }
}
