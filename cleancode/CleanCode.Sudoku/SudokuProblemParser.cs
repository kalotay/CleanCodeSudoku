using System;

namespace CleanCode.Sudoku
{
    public class SudokuProblemParser
    {
        public int[,] parseProblem(String grid) {
            var problem = new int[9,9];
            for (var i = 0; i < 81; i++) {
                var x = i / 9;
                var y = i % 9;
                problem[x, y] = Int32.Parse("" + grid[i]);
            }
            return problem;
        }
    }
}