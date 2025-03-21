using System;
using System.IO;

class Archivo
{
    private string _rutaArchivo;

    public Archivo(string rutaArchivo)
    {
        _rutaArchivo = rutaArchivo;
    }

    public void GuardarNombres(string[] nombres)
    {
        File.WriteAllLines(_rutaArchivo, nombres);
        Console.WriteLine("\nLos nombres han sido guardados exitosamente en el archivo 'nombres.txt'.\n");
    }

    public void LeerNombres()
    {
        if (File.Exists(_rutaArchivo))
        {
            string[] nombresLeidos = File.ReadAllLines(_rutaArchivo);
            Console.WriteLine("Nombres almacenados en el archivo 'nombres.txt':");
            foreach (var nombre in nombresLeidos)
            {
                Console.WriteLine(nombre);
            }
        }
        else
        {
            Console.WriteLine("El archivo 'nombres.txt' no existe.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "nombres.txt";

        Archivo archivo = new Archivo(filePath);

        string[] nombres = ObtenerNombres();

        archivo.GuardarNombres(nombres);

        archivo.LeerNombres();
    }

    static string[] ObtenerNombres()
    {
        string[] nombres = new string[5];
        Console.WriteLine("Por favor, ingresa 5 nombres:");

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Nombre {i + 1}: ");
            nombres[i] = Console.ReadLine();
        }

        return nombres;
    }
}