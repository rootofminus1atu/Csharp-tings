using System.Collections.Generic;

namespace Tensors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Tensor
    {
        int rank;
        public double[] values;
        public double[,] values2;
        public double[,,] values3;
        public double[,,,] values4;
        public double[,,,,] values5;
        public double[,,,,,] values6;
        public double[,,,,,,] values7;

        public Tensor()
        {
            
        }
    }
}