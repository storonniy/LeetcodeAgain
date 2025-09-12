using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class PlacePeople
{
    public int NumberOfPairs(int[][] points)
    {
        points = points
            .OrderBy(x => x[0])
            .ThenByDescending(x => x[1])
            .ToArray();

        var count = 0;
        for (var i = 0; i < points.Length - 1; i++)
        {
            var top = points[i][1];
            var bottom = int.MinValue;
            for (var j = i + 1; j < points.Length; j++)
            {
                var y = points[j][1];
                if (bottom >= y || y > top)
                    continue;
                count++;
                bottom = y;
                if (top == bottom)
                    break;
            }
        }

        return count;
    }
}


public class PlacePeopleTest
{
    static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData(
            new[]
            {
                new[] { 0,1},
                new[] {1, 3 },
                new[] {6, 1 },
            },
            2
        );   
        yield return new TestCaseData(
            new[]
            {
                new[] { 3,1},
                new[] {1,3 },
                new[] {1,1 },
            },
            2
        );
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test(int[][] points, int expected)
    {
        var solution = new PlacePeople();

        solution.NumberOfPairs(points).Should().Be(expected);
    }
}