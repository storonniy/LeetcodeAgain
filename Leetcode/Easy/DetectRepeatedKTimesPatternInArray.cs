using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Easy;

public class DetectRepeatedKTimesPatternInArray
{
    public bool ContainsPattern(int[] nums, int length, int k)
    {
        if (nums.Length < length * k)
            return false;
        var currentCount = 0;
        var maxLength = 0;
        var pattern = new int[length];
        for (var j = 0; j < length; j++)
            pattern[j] = nums[j];
        var start = 0;
        for (var i = 0; i < nums.Length - length + 1; i++)
        {
            if (Enumerable.Range(0, length).Any(j => nums[i + j] != pattern[j]))
            {
                currentCount = 1;
                start++;
                for (var j = 0; j < length; j++)
                    pattern[j] = nums[start + j];
            }
            else
            {
                currentCount++;
                maxLength = Math.Max(maxLength, currentCount);
                i += length - 1;
            }
        }

        return maxLength >= k;
    }
}

public class DetectRepeatedKTimesPatternInArrayTest
{
    [TestCase(new[] { 2,1,1,2,2,1,2,2,1,2 }, 1, 3, false)]
    [TestCase(new[] { 1,2,2,2,1,1,2,2,2 }, 1, 3, true)]
    [TestCase(new[] { 2, 2, 1, 2, 2, 1, 1, 1, 2, 1 }, 2, 2, false)]
    [TestCase(new[] { 2, 2, 2, 2 }, 2, 3, false)]
    [TestCase(new[] { 1, 2, 4, 4, 4, 4 }, 1, 3, true)]
    [TestCase(new[] { 2, 2 }, 1, 2, true)]
    [TestCase(new[] { 1, 2, 1, 2, 1, 3 }, 2, 3, false)]
    [TestCase(new[] { 1, 2, 1, 2, 1, 1, 1, 3 }, 2, 2, true)]
    [TestCase(new[] { 1, 2, 4, 4, 4, 4 }, 1, 3, true)]
    public void Test(int[] nums, int length, int k, bool expected)
    {
        var solution = new DetectRepeatedKTimesPatternInArray();

        solution.ContainsPattern(nums, length, k).Should().Be(expected);
    }
}