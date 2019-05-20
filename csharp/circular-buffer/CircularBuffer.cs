using System;

public class CircularBuffer<T>
{
    private T[] m_internalBuffer;
    private int start_idx = -1;
    private int end_idx = -1;
    public CircularBuffer(int capacity)
    {
        m_internalBuffer = new T[capacity];
    }

    public T Read()
    {
        if (start_idx == -1)
            throw new InvalidOperationException();
        T tmp = m_internalBuffer[start_idx];
        if (start_idx == end_idx)
        {
            start_idx = end_idx = -1; //mark the buffer as empty
        }
        else
        {
            start_idx = (start_idx + 1) % m_internalBuffer.Length;
        }
        return tmp;
    }

    public void Write(T value)
    {
        if (start_idx == -1)
        {
            start_idx = end_idx = 0;
            m_internalBuffer[end_idx] = value;
        }
        else
        {
            int next_end_idx = (end_idx + 1) % m_internalBuffer.Length;
            if (next_end_idx == start_idx)
                throw new InvalidOperationException();
            end_idx = next_end_idx;
            m_internalBuffer[end_idx] = value;
        }
    }

    public void Overwrite(T value)
    {
        try
        {
            Write(value);
        }
        catch (InvalidOperationException)
        {
            // overwrite the existing value
            start_idx = (start_idx + 1) % m_internalBuffer.Length;
            end_idx = (end_idx + 1) % m_internalBuffer.Length;
            m_internalBuffer[end_idx] = value;
        }
    }

    public void Clear()
    {
        start_idx = -1;
        end_idx = -1;
    }
}