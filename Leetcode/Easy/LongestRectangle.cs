using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Easy;

public class LongestRectangle
{
    public int AreaOfMaxDiagonal(int[][] dimensions)
    {
        var maxDiagonal = 0;
        var maxArea = 0;
        foreach (var r in dimensions)
        {
            var a = r[0];
            var b = r[1];
            var diagonal = a * a + b * b;
            var area = a * b;
            if (diagonal > maxDiagonal)
            {
                maxDiagonal = diagonal;
                maxArea = area;
            }

            if (diagonal == maxDiagonal && area > maxArea)
                maxArea = area;
        }
        return maxArea;
    }
}

public class LongestRectangleTest
{    static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData(new[]
        {
            new[] {6,5 }, new[] {8, 6 }, new[] {2,10},
             new[] {8,1},
             new[] {9,2},
             new[] {3,5},
             new[] {3,5}
        }, 20);
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test(int[][] dimensions, int expected)
    {
        var solution = new LongestRectangle();
        
        solution.AreaOfMaxDiagonal(dimensions).Should().Be(expected);
    }
}
