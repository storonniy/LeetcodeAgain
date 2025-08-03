using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Hard;

public class MaximumFruitsHarvestForSteps
{
    /// <summary>
    /// 2106. Maximum Fruits Harvested After at Most K Steps
    /// </summary>
    /*
     * Дано одномерное поле с фруктами [ [position, amount], ...]
     * дана стартовая позиция start и количество шагов k
     * Найти максимальный урожай
     * Решение: в тупую - k = 2 * r + l или k = r + 2 * l
     * т е сходили направо, а потом сымитировали, что сначала сделали l шагов влево
     * то есть если идем 1 раз налево, то конечная точка справа уменьшается на 2 шага
     */
    public int MaxTotalFruits(int[][] fruits, int start, int k)
    {
        var dict = new Dictionary<int, int>();
        foreach (var x in fruits)
        {
            var position = x[0];
            var amount = x[1];
            if (position > start + k || position < start - k)
                continue;
            dict[position] = amount;
        }

        var sum1 = 0;
        for (var i = 0; i <= k; i++)
            sum1 += dict.GetValueOrDefault(start + i, 0);

        var max1 = sum1;
        var right = start + k;
        for (var l = 1; l <= k; l++)
        {
            sum1 -= dict.GetValueOrDefault(right, 0);
            sum1 -= dict.GetValueOrDefault(right - 1, 0);
            right -= 2;
            sum1 += dict.GetValueOrDefault(start - l, 0);
            max1 = Math.Max(max1, sum1);
        }

        var sum2 = 0;
        for (var i = 0; i <= k; i++)
            sum2 += dict.GetValueOrDefault(start - i, 0);
        var max2 = sum2;

        var left = start - k;
        for (var r = 1; r <= k; r++)
        {
            sum2 -= dict.GetValueOrDefault(left, 0);
            sum2 -= dict.GetValueOrDefault(left + 1, 0);
            left += 2;
            sum2 += dict.GetValueOrDefault(start + r, 0);
            max2 = Math.Max(max2, sum2);
        }

        return Math.Max(max1, max2);
    }
}

public class MaximumFruitsHarvestForStepsTest
{
    static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData(new[] { new[] { 2, 8 }, new[] { 6, 3 }, new[] { 8, 6 } }, 5, 4, 9);
        yield return new TestCaseData(new[]
            {
                new[] { 0, 9 },
                new[] { 4, 1 },
                new[] { 5, 7 },
                new[] { 6, 2 },
                new[] { 7, 4 },
                new[] { 10, 9 },
            },
            5,
            4,
            14);
        yield return new TestCaseData(new[]
            {
                new[] { 0, 7 },
                new[] { 7, 4 },
                new[] { 9, 10 },
                new[] { 12, 6 },
                new[] { 14, 8 },
                new[] { 16, 5 },
                new[] { 17, 8 },
                new[] { 19, 4 },
                new[] { 20, 1 },
                new[] { 21, 3 },
                new[] { 24, 3 },
                new[] { 25, 3 },
                new[] { 26, 1 },
                new[] { 28, 10 },
                new[] { 30, 9 },
                new[] { 31, 6 },
                new[] { 32, 1 },
                new[] { 37, 5 },
                new[] { 40, 9 }
            },
            21,
            30,
            71);
        yield return new TestCaseData(new[]
            {
                new[] { 1, 9 },
                new[] { 5, 2 },
                new[] { 8, 4 },
                new[] { 12, 4 },
                new[] { 13, 5 },
                new[] { 14, 5 },
                new[] { 15, 3 },
                new[] { 16, 4 },
                new[] { 19, 9 },
                new[] { 25, 8 },
                new[] { 27, 5 },
                new[] { 29, 9 },
                new[] { 31, 1 },
                new[] { 35, 8 },
                new[] { 37, 2 }
            },
            31,
            2,
            10);
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void Test(int[][] fruits, int start, int k, int expected)
    {
        var solution = new MaximumFruitsHarvestForSteps();

        solution.MaxTotalFruits(fruits, start, k).Should().Be(expected);
    }
}