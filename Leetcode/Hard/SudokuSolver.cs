using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Hard;

public class SudokuSolver1
{
    public void SolveSudoku(char[][] board)
    {
        Backtrack(board);
    }

    private bool Backtrack(char[][] board)
    {
        for (var y = 0; y < 9; y++)
        for (var x = 0; x < 9; x++)
        {
            if (board[y][x] != '.')
                continue;
            for (var value = '1'; value <= '9'; value++)
            {
                if (!IsValidSudoku(board, y, x, value))
                    continue;
                board[y][x] = value;
                if (Backtrack(board))
                    return true;
                board[y][x] = '.';
            }

            return false;
        }

        return true;
    }

    bool IsValidSudoku(char[][] board, int yi, int xi, char value)
    {
        for (var i = 0; i < 9; i++)
            if (board[yi][i] == value || board[i][xi] == value)
                return false;

        var br = yi / 3 * 3;
        var bc = xi / 3 * 3;
        for (var i = br; i < br + 3; i++)
        {
            for (var j = bc; j < bc + 3; j++)
                if (board[i][j] == value)
                    return false;
        }

        return true;
    }
}

public class SudokuSolverTest
{
    static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData(
            new[]
            {
                new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new[] { '.', '9', '.', '.', '1', '.', '.', '3', '.' },
                new[] { '.', '.', '6', '.', '2', '.', '7', '.', '.' },
                new[] { '.', '.', '.', '3', '.', '4', '.', '.', '.' },
                new[] { '2', '1', '.', '.', '.', '.', '.', '9', '8' },
                new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new[] { '.', '.', '2', '5', '.', '6', '4', '.', '.' },
                new[] { '.', '8', '.', '.', '.', '.', '.', '1', '.' },
                new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' }
            },
            new[]
            {
                new[] { '7', '2', '1', '8', '5', '3', '9', '4', '6' },
                new[] { '4', '9', '5', '6', '1', '7', '8', '3', '2' },
                new[] { '8', '3', '6', '4', '2', '9', '7', '5', '1' },
                new[] { '9', '6', '7', '3', '8', '4', '1', '2', '5' },
                new[] { '2', '1', '4', '7', '6', '5', '3', '9', '8' },
                new[] { '3', '5', '8', '2', '9', '1', '6', '7', '4' },
                new[] { '1', '7', '2', '5', '3', '6', '4', '8', '9' },
                new[] { '6', '8', '3', '9', '4', '2', '5', '1', '7' },
                new[] { '5', '4', '9', '1', '7', '8', '2', '6', '3' }
            }
        );
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test(char[][] grid, char[][] expected)
    {
        var solution = new SudokuSolver1();

        solution.SolveSudoku(grid);
        grid.Should().BeEquivalentTo(expected);
    }
}