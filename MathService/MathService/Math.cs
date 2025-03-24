using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace MathService
{
    public class Math : IMath
    {
        // Método que determine si un número es primo
        public bool Prime(int value)
        {
            if (value < 2)
            {
                return false;
            }
            for (int i = 2; i < value; i++)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Método que reciba una tupla y retorne otra con la suma de sus elementos y el nombre adecuado
        public Tuple Add(Tuple tuple)
        {
            double sum = 0;
            foreach (double d in tuple.Data)
            {
                sum += d;
            }
            Tuple result = new Tuple();
            result.Data = new double[] { sum };
            result.Name = "Sum";
            return result;
        }

        // Método que resuelva un sistema de ecuaciones lineales
        public double[] SolveLinearSystem(int numEquations, double[][] coefficients, double[] constants)
        {
            var matrixData = new double[numEquations, numEquations];

            for (int i = 0; i < numEquations; i++)
            {
                for (int j = 0; j < numEquations; j++)
                {
                    matrixData[i, j] = coefficients[i][j];
                }
            }

            var matrix = Matrix<double>.Build.DenseOfArray(matrixData);
            var vector = Vector<double>.Build.DenseOfArray(constants);
            var solution = matrix.Solve(vector);
            return solution.ToArray();
        }
    }
}
