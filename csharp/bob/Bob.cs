using System;

public static class Bob
{
    public static string Response(string statement)
    {
        //throw new NotImplementedException("You need to implement this function.");
        string stmt = statement.Trim();
        if (stmt.IsNullOrEmpty()) return "Fine. Be that way!";
        bool yell = stmt.IsUpper();
        if (stmt.EndsWith('?'))
        {
            if (yell) return "Calm down, I know what I'm doing!";
            else return "Sure.";
        }
        if (yell) return "Whoa, chill out!";
        return "Whatever.";
    }

    private static bool IsUpper(this string s)
    {
        int count = 0;
        foreach( char x in s)
        {
            if (Char.IsLetter(x))
            {
                if (Char.IsLower(x)) return false;
            }
            else count++;
        }
        if (count == s.Length) return false;

        return true;
    }

    private static bool IsNullOrEmpty(this string s)
    {
        if (s == null || s.Trim() == "") return true;
        return false;
    }
}