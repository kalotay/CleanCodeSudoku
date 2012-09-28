using System;

namespace CleanCode.Sudoku
{
    public class SudokuProblemParser
    {
        public int[,] parseProblem(String grid) {
            int[,] problem = new int[9,9];
            for (int i = 0; i < 81; i++) {
                int x = i / 9;
                int y = i % 9;
                problem[x, y] = Int32.Parse("" + grid[i]);
            }
            return problem;
        }
    }
}