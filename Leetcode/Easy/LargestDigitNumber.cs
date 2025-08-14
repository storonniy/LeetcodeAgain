using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Easy;

public class LargestDigitNumber
{
    /// <summary>
    /// 2264. Largest 3-Same-Digit Number in String
    /// </summary>
    public string LargestGoodInteger(string num)
    {
        var max = '\0';
        for (var i = 0; i < num.Length - 2; i++)
        {
            var a = num[i];
            var b = num[i + 1];
            var c = num[i + 2];
            if (a == b && b == c && a > max)
                max = a;
        }
        return max == '\0' ? string.Empty : new string(max, 3);
    }
}

public class LargestDigitNumberTest
{
    [TestCase("6777133339", "777")]
    [TestCase("2300019", "000")]
    [TestCase("42352338", "")]
    public void Test(string num, string expected)
    {
        var solution = new LargestDigitNumber();
        
        solution.LargestGoodInteger(num).Should().Be(expected);
    }
}
