namespace Leetcode.Easy;

public class NonZeroIntegers
{
    public int[] GetNoZeroIntegers(int n)
    {
        for (var i = 1; i < n; i++)
        {
            if (HasZero(i) || HasZero(n - i))
                continue;
            return new[] { i, n - i };
        }

        return Array.Empty<int>();
    }

    private bool HasZero(int x)
    {
        while (x > 0)
        {
            if (x % 10 == 0)
                return true;
            x /= 10;
        }

        return false;
    }
}