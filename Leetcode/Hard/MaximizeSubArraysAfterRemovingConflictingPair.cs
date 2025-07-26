using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Hard;

public class MaximizeSubArraysAfterRemovingConflictingPair
{
    /// <summary>
    /// 3480. Maximize Subarrays After Removing One Conflicting Pair
    /// </summary>
    /*
     * Есть массив чиселок от 0 до n
     * Есть массив пар этих чисел, которые конфликтуют между собой и не могут быть в одном подмассиве
     * Требуется удалить одну пару конфликтующих
     * И посчитать, какое максимальное число неконфликтных подмассивов получится
     * Решение:
     * Считаем, сколько всего будет подмассивов
     * И сколько конфликтующих
     * Выпиливаем наиболее конфликтную пару
     */
    public long MaxSubarrays(int n, int[][] conflictingPairs)
    {
        foreach (var pair in conflictingPairs)
        {
            if (pair[1] > pair[0])
                continue;
            (pair[0], pair[1]) = (pair[1], pair[0]);
        }

        Array.Sort(conflictingPairs, (a, b) => a[1] - b[1]);
        var max1 = 0L;
        var max2 = 0L;
        var gain = 0L;
        var maxGain = 0L;
        var totalOccupied = 0L;
        for (var i = 0; i < conflictingPairs.Length; i++)
        {
            var start = conflictingPairs[i][0];
            var basic = n + 1 - conflictingPairs[i][1];
            if (i < conflictingPairs.Length - 1)
                basic = conflictingPairs[i + 1][1] - conflictingPairs[i][1];

            if (start > max1)
            {
                max2 = max1;
                max1 = start;
                gain = 0;
            }
            else if (start > max2)
                max2 = start;

            gain += (max1 - max2) * basic;
            totalOccupied += max1 * basic;
            maxGain = Math.Max(maxGain, gain);
        }

        var total = (long)n * (n + 1) / 2;
        return total - totalOccupied + maxGain;
    }
}

public class MaximizeSubArraysAfterRemovingConflictingPairTest
{
    static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData(4, new[] { new[] { 2, 3 }, new[] { 1, 4 } }, 9);
        yield return new TestCaseData(100000, new[] { new[] { 50000,50001 }, new[] { 99999,100000 } }, 4999950001);
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void Test(int n, int[][] conflictingPairs, long expected)
    {
        var solution = new MaximizeSubArraysAfterRemovingConflictingPair();

        solution.MaxSubarrays(n, conflictingPairs).Should().Be(expected);
    }
}