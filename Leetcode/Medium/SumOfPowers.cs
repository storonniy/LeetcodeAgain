namespace Leetcode.Medium;

public class SumOfPowers
{
    public int NumberOfWays(int n, int x) {
        const int mod = 1_000_000_007;
        var dp = new long[n + 1];
        dp[0] = 1;
        for (var i = 1; ; i++) {
            var number = Math.Pow(i, x);  
            if (number > n) break;
            for (var j = n; j >= number; j--) {
                dp[j] = (dp[j] + dp[j - (int)number]) % mod;
            }
        }
        return (int)dp[n];
    }
}