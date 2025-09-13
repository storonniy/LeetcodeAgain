namespace Leetcode.Easy;

public class MostFrequentVowel
{
    /// <summary>
    /// 3541. Find Most Frequent Vowel and Consonant
    /// </summary>
    public int MaxFreqSum(string s)
    {
        var frequencies = new int[26];
        var maxVowelFrequency = 0;
        var maxConsolantFrequency = 0;
        foreach (var x in s)
        {
            frequencies[x - 'a']++;
            if (x is 'a' or 'e' or 'o' or 'i' or 'u')
                maxVowelFrequency = Math.Max(frequencies[x - 'a'],  maxVowelFrequency);
            else
                maxConsolantFrequency = Math.Max(frequencies[x - 'a'],  maxConsolantFrequency);
            
        }
        return maxConsolantFrequency +  maxVowelFrequency;
    }
}