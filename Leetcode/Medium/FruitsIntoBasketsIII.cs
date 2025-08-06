namespace Leetcode.Medium;

public class FruitsIntoBasketsIII
{
    int[] SegmentTree;

    private void Update(int id, int left, int right, int u, int value)
    {
        if (left > right)
            return;
        if (left == right)
        {
            SegmentTree[id] = value;
            return;
        }

        var mid = (left + right) / 2;
        if (u <= mid)
            Update(id * 2, left, mid, u, value);
        else
            Update(id * 2 + 1, mid + 1, right, u, value);
        SegmentTree[id] = Math.Max(SegmentTree[id * 2], SegmentTree[id * 2 + 1]);
    }

    private int Get(int id, int left, int right, int value)
    {
        while (true)
        {
            if (left > right) 
                return 0;
            if (left == right) 
                return left;
            var mid = (left + right) / 2;
            if (SegmentTree[id * 2] >= value)
            {
                id = id * 2;
                right = mid;
                continue;
            }

            id = id * 2 + 1;
            left = mid + 1;
        }
    }

    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        var n = fruits.Length;
        SegmentTree = new int[4 * n + 1];
        for (var i = 0; i < n; i++)
            Update(1, 0, n - 1, i, baskets[i]);

        var ans = 0;
        for (var i = 0; i < n; i++)
        {
            if (SegmentTree[1] < fruits[i])
                ans++;
            else
            {
                var index = Get(1, 0, n - 1, fruits[i]);
                Update(1, 0, n - 1, index, 0);
            }
        }

        return ans;
    }
}