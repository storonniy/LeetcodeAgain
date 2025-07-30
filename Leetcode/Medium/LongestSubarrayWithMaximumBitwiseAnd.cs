using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class LongestSubarrayWithMaximumBitwiseAnd
{
    /// <summary>
    /// 2419. Longest Subarray With Maximum Bitwise AND
    /// </summary>
    /*
     * Отыскать максимальную длину непрерывной последовательности,
     * для которой AND всех элементов максимальный для исходного набора чисел
     * Решение: для любого x, y ∈ nums таких, что x ≠ y,  x & y < max(x, y)
     * => требуется отыскать подпоследовательность максимальной длины из
     * максимальных элементов исходного массива
     */
    public int LongestSubarray(int[] nums)
    {
        var max = 0;
        var maxLength = 0;
        var length = 0;
        foreach (var x in nums)
        {
            if (x > max)
            {
                max = x;
                length = 0;
                maxLength = 0;
            }
            if (x == max)
                length++;
            else
                length = 0;
            maxLength = Math.Max(maxLength, length);
        }

        return maxLength;
    }
}

class LongestSubarrayWithMaximumBitwiseAndTest
{
    [TestCase(new[] { 1, 2, 3, 3, 2, 2 }, 2)]
    [TestCase(new[] { 1, 2, 3, 4 }, 1)]
    public void Test(int[] nums, int expected)
    {
        var solution = new LongestSubarrayWithMaximumBitwiseAnd();

        solution.LongestSubarray(nums).Should().Be(expected);
    }
}