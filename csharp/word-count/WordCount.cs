using System;
using System.Collections.Generic;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        string[] words = phrase.Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries);
        IDictionary<string, int> dict = new Dictionary<string, int>();
        foreach(string word in words)
        {
            string tmpWord = word.Trim(new char[] { '\n', ':', '!', '@', '#', '$', '%', '^', '&', '*', '.', '\'' }).ToLower();
            if (string.IsNullOrEmpty(tmpWord))
                continue;
            if (dict.ContainsKey(tmpWord))
                dict[tmpWord]++;
            else
            {
                dict[tmpWord] = 1;
            }
        }
        return dict;
    }
}