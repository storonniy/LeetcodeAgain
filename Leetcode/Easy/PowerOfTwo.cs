using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Easy;

public class PowerOfTwo
{
    public bool IsPowerOfTwo(int n)
    {
        if (n != 1 && n % 2 == 1)
            return false;
        var x = Math.Log2(n);
        return Math.Abs(x - Math.Floor(x)) < 10e-5;
    }
}

public class PowerOfTwoTest
{
    [TestCase(16385, false)]
    [TestCase(1, true)]
    [TestCase(16, true)]
    [TestCase(3, false)]
    public void Test(int n, bool expected)
    {
        var solution = new PowerOfTwo();
        
        solution.IsPowerOfTwo(n).Should().Be(expected);
    }
}
