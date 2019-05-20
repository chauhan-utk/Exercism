using System;
using System.Collections;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    { 
        Stack st = new Stack();
        foreach(char ch in input)
        {
            switch (ch)
            {
                case '{':
                case '[':
                case '(': st.Push(ch);
                    break;
                case '}':
                    if (st.Count != 0 && (char)st.Peek() == '{') { st.Pop(); }
                    else return false; break;
                case ']':
                    if (st.Count != 0 && (char)st.Peek() == '[') { st.Pop(); }
                    else return false; break;
                case ')':
                    if (st.Count != 0 && (char)st.Peek() == '(') { st.Pop(); }
                    else return false; break;
            }
        }
        if (st.Count != 0)
            return false;
        return true;
    }
}
