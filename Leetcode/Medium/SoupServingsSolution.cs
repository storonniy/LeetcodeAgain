namespace Leetcode.Medium;

public class SoupServingsSolution
{
    public double SoupServings(int n)
    {
        if (n > 4800)
            return 1.0;

        var dp = new double[n + 1][];
        for (var i = 0; i <= n; i++)
        {
            dp[i] = new double[n + 1];
            for (var j = 0; j <= n; j++)
                dp[i][j] = -1;
        }

        return Find(n, n, dp);
    }

    private double Find(int a, int b, double[][] dp)
    {
        if (a <= 0 && b > 0)
            return 1.0;

        if (a == 0 && b == 0)
            return 0.5;

        if (a > 0 && b <= 0)
            return 0.0;

        if (a <= 0 && b <= 0)
            return 0.5;

        if (dp[a][b] != -1)
            return dp[a][b];

        var x = 0.25 * Find(a - 100, b, dp);
        var y = 0.25 * Find(a - 75, b - 25, dp);
        var z = 0.25 * Find(a - 50, b - 50, dp);
        var w = 0.25 * Find(a - 25, b - 75, dp);

        return dp[a][b] = x + y + z + w;
    }
}