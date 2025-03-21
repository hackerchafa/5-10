using System;
using System.Linq;

class Arreglo
{
    private int[] _numeros;

    public Arreglo(int tamaño)
    {
        _numeros = new int[tamaño];
    }

    public void IngresarNumeros()
    {
        Console.WriteLine("Por favor, ingresa 10 números:");

        for (int i = 0; i < _numeros.Length; i++)
        {
            Console.Write($"Número {i + 1}: ");
            _numeros[i] = int.Parse(Console.ReadLine());
        }
    }

    public void MostrarArreglo()
    {
        Console.WriteLine("Arreglo actual:");
        foreach (var numero in _numeros)
        {
            Console.Write(numero + " ");
        }
        Console.WriteLine();
    }

    public void EliminarNumero(int numero)
    {
        int index = Array.IndexOf(_numeros, numero);

        if (index >= 0)
        {
            _numeros = _numeros.Where((val, idx) => idx != index).ToArray();
            Console.WriteLine($"Número {numero} eliminado.");
        }
        else
        {
            Console.WriteLine($"El número {numero} no se encuentra en el arreglo.");
        }
    }

    public int[] ObtenerArreglo()
    {
        return _numeros;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Arreglo arreglo = new Arreglo(10);

        arreglo.IngresarNumeros();

        arreglo.MostrarArreglo();

        Console.Write("\nIngrese el número que desea eliminar: ");
        int numeroAEliminar = int.Parse(Console.ReadLine());

        arreglo.EliminarNumero(numeroAEliminar);

        arreglo.MostrarArreglo();
    }
}

