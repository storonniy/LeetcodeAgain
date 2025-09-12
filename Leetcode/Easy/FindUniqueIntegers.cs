namespace Leetcode.Easy;

public class FindUniqueIntegers
{
    public int[] SumZero(int n)
    {
        var result = new int[n];
        for (var i = 0; i < n / 2; i++)
        {
            result[i] = -n - i;
            result[n - 1 - i] = Math.Abs(result[i]);
        }

        return result;
    }
}