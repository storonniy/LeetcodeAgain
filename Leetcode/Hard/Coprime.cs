namespace Leetcode.Hard;

public class Coprime
{
    public IList<int> ReplaceNonCoprimes(int[] nums)
    {
        var stack = new List<int>();
        foreach (var a in nums)
        {
            var result = a;
            while (stack.Count > 0)
            {
                var top = stack[^1];
                var g = Gcd(top, result);
                if (g == 1)
                {
                    break;
                }

                stack.RemoveAt(stack.Count - 1);
                result = top / g * result;
            }

            stack.Add(result);
        }

        return stack;
    }

    private int Gcd(int a, int b)
    {
        if (a == 0)
            return b;
        if (b == 0)
            return a;
        return Gcd(b, a % b);
    }
}