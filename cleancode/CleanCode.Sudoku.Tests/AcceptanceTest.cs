using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace CleanCode.Sudoku.Tests
{
    [TestFixture]
    public class AcceptanceTest
    {
  
    [Test]
	public void easyProblem() {
		check(SudokuExamples.EASY_PROBLEM, SudokuExamples.EASY_SOLUTION);
	}

	[Test]
	public void hardProblem() {
		check(SudokuExamples.HARD_PROBLEM, SudokuExamples.HARD_SOLUTION);
	}

    [Test]
	public void impossible()
    {
        var sudoku = new Sudoku(new SudokuLegalMoveVerifier());
        var problemParser = new SudokuProblemParser();
		int[,] problemGrid = problemParser.parseProblem(SudokuExamples.NOT_SOLVABLE_PROBLEM);
		int[,] actualSolution = sudoku.solve(problemGrid);
		Assert.IsNull(actualSolution);
	}

	private void check(String problem, String solution) {
	    var sudoku = new Sudoku(new SudokuLegalMoveVerifier());
	    var problemParser = new SudokuProblemParser();
	    int[,] solutionGrid = problemParser.parseProblem(solution);
		int[,] problemGrid = problemParser.parseProblem(problem);
		int[,] actualSolution = sudoku.solve(problemGrid);
	    var prettyPrinter = new SudokuPrettyPrinter();
		Assert.That(prettyPrinter.prettyPrint(actualSolution) , Is.EqualTo(prettyPrinter.prettyPrint(solutionGrid) ));
	}
    }
}
