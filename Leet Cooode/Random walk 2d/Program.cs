namespace Random_walk_2d
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // hey I could use points (pairs actually) to create lists
            // lists from scratch
            // I should do that

            char[] path = { 'n', 'e', 's', 'w' };
            char[] path2 = { 'n', 'n' };

            // Point start = new Point(0, 0);

            // Point end = new Point(start.Walk(path).x, start.Walk(path).y) ;

            // Point.Print(start);

            Point here = new Point(1, 2);
            Point.Print(here.Move2('n'));


            Point here2 = new Point(3, 6);
        }
    }

    public class Point
    {
        public int x;
        public int y;

        static readonly public Dictionary<char, Point> directions = new Dictionary<char, Point>()
        {
            { 'e', new Point(1, 0) },
            { 'n', new Point(0, 1) },
            { 'w', new Point(-1, 0) },
            { 's', new Point(0, -1) },
        };

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point operator +(Point A, Point B)
        {
            return new Point(A.x + B.x, A.y + B.y);
        }

        public override string ToString()
        {
            return $"({this.x}, {this.y})";
        }



        public static void Print(Point A)
        {
            Console.WriteLine($"({A.x}, {A.y})");
        }

        public void Move(char dir)
        {
            Point delta = directions[dir];
            this.x += delta.x;
            this.y += delta.y;
        }

        public Point Move2(char dir)
        {
            return this + directions[dir];
        }

        public void Walk(char[] path)
        {
            foreach (char dir in path)
                this.Move(dir);
        }

        public void WalkShow(char[] path)
        {
            Console.WriteLine($"Walk started at: {this.ToString()}");

            foreach (char dir in path)
            {
                this.Move(dir);
                Print(this);
            }

            Console.WriteLine($"Walk ended at: {this.ToString()}");
        }

    }
}