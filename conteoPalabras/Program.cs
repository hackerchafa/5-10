using System;
using System.IO;

class Archivo
{
    private string _rutaArchivo;

    public Archivo(string rutaArchivo)
    {
        _rutaArchivo = rutaArchivo;
    }

    public void GuardarTexto(string texto)
    {
        File.WriteAllText(_rutaArchivo, texto);
        Console.WriteLine("\nEl texto ha sido guardado en el archivo 'texto.txt'.");
    }

    public int ContarPalabras()
    {
        if (File.Exists(_rutaArchivo))
        {
            string contenido = File.ReadAllText(_rutaArchivo);

            string[] palabras = contenido.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            return palabras.Length;
        }
        else
        {
            Console.WriteLine("El archivo 'texto.txt' no existe.");
            return 0;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "texto.txt";

        Archivo archivo = new Archivo(filePath);

        Console.WriteLine("Por favor, ingresa un texto (puedes usar varias líneas, y al terminar presiona Enter vacío para finalizar):");
        string texto = ObtenerTextoDelUsuario();

        archivo.GuardarTexto(texto);

        int totalPalabras = archivo.ContarPalabras();
        Console.WriteLine($"\nEl texto contiene {totalPalabras} palabras.");
    }

    static string ObtenerTextoDelUsuario()
    {
        string texto = "";
        string linea;

        while (true)
        {
            linea = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(linea))
                break;
            texto += linea + "\n";
        }

        return texto;
    }
}
