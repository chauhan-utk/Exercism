using System;
using System.Collections.Generic;

public class Anagram
{
    private int[] computeHash(string word)
    {
        int[] count = new int[26];
        foreach(char ch in word.ToLower())
        {
            if (char.IsNumber(ch) || char.IsSeparator(ch))
                continue;
            int idx = ch - 'a';
            count[idx]++;
        }
        return count;
    }
    private bool isSameHash(int[] a, int[] b)
    {
        int len = a.Length;
        for (int i=0; i<len; i++)
        {
            if (a[i] != b[i])
                return false;
        }
        return true;
    }
    private int[] baseWordHash;
    private string baseWord;
    public Anagram(string baseWord)
    {
        baseWordHash = computeHash(baseWord);
        this.baseWord = baseWord;
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> res = new List<string>();
        foreach(string word in potentialMatches)
        {
            if (word.ToLower() == baseWord.ToLower())
                continue;
            int[] hash = computeHash(word);
            if (isSameHash(baseWordHash, hash))
                res.Add(word);
        }
        return res.ToArray();
    }
}