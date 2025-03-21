using System;
using System.IO;
using System.Collections.Generic;

class Venta
{
    public string NombreProducto { get; set; }
    public int CantidadVendida { get; set; }
    public double PrecioUnitario { get; set; }

    public Venta(string nombreProducto, int cantidadVendida, double precioUnitario)
    {
        NombreProducto = nombreProducto;
        CantidadVendida = cantidadVendida;
        PrecioUnitario = precioUnitario;
    }

    public double CalcularVenta()
    {
        return CantidadVendida * PrecioUnitario;
    }
}

class RegistroVentas
{
    private string _rutaArchivo;

    public RegistroVentas(string rutaArchivo)
    {
        _rutaArchivo = rutaArchivo;
    }

    public void GuardarVenta(Venta venta)
    {
        using (StreamWriter sw = new StreamWriter(_rutaArchivo, true))
        {
            sw.WriteLine($"{venta.NombreProducto},{venta.CantidadVendida},{venta.PrecioUnitario}");
        }
    }

    public double CalcularTotalVentas()
    {
        double totalVentas = 0;

        if (File.Exists(_rutaArchivo))
        {
            string[] lineas = File.ReadAllLines(_rutaArchivo);

            foreach (var linea in lineas)
            {
                string[] datos = linea.Split(',');

                string nombreProducto = datos[0];
                int cantidadVendida = int.Parse(datos[1]);
                double precioUnitario = double.Parse(datos[2]);

                Venta venta = new Venta(nombreProducto, cantidadVendida, precioUnitario);
                totalVentas += venta.CalcularVenta();

                Console.WriteLine($"Producto: {venta.NombreProducto}, Venta: {venta.CalcularVenta():C2}");
            }
        }
        else
        {
            Console.WriteLine("El archivo 'ventas.csv' no existe.");
        }

        return totalVentas;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string rutaArchivo = "ventas.csv";

        RegistroVentas registro = new RegistroVentas(rutaArchivo);

        RegistrarVentas(registro);

        double totalVentas = registro.CalcularTotalVentas();
        Console.WriteLine($"\nEl total de ventas del día es: {totalVentas:C2}");
    }

    static void RegistrarVentas(RegistroVentas registro)
    {
        Console.WriteLine("Ingrese las ventas del día (escriba 'fin' para terminar):");

        while (true)
        {
            Console.Write("Nombre del producto: ");
            string nombreProducto = Console.ReadLine();

            if (nombreProducto.ToLower() == "fin")
                break;

            Console.Write("Cantidad vendida: ");
            int cantidadVendida = int.Parse(Console.ReadLine());

            Console.Write("Precio unitario: ");
            double precioUnitario = double.Parse(Console.ReadLine());

            Venta venta = new Venta(nombreProducto, cantidadVendida, precioUnitario);

            registro.GuardarVenta(venta);
        }

        Console.WriteLine("Las ventas han sido registradas en el archivo 'ventas.csv'.");
    }
}
