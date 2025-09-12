using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class Vowels
{
    public string SortVowels(string s)
    {
        var symbols = new List<char>(s.Length);
        var indices = new List<int>(s.Length);
        var vowels = new HashSet<char>(new []{'a', 'e', 'i', 'o', 'u'});
        for (var i = 0; i < s.Length; i++)
        {
            var x = s[i];
            if (!vowels.Contains(char.ToLower(x)))
                continue;
            symbols.Add(x);
            indices.Add(i);
        }

        var sb = new StringBuilder(s);
        symbols = symbols.OrderBy(x => x - '0').ToList();
        for (var i = 0; i < symbols.Count; i++)
            sb[indices[i]] = symbols[i];

        return sb.ToString();
    }
}

public class VowelsTest
{
    [TestCase("lEetcOde", "lEOtcede")]
    public void Test(string s, string expected)
    {
        var solution = new Vowels();
        
        solution.SortVowels(s).Should().Be(expected);
    }
}