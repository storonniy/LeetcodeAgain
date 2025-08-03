using NUnit.Framework;

namespace Leetcode.Easy;

public class PascalTriangle
{
    /// <summary>
    /// 118. Pascal's Triangle
    /// </summary>
    public IList<IList<int>> Generate(int numRows)
    {
        var result = new int[numRows][];
        for (var i = 1; i <= numRows; i++)
        {
            if (i == 1)
                result[0] = new[] { 1 };
            else if (i == 2)
                result[1] = new[] { 1, 1 };
            else
            {
                var row = new int[i];
                row[0] = 1;
                row[^1] = 1;
                result[i - 1] = row;
                var prevRow = result[i - 2];
                for (var j = 1; j < prevRow.Length; j++)
                {
                    var sum = prevRow[j - 1] + prevRow[j];
                    row[j] = sum;
                }
            }
        }
        return result;
    }
}

public class PascalTriangleTest
{
    [Test]
    public void Test()
    {
        var solution = new PascalTriangle();
        
        solution.Generate(5);
    }
}

