using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Easy;

public class MaximumNumber
{
    public int Maximum69Number (int num)
    {
        var power = 1;
        var lastPower = -1;
        var x = num;
        for (var i = 0; i < 5 && x > 0; i++)
        {
            var digit = x % 10;
            x /= 10;
            if (digit == 6)
                lastPower = power;
            power *= 10;
        }

        if (lastPower == -1)
            return num;
        return num + 3 * lastPower;
    }
}

public class MaximumNumberTest
{
    [TestCase(6999, 9999)]
    [TestCase(9669, 9969)]
    public void Test(int num, int expected)
    {
        var solution = new MaximumNumber();
        
        solution.Maximum69Number(num).Should().Be(expected);
    }
}
