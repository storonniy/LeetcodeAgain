namespace Leetcode.Medium;

public class SmallestSubarraysWithMaximumBitwiseOr
{
    /// <summary>
    /// 2411. Smallest Subarrays With Maximum Bitwise OR
    /// </summary>
    public int[] SmallestSubarrays(int[] nums)
    {
        var res = new int[nums.Length];
        var last = new int[32];
        Array.Fill(last, -1);
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            for (var j = 0; j < 32; j++)
                if (((nums[i] >> j) & 1) == 1)
                    last[j] = i;
            var max = 1;
            for (var k = 0; k < 32; k++)
                if (last[k] != -1)
                    max = Math.Max(max, last[k] - i + 1);
            res[i] = max;
        }

        return res;
    }
}