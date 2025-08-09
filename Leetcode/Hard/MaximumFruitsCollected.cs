namespace Leetcode.Hard;

public class MaximumFruitsCollected
{
    public int MaxCollectedFruits(int[][] fruits)
    {
        var n = fruits.Length;
        var collected = 0;
        for (var i = 0; i < n; ++i)
            collected += fruits[i][i];

        collected += Dp(fruits);

        Transpose(fruits);

        collected += Dp(fruits);
        return collected;
    }

    private static void Transpose(int[][] fruits)
    {
        var n = fruits.Length;
        for (var i = 0; i < n; ++i)
        for (var j = 0; j < i; ++j)
            (fruits[j][i], fruits[i][j]) = (fruits[i][j], fruits[j][i]);
    }

    int Dp(int[][] fruits)
    {
        var n = fruits.Length;
        var prev = Enumerable.Repeat(int.MinValue, n).ToArray();
        var curr = new int[n];
        prev[n - 1] = fruits[0][n - 1];
        for (var i = 1; i < n - 1; ++i)
        {
            Array.Fill(curr, int.MinValue);
            for (var j = Math.Max(n - 1 - i, i + 1); j < n; ++j)
            {
                var best = prev[j];
                if (j - 1 >= 0)
                    best = Math.Max(best, prev[j - 1]);
                if (j + 1 < n)
                    best = Math.Max(best, prev[j + 1]);
                curr[j] = best + fruits[i][j];
            }

            (prev, curr) = (curr, prev);
        }

        return prev[n - 1];
    }
}