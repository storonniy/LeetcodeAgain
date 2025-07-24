namespace Leetcode.Medium;

public class Solution {
    /// <summary>
    /// 1717. Maximum Score From Removing Substrings
    /// </summary>
    /*
     * Есть строка, надо удалить подстроки ab и ba
     * За удаление ab получаешь x попугаев
     * За удаление ba получаешь y попугаев
     * Идейка в том, чтобы получить максимум попугаев
     *
     * Решеньице: сначала удаляем то, что дороже стоит
     * Если x > y, то сначала удаляем все ab, иначе ba
     */
    public int MaximumGain(string input, int x, int y) 
    {
        var gain = 0;
        var stack = new Stack<char>(input.Length);
        var first = 'b';
        var second = 'a';
        if (x > y)
        {
            (x, y) = (y, x);
            (first, second) = (second, first);
        }
        foreach (var c in input)
        {
            if (c != second)
            {
                stack.Push(c);
                continue;
            }

            if (stack.Count > 0 && stack.Peek() == first)
            {
                stack.Pop();
                gain += y;
            }
            else 
                stack.Push(c);
        }

        var reversedStack = new Stack<char>(stack.Count);
        while (stack.Count > 0)
        {
            var c = stack.Pop();
            if (c != second)
            {
                reversedStack.Push(c);
                continue;
            }

            if (reversedStack.Count > 0 && reversedStack.Peek() == first)
            {
                reversedStack.Pop();
                gain += x;
            }
            else 
                reversedStack.Push(c);

        }
        return gain;
    }
}