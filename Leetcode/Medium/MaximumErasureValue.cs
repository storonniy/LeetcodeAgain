namespace Leetcode.Medium;

public class MaximumErasureValue
{
    /// <summary>
    /// 1695. Maximum Erasure Value
    /// </summary>
    /*
     * Есть набор чиселок, требуется удалить неразрывную подпоследовательность
     * уникальных чиселок
     * За удаление подпоследовательности получаешь очки - сумму чиселок подпоследовательности
     * Найти подпоследовательность с максимальной суммой
     * Подход - идем по исходным чиселкам, пока не встретим такую,
     * какую уже видели
     * Слева подметаем подпоследовательность, пока не удалим дублирующийся элемент
     * И так, пока не закончатся чиселки
     */
    public int MaximumUniqueSubarray(int[] nums) 
    {
        var buffer = new HashSet<int>(nums.Length);
        var sum = 0;
        var max = 0;
        var left = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (buffer.Contains(nums[i]))
            {
                while (left < i && buffer.Contains(nums[i]))
                {
                    sum -= nums[left];
                    buffer.Remove(nums[left]);
                    left++;
                }
            }
            sum += nums[i];
            max = Math.Max(max, sum);
            buffer.Add(nums[i]);
        }

        return max;
    }
}