using System;
using System.Collections.Generic;
using System.Linq;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        if (rows == 0)
            return new List<List<int>>();
        return makePascalsTriangle(new List<List<int>>() { new List<int>() { 1 }}, rows - 1);
    }

    private static List<List<int>> makePascalsTriangle(List<List<int>> triangleRows, int remainingRows)
    {
        if (remainingRows == 0)
            return triangleRows;
        List<int> currRow = new List<int>();
        List<int> previousRow = triangleRows.Last();
        currRow.Add(previousRow.First());
        for(int i=0; i<=previousRow.Count-2; i++)
        {
            currRow.Add(previousRow[i] + previousRow[i + 1]);
        }
        currRow.Add(previousRow.Last());
        remainingRows--;
        triangleRows.Add(currRow);
        return makePascalsTriangle(triangleRows, remainingRows);
    }
}