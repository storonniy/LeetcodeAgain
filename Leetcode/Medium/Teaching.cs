using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class Teaching
{
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
    {
        var min = int.MaxValue;
        var communication = new bool[friendships.Length];
        for (var i = 0; i < friendships.Length; i++)
        {
            var a = friendships[i][0];
            var b = friendships[i][1];
            var canSpeak = languages[a - 1].ToHashSet().Intersect(languages[b - 1]).Any();
            communication[i] = canSpeak;
        }

        for (var language = 1; language <= n; language++)
        {
            var taught = new HashSet<int>(n);

            var current = 0;
            for (var i = 0; i < friendships.Length; i++)
            {
                var a = friendships[i][0];
                var b = friendships[i][1];
                if (communication[i])
                    continue;
                if (!languages[a - 1].Contains(language) && taught.Add(a))
                {
                    current++;
                }

                if (!languages[b - 1].Contains(language) && taught.Add(b))
                {
                    current++;
                }

            }

            min = Math.Min(min, current);
        }

        return min;
    }
}

public class TeachingTest
{
    static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData(
            11,
            new[]
            {
                new[] { 3, 11, 5, 10, 1, 4, 9, 7, 2, 8, 6 }, new[] { 5, 10, 6, 4, 8, 7 }, new[] { 6, 11, 7, 9 },
                new[] { 11, 10, 4 }, new[] { 6, 2, 8, 4, 3 }, new[] { 9, 2, 8, 4, 6, 1, 5, 7, 3, 10 },
                new[] { 7, 5, 11, 1, 3, 4 }, new[] { 3, 4, 11, 10, 6, 2, 1, 7, 5, 8, 9 },
                new[] { 8, 6, 10, 2, 3, 1, 11, 5 }, new[] { 5, 11, 6, 4, 2 }
            },
            new[]
            {
                new[] { 7, 9 }, new[] { 3, 7 }, new[] { 3, 4 }, new[] { 2, 9 }, new[] { 1, 8 }, new[] { 5, 9 },
                new[] { 8, 9 }, new[] { 6, 9 }, new[] { 3, 5 }, new[] { 4, 5 }, new[] { 4, 9 }, new[] { 3, 6 },
                new[] { 1, 7 }, new[] { 1, 3 }, new[] { 2, 8 }, new[] { 2, 6 }, new[] { 5, 7 }, new[] { 4, 6 },
                new[] { 5, 8 }, new[] { 5, 6 }, new[] { 2, 7 }, new[] { 4, 8 }, new[] { 3, 8 }, new[] { 6, 8 },
                new[] { 2, 5 }, new[] { 1, 4 }, new[] { 1, 9 }, new[] { 1, 6 }, new[] { 6, 7 }
            },
            0
        );
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test(int n, int[][] languages, int[][] friendships, int expected)
    {
        var solution = new Teaching();
        solution.MinimumTeachings(n, languages, friendships).Should().Be(expected);
    }
}