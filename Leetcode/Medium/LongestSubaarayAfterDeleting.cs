using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class LongestSubaarayAfterDeleting
{
    /// <summary>
    /// 1493. Longest Subarray of 1's After Deleting One Element
    /// </summary>
    /*
     * Есть последовательность из 1 и 0
     * Надо найти максимальную непрерывную подпоследовательность из единиц
     * При условии, что точно надо удалить 1 элемент
     * Решение:
     * Выгодно удалить одиночно стоящий 0
     * Если нулей нет совсем => ответ = ответ - 1
     *
     * Идем по массиву, пока не наткнемся на 0:
     * если после 0 - тоже 0, то приплыли, скипаем все, пока не встретим 1
     * если после 0 - 1, то можно его скипнуть и запомнить последний скипнутый индекс
     *      НО: если мы уже скипнули, то надо разскипать последний скипнутый и оставить текущую длину
     *          как длину от скипнутого индекса до текущего 
     */
    public int LongestSubarray(int[] nums)
    {
        var maxLength = 0;
        var length = 0;
        var lastDeleted = -1;
        var zeroFound = false;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                length++;
                maxLength = Math.Max(maxLength, length);
                continue;
            }

            zeroFound = true;
            if (i == nums.Length - 1 || length == 0)
                continue;
            if (nums[i + 1] == 0)
            {
                lastDeleted = -1;
                while (i < nums.Length && nums[i] == 0)
                    i++;

                length = 1;
                continue;
            }

            if (lastDeleted != -1)
                length = i - lastDeleted - 1;
            lastDeleted = i;
            maxLength = Math.Max(maxLength, length);
        }
        return maxLength - (zeroFound ? 0 : 1);
    }

    public class LongestSubaarayAfterDeletingTest
    {
        
        [TestCase(new[] { 1,0,1,1,1,1,1,1,0,1,1,1,1,1}, 11)]
        [TestCase(new[] { 1,1,1}, 2)]
        [TestCase(new[] { 1,1,0,1}, 3)]
        [TestCase(new[] { 0,1,1,1,0,1,1,0,1}, 5)]
        public void Test(int[] nums, int expected)
        {
            var solution = new LongestSubaarayAfterDeleting();

            solution.LongestSubarray(nums).Should().Be(expected);
        }
    }

}