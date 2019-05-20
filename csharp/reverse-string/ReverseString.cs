using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        if (input == null) return string.Empty;
        char[] arr = input.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
    static string funnyString(string s)
    {
        if (s == null) return "Not Funny";
        if (s.Length == 1) return "Funny";
        string rev = new string(s);
        Array.Reverse(s.ToCharArray());
        rev = new string(rev);
        int a = (int)s[0], rev_a = (int)rev[0];
        for (int i = 1; i < s.Length - 1; i++)
        {
            int b = (int)s[i], rev_b = (int)rev[i];
            if (!(Math.Abs(a - b) == Math.Abs(rev_a - rev_b)))
            {
                return "Not Funny";
            }
        }
        return "Funny";
    }
}