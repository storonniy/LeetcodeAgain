namespace Leetcode.Medium;

public class RangeProductPowerQueries
{
    public int[] ProductQueries(int n, int[][] queries)
    {
        var powers = new List<int>(32);
        var product = 1;
        while (n > 0)
        {
            if (n % 2 == 0)
                powers.Add(product);
            product *= 2;
            n /= 2;
        }
        var result = new int[queries.Length];
        for (var i = 0; i < queries.Length; i++)
        {
            var current = 1L;
            var start = queries[i][0];
            var end = queries[i][1];
            for (var j = start; j <= end; j++)
                current = (current * powers[j]) % 1000000007;
            result[i] = (int)current;
        }

        return result;
    }
}