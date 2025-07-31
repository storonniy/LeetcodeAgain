using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class DistinctBitwiseOrSubarraysCount
{
    /// <summary>
    /// 898. Bitwise ORs of Subarrays
    /// </summary>
    public int SubarrayBitwiseORs(int[] arr)
    {
        var hashSet = new HashSet<int>();
        var current = new HashSet<int>();
        current.Add(0);
        foreach (var x in arr)
        {
            var sub = new HashSet<int>();
            foreach (var y in current)
                sub.Add(x | y);
            sub.Add(x);
            current = sub;
            foreach (var t in current)
                hashSet.Add(t);
        }

        return hashSet.Count;
    }
}

public class DistinctBitwiseOrSubarraysCountTest
{
    
    [TestCase(new[] {13,4,2}, 5)]
    [TestCase(new[] {1,1,2}, 3)]
    [TestCase(new[] {1,2,4}, 6)]
    public void Test(int[] arr, int expected)
    {
        var solution = new DistinctBitwiseOrSubarraysCount();

        solution.SubarrayBitwiseORs(arr).Should().Be(expected);
    }
}