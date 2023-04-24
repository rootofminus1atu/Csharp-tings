namespace Lab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = new int[5];
            intArr[0] = 999;
            intArr[1] = 666;
            intArr[2] = 0;
            intArr[3] = 333;
            // last element unassigned


            PrintArray(intArr);
            intArr = RemoveDefault(intArr);
            PrintArray(intArr);

            intArr = intArr[..3];
            PrintArray(intArr);

            Console.WriteLine($"Length: {intArr.Length}");




        }

        public static T[] RemoveEmpty<T>(T[] arr)
        {
            return arr.Where(e => (!e.Equals(default(T))) && e != null).ToArray();
        }

        public static T[] RemoveEmpty2<T>(T[] arr)
        {
            List<T> temp = new List<T>() { };

            foreach (T item in arr)
                if (item.Equals(default(T)) || item != null)
                    temp.Add(item);

            return temp.ToArray();
        }

        public static T[] RemoveDefault<T>(T[] arr)
        {
            T defaultValue = default(T);
            T[] defaultArr = Enumerable.Repeat(defaultValue, arr.Length).ToArray();
            return arr.Where(x => !Enumerable.SequenceEqual(new[] { x }, defaultArr)).ToArray();
        }


        public static T[] TrimArray<T>(T[] arr, int length)
        {
            T[] temp = new T[length];

            for (int i = 0; i < length; i++)
            {
                temp[i] = arr[i];
            }

            return temp;
        }

        public static void PrintArray<T>(T[] arr)
        {
            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }


    }
}