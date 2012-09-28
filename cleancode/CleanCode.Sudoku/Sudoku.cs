namespace CleanCode.Sudoku
{
    /**
 * <p>
 * The following is an example of a Sudoku problem:
 *
 * <pre>
 * -----------------------
 * |   8   | 4   2 |   6   |
 * |   3 4 |       | 9 1   |
 * | 9 6   |       |   8 4 |
 *  -----------------------
 * |       | 2 1 6 |       |
 * |       |       |       |
 * |       | 3 5 7 |       |
 *  -----------------------
 * | 8 4   |       |   7 5 |
 * |   2 6 |       | 1 3   |
 * |   9   | 7   1 |   4   |
 *  -----------------------
 * </pre>
 *
 * The goal is to fill in the missing numbers so that every row, column and box
 * contains each of the numbers <code>1-9</code>. Here is the solution to the
 * problem above:
 *
 * <pre>
 *  -----------------------
 * | 1 8 7 | 4 9 2 | 5 6 3 |
 * | 5 3 4 | 6 7 8 | 9 1 2 |
 * | 9 6 2 | 1 3 5 | 7 8 4 |
 *  -----------------------
 * | 4 5 8 | 2 1 6 | 3 9 7 |
 * | 2 7 3 | 8 4 9 | 6 5 1 |
 * | 6 1 9 | 3 5 7 | 4 2 8 |
 *  -----------------------
 * | 8 4 1 | 9 6 3 | 2 7 5 |
 * | 7 2 6 | 5 8 4 | 1 3 9 |
 * | 3 9 5 | 7 2 1 | 8 4 6 |
 *  -----------------------
 * </pre>
 *
 * Note that the first row <code>187492563</code> contains each number exactly
 * once, as does the first column <code>159426873</code>, the upper-left box
 * <code>187534962</code>, and every other row, column and box.
 *
 * <p>
 * See <a href="http://en.wikipedia.org/wiki/Sudoku">Wikipedia: Sudoku</a> for more information on Sudoku.
 *
 * <p>
 * The algorithm employed is similar to the standard backtracking <a href="http://en.wikipedia.org/wiki/Eight_queens_puzzle">eight queens algorithm</a>.
 *
 * @version 1.0
 * @author <a href="http://www.colloquial.com/carp">Bob Carpenter</a>
 */
    public class Sudoku
    {
        private readonly ISudokuLegalMoveVerifier _sudokuLegalMoveVerifier;

        public Sudoku(ISudokuLegalMoveVerifier sudokuLegalMoveVerifier)
        {
            _sudokuLegalMoveVerifier = sudokuLegalMoveVerifier;
        }

        public int[,] solve(int[,] matrix)
        {
            if (solve(0, 0, matrix)) // solves in place
                return matrix;
            return null;
        }

        bool solve(int i, int j, int[,] cells)
        {
            if (i == 9)
            {
                i = 0;
                if (++j == 9)
                    return true;
            }
            if (cells[i,j] != 0) // skip filled cells
                return solve(i + 1, j, cells);

            for (int val = 1; val <= 9; ++val)
            {
                if (_sudokuLegalMoveVerifier.IsMoveLegal(i, j, val, cells))
                {
                    cells[i,j] = val;
                    if (solve(i + 1, j, cells))
                        return true;
                }
            }
            cells[i,j] = 0; // reset on backtrack
            return false;
        }
    }
}