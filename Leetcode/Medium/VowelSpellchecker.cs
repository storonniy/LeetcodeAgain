using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Medium;

public class VowelSpellchecker
{
    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
        var buffer = new HashSet<string>(wordlist);
        var dictionary = new Dictionary<string, string>();
        var skeletones = new Dictionary<string, string>();

        foreach (var word in wordlist)
        {
            var lower = word.ToLower();
            dictionary.TryAdd(lower, word);
            var skeleton = GetSkeleton(lower);
            skeletones.TryAdd(skeleton, word);
        }

        var result = new string[queries.Length];
        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            if (buffer.Contains(query))
            {
                result[i] = query;
                continue;
            }

            var lower = query.ToLower();
            if (dictionary.TryGetValue(lower, out var value))
            {
                result[i] = value;
                continue;
            }

            var skeleton = GetSkeleton(lower);
            result[i] = skeletones.GetValueOrDefault(skeleton, "");
        }

        return result;
    }

    string GetSkeleton(string word)
    {
        var vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
        var sb = new StringBuilder(word);
        for (var j = 0; j < sb.Length; j++)
        {
            if (vowels.Contains(sb[j]))
                sb[j] = '*';
        }

        return sb.ToString();
    }
}

public class TestTest
{
    [TestCase(new[] { "KiTe", "kite", "hare", "Hare" },
        new[] { "kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto" },
        new[] { "kite", "KiTe", "KiTe", "Hare", "hare", "", "", "KiTe", "", "KiTe" })]
    public void Test(string[] wordlist, string[] queries, string[] expected)
    {
        var x = new VowelSpellchecker();
        x.Spellchecker(wordlist, queries).Should().BeEquivalentTo(expected);
    }
}