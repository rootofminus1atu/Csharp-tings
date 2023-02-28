namespace Matrix_but_classes
{
    public class Matrix
    {
        public double[,] Nums;
        public Matrix(double[,] nums)
        {
            this.Nums = nums;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // continued on replit for some reason

            Matrix matrix1 = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });

        }
    }

    
}