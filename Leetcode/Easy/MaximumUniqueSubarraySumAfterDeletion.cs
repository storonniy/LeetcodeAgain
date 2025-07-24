using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Easy;

public class MaximumUniqueSubarraySumAfterDeletion
{
    /// <summary>
    /// 3487. Maximum Unique Subarray Sum After Deletion
    /// </summary>
    /*
     * Удалить любое количество элементов, оставив непустую последовательность
     * уникальных элементов, сумма которых максимальна
     * Вернуть эту сумму
     * Решение:
     * Суммируем все уникальные элементы
     * Суммируем все отрицательные числа
     * Находим максимальный элемент
     * Если сумма == сумме отрицательных - отдадим максимальный отрицательный элемент
     * Иначе вернем общую сумму уникальных элементов за вычетом суммы отрицательных элементов
     */
    public int MaxSum(int[] nums)
    {
        var frequency = new HashSet<int>(nums.Length);
        var sum = 0;
        var max = int.MinValue;
        var lessThanZeroSum = 0;
        foreach (var x in nums)
        {
            if (!frequency.Add(x))
                continue;
            if (x < 0)
                lessThanZeroSum += x;
            max = Math.Max(max, x);
            sum += x;
        }

        return sum == lessThanZeroSum ? max : sum - lessThanZeroSum;
    }
}

class MaximumUniqueSubarraySumAfterDeletionTest
{
    private MaximumUniqueSubarraySumAfterDeletion unit = new();

    [TestCase(new[] { 1, 1 }, 1)]
    [TestCase(new[] { -200, -100 }, -100)]
    [TestCase(new[] { -100 }, -100)]
    [TestCase(new[] { 1,2,-1,-2,1,0,-1 }, 3)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, 15)]
    [TestCase(new[] { 1, 2, 3, 4, 5, 5 }, 15)]
    public void Test(int[] nums, int expected)
    {
        unit.MaxSum(nums).Should().Be(expected);
    }
}