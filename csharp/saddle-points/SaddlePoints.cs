using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        List<(int, int)> res = new List<(int, int)>();
        for (int i=0; i<n; i++)
        {
            List<int> col_index = FindMaxRowElementIndex(matrix, i);
            foreach(int j in col_index)
            {
                if (isMinInColumn(matrix, i, j))
                {
                    res.Add((i, j));
                }
            }
        }

        return res;
    }

    private static bool isMinInColumn(int[,] matrix, int i, int j)
    {
        int n = matrix.GetLength(0);
        for (int k=0; k<n; k++)
        {
            if (matrix[k, j] < matrix[i, j])
                return false;
        }
        return true;
    }

    private static List<int> FindMaxRowElementIndex(int[,] matrix, int r)
    {
        int curr_max = int.MinValue;
        List<int> res_index = new List<int>(); // in case there are repeated max values
        int m = matrix.GetLength(1);
        for (int i = 0; i < m; i++)
        {
            if (matrix[r,i] > curr_max)
            {
                curr_max = matrix[r, i];
                res_index.Clear();
                res_index.Add(i);
            }
            else if (matrix[r,i] == curr_max)
            {
                res_index.Add(i);
            }
        }
        return res_index;
    }
}
