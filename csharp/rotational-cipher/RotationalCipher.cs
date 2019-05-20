using System;
using System.Collections.Generic;

public static class RotationalCipher
{
    private static char rotateChar(char ch, int rot)
    {
        bool isUpper = char.IsUpper(ch);
        int currVal = char.ToLower(ch) - 'a';
        int newVal = (currVal + rot) % 26;
        char newCh = (char)('a' + newVal);
        newCh = isUpper ? char.ToUpper(newCh) : newCh;
        return newCh;
    }
    public static string Rotate(string text, int shiftKey)
    {
        List<char> cipher = new List<char>();
        foreach(char ch in text)
        {
            if (char.IsLetter(ch))
            {
                cipher.Add(rotateChar(ch, shiftKey));
            }
            else cipher.Add(ch);
        }
        return string.Join("", cipher.ToArray());
    }
}