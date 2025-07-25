using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Easy;

public class LongPressedName
{
    /// <summary>
    /// 925. Long Pressed Name
    /// </summary>
    public bool IsLongPressedName(string name, string typed)
    {
        if (name.First() != typed.First() || 
            name.Length > typed.Length
            || name.Last() != typed.Last())
            return false;
        var pointer = 0;
        var count = 1;
        for (var i = 1; i < name.Length; i++)
        {
            var typedCount = 0;
            if (name[i] != name[i - 1])
            {
                while (pointer < typed.Length && typed[pointer] == name[i - 1])
                {
                    typedCount++;
                    pointer++;
                }
                if (count > typedCount)
                    return false;
                if (pointer == typed.Length)
                    return false;
                if (name[i] != typed[pointer])
                    return false;
                count = 1;
            }
            else
                count++;
        }
        while (pointer < typed.Length)
        {
            if (typed[pointer] != name.Last())
                return false;
            pointer++;
        }

        return true;
    }
}

public class LongPressedNameTest
{
    private LongPressedName unit = new();
    
    [TestCase("bdad", "bbbd", false)]
    [TestCase("leelee", "lleeelee", true)]
    [TestCase("vtkgn", "vttkgnn", true)]
    [TestCase("alex", "aaleexeex", false)]
    [TestCase("alex", "aaleexa", false)]
    [TestCase("alex", "aaleex", true)]
    [TestCase("saeed", "ssaaedd", false)]
    public void Test(string name, string typed, bool expected)
    {
        unit.IsLongPressedName(name, typed).Should().Be(expected);
    }
}