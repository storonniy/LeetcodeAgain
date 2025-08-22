using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class RectangleArea
{
    /// <summary>
    /// 3195. Find the Minimum Area to Cover All Ones I
    /// </summary>
    /*
     * Дали бинарную матрицу, найти минимальную площадь с максимальной суммой
     * Все проще, чем кажется: максимальная сумма, когда взяли все единицы матрицы
     * минимальная площадь - когда не взяли крайние строки и столбцы из нулей
     * => находим левую, правую, верхнюю, нижнюю границы, где 1 еще встречается
     */
    public int MinimumArea(int[][] grid)
    {
        var height = grid.Length;
        var width = grid[0].Length;
        var left = width - 1;
        var right = 0;
        var top = height - 1;
        var bottom = 0;
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
        yield return new TestCaseData(new[] { new[] { 1, 0 }, new[] { 0, 0 } }, 1);
        yield return new TestCaseData(new[] { new[] { 0, 1, 0 }, new[] { 1, 0, 1 } }, 6);
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test(int[][] grid, int expected)
    {
        var solution = new RectangleArea();
        solution.MinimumArea(grid).Should().Be(expected);
    }
}