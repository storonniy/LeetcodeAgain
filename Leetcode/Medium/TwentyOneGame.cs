namespace Leetcode.Medium;

public class TwentyOneGame
{
    /// <summary>
    /// 837. New 21 Game
    /// </summary>
    public double New21Game(int p, int pointsToWin, int maxPointsPerRound)
    {
        var dp = new double[maxPointsPerRound];
        dp[0] = 1.0;
        var windowSum = 1.0;
        var result = 0.0;
        for (var i = 1; i <= p; i++)
        {
            var prob = windowSum / maxPointsPerRound;
            if (i < pointsToWin)
                windowSum += prob;
            else
                result += prob;
            if (i >= maxPointsPerRound)
                windowSum -= dp[i % maxPointsPerRound];
            dp[i % maxPointsPerRound] = prob;
        }

        return result;
    }
}