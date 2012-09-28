namespace CleanCode.Sudoku
{
    public interface ISudokuLegalMoveVerifier
    {
        bool IsMoveLegal(int i, int j, int val, int[,] cells);
    }

    public class SudokuLegalMoveVerifier : ISudokuLegalMoveVerifier
    {
        public bool IsMoveLegal(int i, int j, int val, int[,] cells)
        {
            for (var k = 0; k < 9; ++k)
                // row
                if (val == cells[k,j])
                    return false;

            for (var k = 0; k < 9; ++k)
                // col
                if (val == cells[i,k])
                    return false;

            var boxRowOffset = (i / 3) * 3;
            var boxColOffset = (j / 3) * 3;
            for (var k = 0; k < 3; ++k)
                // box
                for (var m = 0; m < 3; ++m)
                    if (val == cells[boxRowOffset + k,boxColOffset + m])
                        return false;

            return true; // no violations, so it's legal
        }
    }
}