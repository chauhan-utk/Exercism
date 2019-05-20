using System;

public class SpiralMatrix
{
    private enum direction {
        right,
        down,
        left,
        up
    };
    private static void fillMatrix(int[,] m_matrix, ref int m_nextVal, int start_x, int start_y, int stepSize, direction dir)
    {
        if (stepSize <= 0)
        {
            m_matrix[start_x, start_y] = m_nextVal;
            m_nextVal++;
            return;
        }

        int tmp = 1;
        switch (dir)
        {
            case direction.right:
                while (tmp <= stepSize)
                {
                    m_matrix[start_x, start_y] = m_nextVal;
                    m_nextVal++;
                    start_y++;
                    tmp++;
                }
                fillMatrix(m_matrix, ref m_nextVal, start_x, start_y, stepSize, direction.down);
                return;
            case direction.down:
                while (tmp <= stepSize)
                {
                    m_matrix[start_x, start_y] = m_nextVal;
                    m_nextVal++;
                    start_x++;
                    tmp++;
                }
                fillMatrix(m_matrix, ref m_nextVal, start_x, start_y, stepSize, direction.left);
                return;
            case direction.left:
                while (tmp <= stepSize)
                {
                    m_matrix[start_x, start_y] = m_nextVal;
                    m_nextVal++;
                    start_y--;
                    tmp++;
                }
                fillMatrix(m_matrix, ref m_nextVal, start_x, start_y, stepSize, direction.up);
                return;
            case direction.up:
                while (tmp <= stepSize)
                {
                    m_matrix[start_x, start_y] = m_nextVal;
                    m_nextVal++;
                    start_x--;
                    tmp++;
                }
                return;
        }
    }
    public static int[,] GetMatrix(int size)
    {
        int m_nextVal = 1;
        int[,] m_matrix;

        if (size == 1)
        {
            return new int[1, 1] { { 1 } };
        }
        m_matrix = new int[size, size];
        int cellsToWrite = size - 1; // initial number of steps to write
        for (int startIdx=0; startIdx < (size+1)/2; startIdx++, cellsToWrite = cellsToWrite - 2)
        {
            fillMatrix(m_matrix, ref m_nextVal, startIdx, startIdx, cellsToWrite, direction.right);            
        }
        return m_matrix;
    }

    //public static void Main()
    //{
    //    int size = 100;
    //    int[,] matrix = GetMatrix(size);
    //    for (int i = 0; i < matrix.GetLength(0); i++)
    //    {
    //        for (int j = 0; j < matrix.GetLength(1); j++)
    //        {
    //            Console.Write(matrix[i, j].ToString("0000") + "\t");
    //        }
    //        Console.WriteLine();
    //    }
    //}
}
