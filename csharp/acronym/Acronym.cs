using System;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        string[] words = phrase.Split(new char[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
        string result = "";
        foreach(string word in words)
        {
            string wrd = word.Trim(new char[] { '_', ',' });
            result += wrd.Substring(0, 1).ToUpper();
        }
        return result;
    }
}