using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class Sudoku
{
    public bool IsValidSudoku(char[][] board)
    {
        for (var y = 0; y < 9; y++)
        {
            var row = new HashSet<int>(9);
            var column = new HashSet<int>(9);
            for (var x = 0; x < 9; x++)
            {
                if (char.IsDigit(board[y][x]) && !row.Add(board[y][x] - '0'))
                    return false;

                if (char.IsDigit(board[x][y]) && !column.Add(board[x][y] - '0'))
                    return false;
            }
        }

        for (var y = 0; y < 9; y += 3)
        {
            for (var x = 0; x < 9; x += 3)
            {
                var square = new HashSet<int>(9);
                for (var yi = 0; yi < 3; yi++)
                for (var xi = 0; xi < 3; xi++)
                {
                    if (!char.IsDigit(board[y + yi][x + xi]))
                        continue;
                    if (!square.Add(board[y + yi][x + xi] - '0'))
                        return false;
                }
            }
        }

        return true;
    }
}

public class SudokuTest
{
    static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData(
            new[]
            {
                new[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            }
            , true);
        yield return new TestCaseData(
            new[]
            {
                new[] { '.', '.', '4', '.', '.', '.', '6', '3', '.' },
                new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new[] { '5', '.', '.', '.', '.', '.', '.', '9', '.' },
                new[] { '.', '.', '.', '5', '6', '.', '.', '.', '.' },
                new[] { '4', '.', '3', '.', '.', '.', '.', '.', '1' },
                new[] { '.', '.', '.', '7', '.', '.', '.', '.', '.' },
                new[] { '.', '.', '.', '5', '.', '.', '.', '.', '.' },
                new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' }
            }
            , false);
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test(char[][] grid, bool expected)
    {
        var solution = new Sudoku();

        solution.IsValidSudoku(grid).Should().Be(expected);
    }
}