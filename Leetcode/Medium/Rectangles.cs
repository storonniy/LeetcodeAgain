namespace Leetcode.Medium;

public class Rectangles
{
    /// <summary>
    /// 1504. Count Submatrices With All Ones
    /// </summary>
    public int NumSubmat(int[][] mat)
    {
        var count = 0;
        var height = mat.Length;
        var width = mat[0].Length;
        var meow = new int[width];
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
                meow[x] = mat[y][x] == 0 ? 0 : meow[x] + 1;
            for (var x = 0; x < width; x++)
            {
                var minHeight = int.MaxValue;
                for (var i = x; i >= 0 && meow[i] > 0; i--)
                {
                    if (meow[i] < minHeight)
                        minHeight = meow[i];
                    count += minHeight;
                }
            }
        }

        return count;
    }
}