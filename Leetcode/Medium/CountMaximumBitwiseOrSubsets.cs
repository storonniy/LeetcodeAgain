using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class CountMaximumBitwiseOrSubsets
{
    /// <summary>
    /// 2044. Count Number of Maximum Bitwise-OR Subsets
    /// </summary>
    /*
     * Есть числа, для максимально достижимого значения or среди них
     * найтить количество подмножеств с таким or: каждое число считать уникальным:
     * для любого x из nums x != x, если xi != xi
     * Решение для ебиков:
     * максимальное or - это or для всеъ элементов
     * беремс все уникальные числа, считаем, сколько подмножеств дают or = maxOr
     */
    public int CountMaxOrSubsets(int[] nums)
    {
        var or = nums.Aggregate((x, y) => x | y);
        var dict = nums
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());
        var distinct = dict.Keys.ToArray();
        var count = 0;
        for (var i = 1; i <= 1 << distinct.Length; i++)
            count += CountSubsets(dict, distinct, i, or);

        return count;
    }

    int CountSubsets(Dictionary<int, int> frequency, int[] nums, int state, int max)
    {
        var or = 0;
        var count = 1;
        for (var i = 0; i < nums.Length; i++)
        {
            if ((state & (1 << i)) == 0)
                continue;
            or |= nums[i];
            count *= (1 << frequency[nums[i]]) - 1;
        }

        return or == max ? count : 0;
    }
}

public class CountMaximumBitwiseOrSubsetsTest
{
    [TestCase(new[] { 3, 1 }, 2)]
    [TestCase(new[] { 2, 2, 2 }, 7)]
    [TestCase(new[] { 3, 2, 1, 5 }, 6)]
    public void Test(int[] nums, int expected)
    {
        var code = new CountMaximumBitwiseOrSubsets();

        code.CountMaxOrSubsets(nums).Should().Be(expected);
    }
}