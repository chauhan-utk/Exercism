using System;
using System.Linq;
using System.Text;

public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        StringBuilder res = new StringBuilder();
        string[] flagArray = flags.Split(' ');
        bool singleFile = files.Count() == 1 ? true : false;
        foreach(string file in files)
        {
            string tmp = ProcessSingleFile(pattern, flagArray, file, singleFile);
            if (!string.IsNullOrEmpty(tmp))
            {
                res.AppendFormat("{0}\n", tmp);
            }
        }
        return res.ToString().TrimEnd();
    }

    private static string ProcessSingleFile(string pattern, string[] flags, string file, bool singleFile)
    {
        string[] lines = System.IO.File.ReadAllLines(file);
        StringBuilder res = new StringBuilder();
        Func<string[], string, int, string, string> formatString;
        if (singleFile) formatString = formatResultSingleFile;
        else formatString = formatResultMultipleFile;

        bool includeLineNumber = flags.Contains("-n");
        bool printOnlyFileName = flags.Contains("-l");

        for(int i=0; i<lines.Length; i++)
        {
            string tmp = GetResultLine(flags, file, pattern, i, lines[i], formatString);
            if (!string.IsNullOrEmpty(tmp))
            {
                if (flags.Contains("-l") && !singleFile)
                {
                    if (res.ToString().Contains(tmp))
                        continue;
                }
                res.AppendFormat("{0}\n", tmp);
            }
        }
        return res.ToString().TrimEnd();
    }

    private static string GetResultLine(string[] flags, string file, string pattern, int i, string line, Func<string[], string, int, string, string> formatString)
    {
        string res = string.Empty;
        bool matchWholeLine = flags.Contains("-x");
        bool invertResult = flags.Contains("-v");
        StringComparison stringComparison = flags.Contains("-i") ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        if (matchWholeLine)
        {
            if (pattern.Equals(line, stringComparison))
            {
                return invertResult ? string.Empty : formatString(flags, file, i, line);
            }
            else
            {
                return invertResult ? formatString(flags, file, i, line) : string.Empty;
            }
        }
        else
        {
            if (line.Contains(pattern, stringComparison))
            {
                return invertResult ? string.Empty : formatString(flags, file, i, line);
            }
            else
            {
                return invertResult ? formatString(flags, file, i, line) : string.Empty;
            }
        }
    }

    private static string formatResultSingleFile(string[] flags, string file, int i, string line)
    {
        return flags.Contains("-l") ? file : flags.Contains("-n") ? string.Format("{0}:{1}",i+1,line) : string.Format("{0}", line);
    }

    private static string formatResultMultipleFile(string[] flags, string file, int i, string line)
    {
        string res = string.Format("{0}",file);
        bool onlyFileName = flags.Contains("-l");
        if (onlyFileName) return file;
        bool includeLineNumber = flags.Contains("-n");
        return includeLineNumber ? string.Format("{0}:{1}:{2}", res, i + 1, line) : string.Format("{0}:{1}", res, line);
    }
}