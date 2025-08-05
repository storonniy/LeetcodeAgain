using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Easy;

public class FruitsIntoBaskets
{
    /// <summary>
    /// 3477. Fruits Into Baskets II
    /// </summary>
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        var unplacedFruits = 0;
        foreach (var quantity in fruits)
        {
            var placed = false;
            for (var i = 0; i < baskets.Length; i++)
            {
                var capacity = baskets[i];
                if (capacity < quantity) 
                    continue;
                placed = true;
                baskets[i] = 0;
                break;
            }
            if (!placed) 
                unplacedFruits++;
        }
        return unplacedFruits;
    }
}

public class FruitsIntoBasketsTest
{
    [TestCase(new[] { 3, 6, 1 }, new[] { 6, 4, 7 }, 0)]
    [TestCase(new[] { 4, 2, 5 }, new[] { 3, 5, 4 }, 1)]
    public void Test(int[] fruits, int[] baskets, int expected)
    {
        var solution = new FruitsIntoBaskets();

        solution.NumOfUnplacedFruits(fruits, baskets).Should().Be(expected);
    }
}