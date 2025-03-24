using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClientConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MathClient client = new MathClient("BasicHttpBinding_IMath");

                int x = 23;

                if (client.Prime(x))
                    Console.WriteLine("{0} es primo", x);
                else
                    Console.WriteLine("{0} no es primo", x);

                Console.Write("Introduce el número de ecuaciones: ");
                int numEquations = int.Parse(Console.ReadLine());

                double[][] coefficients = new double[numEquations][];
                double[] constants = new double[numEquations];

                // Leer los coeficientes
                for (int i = 0; i < numEquations; i++)
                {
                    coefficients[i] = new double[numEquations];
                    for (int j = 0; j < numEquations; j++)
                    {
                        Console.Write($"Coeficiente [{i + 1},{j + 1}]: ");
                        coefficients[i][j] = double.Parse(Console.ReadLine());
                    }
                }

                // Leer las constantes
                for (int i = 0; i < numEquations; i++)
                {
                    Console.Write($"Constante {i + 1}: ");
                    constants[i] = double.Parse(Console.ReadLine());
                }

                // Llamar al método SolveLinearSystem
                double[] result = client.SolveLinearSystem(numEquations, coefficients, constants);

                Console.WriteLine("Solución del sistema de ecuaciones:");
                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine($"x{i + 1} = {result[i]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al invocar el servicio: {ex.Message}");
            }
        }
    }
}
