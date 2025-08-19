using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class ZeroFilledArray
{
    /// <summary>
    /// 2348. Number of Zero-Filled Subarrays
    /// </summary>
    /*
     * Найти все подпоследовательности нулей и найти количество всех комбинаций из подпоследовательностей нулей 
     */
    public long ZeroFilledSubarray(int[] nums)
    {
        var count = 0L;
        var length = 0;
        for (var i = 0; i < nums.Length; ++i)
        {
            if (nums[i] == 0)
                length++;
            if (nums[i] != 0 || i == nums.Length - 1)
            {
                count += (long)length * (length + 1) / 2;
                length = 0;
            }
        }

        return count;
    }

    public class ZeroFilledArrayTest
    {
        [TestCase(new[] { 0,12,0,12,0,-8,0,-18,0,-11,0}, 6)]
        [TestCase(new[] { 0,0,0,2,0,0}, 9)]
        [TestCase(new[] { 1,3,0,0,2,0,0,4}, 6)]
        public void Test(int[] nums, long expected)
        {
            var solution = new ZeroFilledArray();
            
            solution.ZeroFilledSubarray(nums).Should().Be(expected);
        }
    }

}