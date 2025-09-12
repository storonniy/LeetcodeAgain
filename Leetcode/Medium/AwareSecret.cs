namespace Leetcode.Medium;

public class AwareSecret
{
    public class Solution
    {
        public int PeopleAwareOfSecret(int n, int delay, int forget)
        {
            const int mod = 1_000_000_007;
            if (n == 1) return 1;

            var dp = new long[n + 1];
            dp[1] = 1;
            var windowSum = 0L;

            for (var i = 2; i <= n; i++)
            {
                var enterIdx = i - delay;
                var exitIdx = i - forget;

                if (enterIdx >= 1)
                    windowSum = (windowSum + dp[enterIdx]) % mod;

                if (exitIdx >= 1)
                    windowSum = (windowSum - dp[exitIdx] + mod) % mod;
                dp[i] = windowSum;
            }

            var result = 0L;
            var start = Math.Max(1, n - forget + 1);
            for (var i = start; i <= n; i++)
                result = (result + dp[i]) % mod;

            return (int)result;
        }
    }
}