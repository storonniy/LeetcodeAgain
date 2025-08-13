using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Hard;

public class ReorderPowerOfTwo
{
    /// <summary>
    /// 869. Reordered Power of 2
    /// </summary>
    public bool ReorderedPowerOf2(int n)
    {
        var originalDigits = new int[10];
        while (n > 0)
        {
            originalDigits[n % 10]++;
            n /= 10;
        }

        for (var i = 0; i < 30; i++)
        {
            var digits = new int[10];
            var x = 1 << i;
            while (x > 0)
            {
                digits[x % 10]++;
                x /= 10;
            }

            if (Equals(digits, originalDigits))
                return true;
        }

        return false;
    }

    bool Equals(int[] x, int[] y)
    {
        for (var i = 0; i < 10; i++)
            if (x[i] != y[i])
                return false;
        return true;
    }
}

public class ReorderPowerOfTwoTest
{
    [TestCase(1, true)]
    [TestCase(10, false)]
    [TestCase(1042, true)]
    [TestCase(1023, false)]
    [TestCase(821, true)]
    public void Test(int n, bool expected)
    {
        var solution = new ReorderPowerOfTwo();
        
        solution.ReorderedPowerOf2(n).Should().Be(expected);
    }
}
