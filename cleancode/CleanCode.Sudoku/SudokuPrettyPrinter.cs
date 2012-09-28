using System;
using System.Text;

namespace CleanCode.Sudoku
{
    public class SudokuPrettyPrinter
    {
        public String prettyPrint(int[,] grid)
        {
            var buffer = new StringBuilder();
            for (int i = 0; i < 9; ++i)
            {
                if (i % 3 == 0)
                    buffer.Append(" -----------------------\n");
                for (int j = 0; j < 9; ++j)
                {
                    if (j % 3 == 0)
                    {
                        buffer.Append("| ");
                    }
                    buffer.Append(grid[i,j] == 0 ? " " : (grid[i,j].ToString()));
                    buffer.Append(' ');
                }
                buffer.Append("|\n");
            }
            buffer.Append(" -----------------------\n");
            return buffer.ToString();
        }
    }
}