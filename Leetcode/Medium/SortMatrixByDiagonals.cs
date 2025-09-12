using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class SortMatrixByDiagonals
{
    public int[][] SortMatrix(int[][] grid)
    {
        var n = grid.Length;
        for (var y = 0; y < n; y++)
        {
            var diagonal = new int[n - y];
            for (var d = 0; d < n - y; d++)
            {
                var value = grid[y + d][d];
                diagonal[d] = value;
            }

            Array.Sort(diagonal, (a, b) => -a.CompareTo(b));
            for (var i = 0; i < diagonal.Length; i++)
                grid[y + i][i] = diagonal[i];
        }
// -1  2  1
//  0  3 -5
//  0  2  1
        for (var x = 1; x < n; x++)
        {
            var diagonal = new int[n - x];
            for (var y = 0; y < n - x; y++)
            {
                var value = grid[y][x + y];
                diagonal[y] = value;
            }
            Array.Sort(diagonal);
            for (var i = 0; i < diagonal.Length; i++)
                grid[i][x + i] = diagonal[i];
        }

        return grid;
    }
}

public class SortMatrixByDiagonalsTest
{
    static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData(new[]
        {
            new[] {1,7,3 }, new[] {9,8,2}, new[] {4,5,6},
        },
        new[]
        {
            new[] {8,2,3 }, new[] {9,6,7}, new[] {4,5,1}
        });      
        yield return new TestCaseData(new[]
        {
            new[] {-1,2,1 }, new[] {0,3,-5}, new[] {0,2,1},
        },
        new[]
        {
            new[] {3,-5,1}, new[] {2,1,2}, new[] {0,0,-1}
        });
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test(int[][] grid, int[][] expected)
    {
        var solution = new SortMatrixByDiagonals();
        
        solution.SortMatrix(grid).Should().BeEquivalentTo(expected);
    }
}

