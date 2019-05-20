using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        Dictionary<char, int> res = new Dictionary<char, int>();
        Parallel.ForEach(texts, (text) =>
        {
            text = text.ToLower();
            foreach(char ch in text)
            {
                if (char.IsDigit(ch) || char.IsPunctuation(ch) || char.IsWhiteSpace(ch)) continue;
                lock (res)
                {
                    if (res.ContainsKey(ch)) res[ch]++;
                    else res[ch] = 1;
                }
            }
        });
        return res;
    }
}