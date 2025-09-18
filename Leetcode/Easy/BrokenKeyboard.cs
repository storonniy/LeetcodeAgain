using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Easy;

public class BrokenKeyboard
{
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        var broken = new bool[26];
        foreach (var c in brokenLetters)
            broken[c - 'a'] = true;
        var typed = 0;
        var hasBroken = false;
        foreach (var c in text)
        {
            if (char.IsWhiteSpace(c))
            {
                if (!hasBroken)
                    typed++;
                hasBroken = false;
            }
            else if (broken[c - 'a'])
                hasBroken = true;
        }

        if (!hasBroken)
            typed++;

        return typed;
    }
}

public class BrokenKeyboardTest
{
    [TestCase("leet code", "lt", 1)]
    public void Test(string text, string brokenLetters, int expected)
    {
        var s = new BrokenKeyboard();

        s.CanBeTypedWords(text, brokenLetters).Should().Be(expected);
    }
}