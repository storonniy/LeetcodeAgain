using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Easy;

public class PowerOfThree
{
    public bool IsPowerOfThree(int n) {
        var log = Math.Log(n, 3);
        var floor = Math.Ceiling(log);
        return Math.Abs(log - floor) < 10e-8;
    }
}

public class PowerOfThreeTest
{
    [TestCase(19682, false)]
    [TestCase(243, true)]
    [TestCase(45, false)]
    public void Test(int n, bool expected)
    {
        var solution = new PowerOfThree();
        
        solution.IsPowerOfThree(n).Should().Be(expected);
    }
}
