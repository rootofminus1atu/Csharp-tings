namespace Which_nums_add_to_target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 4, 11, 3 };
            int target = 6;

            int[] answer = TwoSum(nums, target);

            Console.WriteLine(String.Join(" ", answer));
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            int[] table = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j && nums[i] + nums[j] == target)
                    {
                        table[0] = j;
                        table[1] = i;
                        break;
                    }
                }
            }

            return table;
        }
    }
}