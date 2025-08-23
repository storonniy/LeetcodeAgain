using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Hard;

public class ThreeRectangles
{
    /// <summary>
    /// 3197. Find the Minimum Area to Cover All Ones II
    /// </summary>
    public int MinimumSum(int[][] grid)
    {
        var area = int.MaxValue;
        for (var rotation = 0; rotation < 4; rotation++)
        {
            var height = grid.Length;
            var width = grid[0].Length;
            for (var y = 1; y < height; y++)
            {
                var leftRectangle = grid.Take(y).ToArray();
                var leftArea = MinimumArea(leftRectangle);
                for (var x = 1; x < width; x++)
                {
                    var topRectangle = grid.Skip(y).Select(r => r.Take(x).ToArray()).ToArray();
                    var topArea = MinimumArea(topRectangle);
                    var bottomRectangle = grid.Skip(y).Select(r => r.Skip(x).ToArray()).ToArray();
                    var bottomArea = MinimumArea(bottomRectangle);
                    area = Math.Min(area, leftArea + topArea + bottomArea);
                }

                for (var right = y + 1; right < height; right++)
                {
                    var middleHorizontalRectangle = grid.Skip(y).Take(right - y).ToArray();
                    var rightRectangle = grid.Skip(right).ToArray();
                    var middleArea = MinimumArea(middleHorizontalRectangle);
                    var rightArea = MinimumArea(rightRectangle);
                    area = Math.Min(area, leftArea + middleArea + rightArea);
                }
            }

            grid = Transpose(grid);
        }

        return area;
    }

    int[][] Transpose(int[][] grid)
    {
        var height = grid.Length;
        var width = grid[0].Length;
        var result = new int[width][];
        for (var x = 0; x < width; x++)
            result[x] = new int[height];
        for (var y = 0; y < height; y++)
        for (var x = 0; x < width; x++)
            result[x][height - 1 - y] = grid[y][x];

        return result;
    }

    private int MinimumArea(int[][] grid)
    {
        if (grid.Length == 0 || grid[0].Length == 0) return 0;
        var height = grid.Length;
        var width = grid[0].Length;
        var left = int.MaxValue;
        var right = int.MinValue;
        var top = int.MaxValue;
        var bottom = int.MinValue;
        var found = false;
        for (var y = 0; y < height; y++)
        for (var x = 0; x < width; x++)
        {
            if (grid[y][x] != 1)
                continue;
            found = true;
            left = Math.Min(left, x);
            right = Math.Max(right, x);
            top = Math.Min(top, y);
            bottom = Math.Max(bottom, y);
        }

        return found ? (right - left + 1) * (bottom - top + 1) : 0;
    }
}

public class RectangleAreaTest
{
    static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData(new[] { new[] { 1, 0, 1, 0 }, new[] { 0, 1, 0, 1 } }, 5);
        yield return new TestCaseData(new[] { new[] { 1, 0, 1 }, new[] { 1, 1, 1 } }, 5);
        yield return new TestCaseData(new[]
        {
            new[] { 0, 0, 0, 0, 0 },
            new[] { 0, 0, 0, 0, 0 },
            new[] { 0, 0, 0, 0, 0 },
            new[] { 0, 1, 1, 0, 1 },
            new[] { 0, 0, 0, 1, 0 }
        }, 4);
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test(int[][] grid, int expected)
    {
        var solution = new ThreeRectangles();
        solution.MinimumSum(grid).Should().Be(expected);
    }
}