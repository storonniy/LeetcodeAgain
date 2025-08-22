using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class SubMatrix
{
    public int CountSquares(int[][] matrix)
    {
        var height = matrix.Length;
        var width = matrix[0].Length;
        var count = 0;
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                if (matrix[y][x] == 1 && y > 0 && x > 0)
                {
                    matrix[y][x] = Math.Min(
                        matrix[y - 1][x - 1],
                        Math.Min(matrix[y - 1][x], matrix[y][x - 1])
                    ) + 1;
                }

                count += matrix[y][x];
            }
        }

        return count;
    }
}

public class SubMatrixTest
{
    [Test]
    public void Test()
    {
        var solution = new SubMatrix();

        solution.CountSquares(new[]
        {
            new[] { 0, 1, 1, 1 },
            new[] { 1, 1, 1, 1 },
            new[] { 0, 1, 1, 1 },
        }).Should().Be(15);
    }
}