namespace Leetcode.Hard;

public class RearrangingFruits
{
    public long MinCost(int[] basket1, int[] basket2)
    {
        var f = new Dictionary<int, int>(basket1.Length);
        var min = int.MaxValue;
        for (var i = 0; i < basket1.Length; i++)
        {
            f.TryAdd(basket1[i], 0);
            f[basket1[i]]++;
            f.TryAdd(basket2[i], 0);
            f[basket2[i]]--;
        }
        var list = new List<int>(basket1.Length + basket2.Length);
        foreach (var x in f)
        {
            if (x.Value % 2 != 0)
                return -1;
            for (var i = 0; i < Math.Abs(x.Value) / 2; i++)
                list.Add(x.Key);
            min = Math.Min(min, x.Key);
        }
        list.Sort();
        var cost = 0L;
        for (var i = 0; i < list.Count / 2; i++)
            cost += Math.Min(list[i], min * 2);
        return cost;
    }
}