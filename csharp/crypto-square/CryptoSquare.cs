using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        if (plaintext.Length == 0) return string.Empty;
        return new string(plaintext.ToLower().Where(x => !char.IsPunctuation(x) && !char.IsWhiteSpace(x)).ToArray());
    }

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        int len = plaintext.Length;
        int rows, cols;
        GetRectangleDimensions(len, out rows, out cols);
        string plainTextForRectangle = plaintext.PadRight(rows * cols);
        int chunkLen = plainTextForRectangle.Length / cols;
        List<string> chunks = new List<string>();
        for(int i=0; i<plainTextForRectangle.Length; i=i+chunkLen)
        {
            chunks.Add(plainTextForRectangle.Substring(i, chunkLen));
        }
        List<string> res = new List<string>();
        for(int i=0; i<rows; i++)
        {
            res.Add(chunks.RemoveFromAllAt(i));
        }
        return res;
    }

    public static string RemoveFromAllAt<T>(this List<T> list, int idx)
    {
        if (typeof(T) == typeof(string))
        {
            StringBuilder res = new StringBuilder();
            foreach (var ele in list)
            {
                res.Append(ele.ToString().ElementAt(idx));
            }
                return res.ToString();
        }
        return string.Empty;
    }

    private static void GetRectangleDimensions(int len, out int rows, out int cols)
    {
        bool foundUpper = false;
        int lower = 0, upper = 0;
        for(int i=2; !foundUpper; i++)
        {
            if(i*i >= len)
            {
                lower = i - 1;
                upper = i;
                foundUpper = true;
            }
        }
        if ((upper * upper == len) || ((upper * (upper - 1)) < len)) { rows = upper; cols = upper; return; }

        rows = upper; cols = upper - 1;
        return;
    }

    public static string Encoded(string plaintext)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static string Ciphertext(string plaintext)
    {
        string normalizedText = NormalizedPlaintext(plaintext);
        if (normalizedText.Length <= 1)
            return normalizedText;
        var chunks = PlaintextSegments(normalizedText).ToArray();
        return string.Join(" ", chunks);
    }

    // alternate solution using LINQ query
    //
    //public static string Ciphertext(string plaintext)
    //{
    //    // normalize plain text
    //    plaintext = Concat(plaintext
    //        .Where(char.IsLetterOrDigit)
    //        .Select(char.ToLower));

    //    // compute dimensions
    //    var sqrt = Sqrt(plaintext.Length);
    //    var r = (int)Round(sqrt);
    //    var c = (int)Ceiling(sqrt);

    //    // encode text
    //    return Join(" ",
    //        from ci in Range(0, c)
    //        select Concat
    //        (
    //            from ri in Range(0, r)
    //            let i = ri * c + ci
    //            select i < plaintext.Length ? plaintext[i] : ' '
    //        )
    //    );
    //}
}