using System;
using System.Collections.Generic;
using System.Text;

public class SimpleCipher
{
    private string m_key = null;
    public SimpleCipher()
    {
        string lowerChars = "abcdefghijklmnopqrstuvwxyz";
        m_key = "";
        for (int i = 1; i <= 100; i++)
        {
            Random rnd = new Random();
            int idx = rnd.Next(0, lowerChars.Length);
            m_key += lowerChars[idx];
        }
    }

    public SimpleCipher(string key)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentException();
        m_key = key;
    }
    
    public string Key
    {
        get
        {
            return m_key;
        }
    }

    public string Encode(string plaintext)
    {
        StringBuilder res = new StringBuilder();
        for(int i = 0; i < plaintext.Length; i++)
        {
            int ch = plaintext[i] - 'a';
            int shiftDist = m_key[i % m_key.Length] - 'a';
            int encodedChar = (ch + shiftDist) % 26 + 'a';
            res.Append((char)encodedChar);
        }
        return res.ToString();
    }

    public string Decode(string ciphertext)
    {
        StringBuilder res = new StringBuilder();
        for(int i = 0; i < ciphertext.Length; i++)
        {
            int shiftDist = m_key[i % m_key.Length] - 'a';
            int ch = ciphertext[i] - 'a';
            int decodedChar = (ch - shiftDist + 26) % 26 + 'a';
            res.Append((char)decodedChar);
        }
        return res.ToString();
    }
}