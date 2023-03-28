using System.IO;
using System.Text;

namespace Lab13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // filehandling and pain

            string FilePath = @"../../../myfile.txt";
            string data;
            FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite);

            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                data = streamReader.ReadToEnd();
            }

            Console.WriteLine(data);


            /*
            byte[] bdata = Encoding.Default.GetBytes("add me to the end of the file");
            fileStream.Write(bdata, 0, bdata.Length);

            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                data = streamReader.ReadToEnd();
            }
            */
        }
    }
}