namespace Leetcode.Hard;

public class TheGameOfSum
{
    private const double dv = 10e-6;

    public bool JudgePoint24(int[] cards)
    {
        var values = cards.Select(x => (double)x).ToList();
        return Evaluate(values);
    }

    private bool Evaluate(List<double> values)
    {
        if (values.Count == 1)
            return Math.Abs(values[0] - 24) < dv;

        for (var i = 0; i < values.Count; i++)
        for (var j = i + 1; j < values.Count; j++)
            foreach (var v in GenerateAllValues(values[i], values[j]))
            {
                var newValues = new List<double>() { v };
                for (var k = 0; k < values.Count; k++)
                    if (k != j && k != i)
                        newValues.Add(values[k]);
                if (Evaluate(newValues))
                    return true;
            }


        return false;
    }

    IEnumerable<double> GenerateAllValues(double a, double b)
    {
        yield return a + b;
        yield return a - b;
        yield return a * b;
        yield return b - a;
        if (Math.Abs(b) > dv)
            yield return a / b;
        if (Math.Abs(a) > dv)
            yield return b / a;
    }
}