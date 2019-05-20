using System;
using System.Collections.Generic;
using System.Linq;

public static class Minesweeper
{
    private static string[] minefield;
    private static int m_rows;
    private static int m_cols;
    public static string[] Annotate(string[] input)
    {
        if (input.Count() == 0)
            return Array.Empty<string>();
        List<string> res = new List<string>();
        minefield = input;
        m_rows = input.Length;
        m_cols = input.First().Length;
        for(int i = 0; i < m_rows; i++)
        {
            string tmp = "";
            for(int j = 0; j < m_cols; j++)
            {
                if (minefield[i][j] == '*') { tmp += '*'; continue; }
                int countdMines = GetNeabyMine(i, j);
                tmp = countdMines == 0 ? tmp + " " : tmp + countdMines;
            }
            res.Add(tmp);
        }
        return res.ToArray();
    }

    private static int GetNeabyMine(int x, int y)
    {
        int res = 0;
        if (isValid(x, y - 1) && IsMne(x, y - 1)) ++res;
        if (isValid(x - 1, y - 1) && IsMne(x - 1, y - 1)) ++res;
        if (isValid(x - 1, y) && IsMne(x - 1, y)) ++res;
        if (isValid(x - 1, y + 1) && IsMne(x - 1, y + 1)) ++res;
        if (isValid(x, y + 1) && IsMne(x, y + 1)) ++res;
        if (isValid(x + 1, y + 1) && IsMne(x + 1, y + 1)) ++res;
        if (isValid(x + 1, y) && IsMne(x + 1, y)) ++res;
        if (isValid(x + 1, y - 1) && IsMne(x + 1, y - 1)) ++res;
        return res;
    }

    private static bool isValid(int x, int y)
    {
        return x >= 0 && x < m_rows && y >= 0 && y < m_cols;
    }

    private static bool IsMne(int x, int y)
    {
        return minefield[x][y] == '*';
    }
}
