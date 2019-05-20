using System;

public class Matrix
{
    private int n_rows = -1;
    private int[][] rows = null;

    public Matrix(string input)
    {
        string[] stringRows = input.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        n_rows = stringRows.Length;
        rows = new int[n_rows][];
        int currRow = 0;
        foreach(string stringRow in stringRows)
        {
            string[] cols = stringRow.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            rows[currRow] = new int[cols.Length];
            int currCol = 0;
            foreach(string colVal in cols)
            {
                rows[currRow][currCol] = Convert.ToInt32(colVal);
                currCol++;
            }
            currRow++;
        }
    }

    public int Rows
    {
        get
        {
            return rows.Length;
        }
    }

    public int Cols
    {
        get
        {
            return rows[0].Length;
        }
    }

    public int[] Row(int row)
    {
        int rowIndx = row - 1;
        if (rowIndx < 0 || rowIndx > rows.Length)
            throw new IndexOutOfRangeException();
        return rows[rowIndx];
    }

    public int[] Column(int col)
    {
        int[] colVals = new int[n_rows];
        int colIdx = col - 1;
        if (colIdx < 0 || colIdx > rows[0].Length - 1)
            throw new IndexOutOfRangeException();
        int tmp = 0;
        foreach(int[]row in rows)
        {
            colVals[tmp] = row[colIdx];
            ++tmp;
        }
        return colVals;
    }
}