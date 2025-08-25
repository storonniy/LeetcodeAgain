using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class MatrixTraverse
{
    /// <summary>
    /// 498. Diagonal Traverse
    /// </summary>
    /*
     * пройти по диагонали матрицу [m x n] змейкой
     */
    public int[] FindDiagonalOrder(int[][] matrix)
    {
        var height = matrix.Length;
        var width = matrix[0].Length;
        var order = new List<int>(width * height);
        for (var x = 0; x < width; x++)
        {
            var diagonal = new List<int>(height);
            for (var y = 0; y < height; y++)
            {
                if (x - y < 0)
                    break;
                diagonal.Add(matrix[y][x - y]);
            }

            if (x % 2 == 0)
                diagonal.Reverse();
            order.AddRange(diagonal);
        }
        
        for (var y = 1; y < height; y++)
        {
            var diagonal = new List<int>(height);
            for (var x = 0; x < height; x++)
            {
                if (y + x >= height || width - 1 - x < 0)
                    break;
                diagonal.Add(matrix[y + x][width - 1 - x]);

            }
            if (y % 2 + width % 2 == 1)
                diagonal.Reverse();
            order.AddRange(diagonal);
        }

        return order.ToArray();
    }
}



public class MatrixTraverseTest
{
    static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData(new[] { new[] { 2,5 }, new[] {8,4 }, new[] {0,-1}}, new[] {2,5,8,0,4,-1});
        yield return new TestCaseData(new[] { new[] { 1,2,3 }, new[] { 4, 5, 6 }, new[] {7, 8, 9} }, new[] {1,2,4,7,5,3,6,8,9});
        yield return new TestCaseData(new[] { new[] { 1,2 }, new[] { 3, 4 }}, new[] {1,2,3,4});
        yield return new TestCaseData(new[] { new[] { 3 }, new[] { 2 }}, new[] {3, 2});
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test(int[][] matrix, int[] expected)
    {
        var solution = new MatrixTraverse();
        
        solution.FindDiagonalOrder(matrix).Should().BeEquivalentTo(expected);
    }
}
