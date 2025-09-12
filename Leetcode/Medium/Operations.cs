namespace Leetcode.Medium;

public class Operations
{
    public int MakeTheIntegerZero(int num1, int num2)
    {
        var operations = 0;
        for (var i = 0L; i < 60; i++)
        {
            var value = num1 - i * num2;
            if (value < 0 || value < i)
                continue;
            var ones = CountBits(value);
            if (ones <= i)
                return (int)i;
        }

        return -1;
    }

    private int CountBits(long value)
    {
        var bitsCount = 0L;
        while (value > 0)
        {
            bitsCount += value & 1;
            value >>= 1;
        }
        return (int)bitsCount;
    }
}