namespace q2_chess_blackbox
{
    // row: [1, 8], col: [1, 8]
    // for just `row`:
    // eq-class representatives:
    //   -5
    //   5 
    //   15
    // near boundary representatives:
    //   0, 1, 2
    //   7, 8, 9

    // same for `col`

    // then mix them up, one from each?

    internal class Program
    {
        static void Main(string[] args)
        {
            List<(int, bool)> tests = new() {
                (5, true),  // inside
                (-5, false),  // outside
                (15, false),  // outside

                (0, false),  // left boundary
                (1, true),
                (2, true),

                (7, true),  // right boundary
                (8, true),
                (9, true),
            };
        }

        static bool IsValidChessCoord(int row, int col)
        {
            const int BOUND_LEFT = 1;
            const int BOUND_RIGHT = 8;

            return (row >= BOUND_LEFT && row <= BOUND_RIGHT) && (col >= BOUND_LEFT && col <= BOUND_RIGHT);
        }
    }
}
