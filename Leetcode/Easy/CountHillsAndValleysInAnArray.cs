using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Easy;

public class CountHillsAndValleysInAnArray
{
    /// <summary>
    /// 2210. Count Hills and Valleys in an Array
    /// </summary>
    /*
     * на i-м месте Hill - если ближайшие неравные соседи слева и справа ниже
     * Valley - наоборот
     * Сколько всего локальных минимумов и максимумов
     * Решение: для любого i смотрим на соседа слева
     * если выше или ниже nums[i], то ищем ближайшего неравного справа
     * смотрим на разницу высоты слева и справа
     */
    public int CountHillValley(int[] nums)
    {
        var left = 0;
        var count = 0;
        for (var i = 1; i < nums.Length - 1; i++)
        {
            if (nums[i] == nums[i - 1]) 
                continue;
            var p = i;
            while (p < nums.Length && nums[p] == nums[i])
                p++;
            if (p == nums.Length)
                continue;
            var dl = nums[i] - nums[i - 1];
            var dr = nums[i] - nums[p];
            if ((dl > 0 && dr > 0) || (dl < 0 && dr < 0))
                count++;
            i = p - 1;
        }

        return count;
    }
}

public class CountHillValleyTest
{
    [TestCase(
        new[] { 85, 52, 89, 81, 48, 8, 18, 12, 88, 20, 70, 100, 67, 42, 12, 95, 57, 8, 41, 82, 37, 44, 47, 18, 46 },
        15)]
    [TestCase(new[] { 2, 4, 1, 1, 6, 5 }, 3)]
    [TestCase(new[] { 6, 6, 5, 5, 4, 1 }, 0)]
    public void Test(int[] nums, int expected)
    {
        var solution = new CountHillsAndValleysInAnArray();

        solution.CountHillValley(nums).Should().Be(expected);
    }
}