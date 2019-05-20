using System;
using System.Text;

public static class AtbashCipher
{
    private static string plainText = "abcdefghijklmnopqrstuvwxyz";
    private static string cipherText = "zyxwvutsrqponmlkjihgfedcba";

    public static string Encode(string plainValue)
    {
        StringBuilder res = new StringBuilder();
        int idx = 1;
        foreach(char ch in plainValue.ToLower())
        {
            if (char.IsWhiteSpace(ch) || char.IsPunctuation(ch)) continue;
            if (char.IsDigit(ch)) { res.Append(ch); }
            else
            {
                int tmp = plainText.IndexOf(ch);
                res.Append(cipherText[tmp]);
            }
            if (idx == 5) { idx = 1; res.Append(' '); }
            else { idx++; }
        }
        return res.ToString().Trim();
    }

    public static string Decode(string encodedValue)
    {
        StringBuilder res = new StringBuilder();
        foreach(char ch in encodedValue)
        {
            if (char.IsWhiteSpace(ch)) continue;
            if (char.IsDigit(ch)) { res.Append(ch); }
            else
            {
                int tmp = cipherText.IndexOf(ch);
                res.Append(plainText[tmp]);
            }
        }
        return res.ToString();
    }
}
