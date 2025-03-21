using System;

class Matriz
{
    private int[,] _matriz;

    public Matriz()
    {
        _matriz = new int[3, 3];
    }

    public void IngresarValores()
    {
        Console.WriteLine("Ingrese los valores de la matriz 3x3:");

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Elemento [{i + 1}, {j + 1}]: ");
                _matriz[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    public void MultiplicarPorNumero(int numero)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                _matriz[i, j] *= numero;
            }
        }
    }

    public void MostrarMatriz()
    {
        Console.WriteLine("Matriz resultante:");

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(_matriz[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Matriz matriz = new Matriz();

        matriz.IngresarValores();

        Console.WriteLine("\nMatriz original:");
        matriz.MostrarMatriz();

        Console.Write("\nIngrese el número por el cual desea multiplicar cada fila: ");
        int numero = int.Parse(Console.ReadLine());

        matriz.MultiplicarPorNumero(numero);

        matriz.MostrarMatriz();
    }
}
