using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class FruitIntoBaskets
{
    /// <summary>
    /// 904. Fruit Into Baskets
    /// </summary>
    /// Найти максимально длинный подмассив, для которого: для ∀ x ∈ fruits subsequence.Distinct ≤ 2
    public int TotalFruit(int[] fruits)
    {
        var frequency = new Dictionary<int, int>(fruits.Length);
        var left = 0;
        var length = 0;
        var maxLength = 0;
        for (var i = 0; i < fruits.Length; i++)
        {
            if (frequency.ContainsKey(fruits[i]))
                frequency[fruits[i]]++;
            else if (frequency.Keys.Count == 2)
            {
                while (left < i && frequency.Keys.Count == 2)
                {
                    frequency[fruits[left]]--;
                    if (frequency[fruits[left]] == 0)
                        frequency.Remove(fruits[left]);
                    left++;
                    length--;
                }
                frequency.Add(fruits[i], 1);
            }
            else
                frequency.Add(fruits[i], 1);

            length++;
            maxLength = Math.Max(maxLength, length);
        }

        return maxLength;
    }
}

public class FruitIntoBasketsTest
{
    [TestCase(new[] {0,1,1,4,3}, 3)]
    [TestCase(new[] {1,2,1}, 3)]
    [TestCase(new[] {0,1,2,2}, 3)]
    [TestCase(new[] {1,2,3,2,2}, 4)]
    public void Test(int[] fruits, int expected)
    {
        var solution = new FruitIntoBaskets();
        
        solution.TotalFruit(fruits).Should().Be(expected);
    }
}