using System;
using System.Collections.Generic;

public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        List<uint> result = new List<uint>();
        foreach(uint number in numbers)
        {
            List<uint> encodedNumber = GetEncoding(number);
            encodedNumber.Reverse();
            result.AddRange(encodedNumber);
        }
        return result.ToArray();
    }

    private static List<uint> GetEncoding(uint number)
    {
        List<uint> res = new List<uint>();
        bool firstByte = true;
        while (firstByte || number != 0)
        {
            uint tmp = number & 0x7f;
            number = number >> 7; // shift bits to right
            if (firstByte)
            {
                tmp = tmp & 0x7f;
                firstByte = false;
            }
            else
            {
                tmp = tmp | 0x80;
            }
            res.Add(tmp);
        }
        return res;
    }

    public static uint[] Decode(uint[] bytes)
    {
        List<uint> result = new List<uint>();
        uint tmp = 0x0;
        bool incompleteSequence = true;
        foreach(uint byt in bytes)
        {
            incompleteSequence = true;
            tmp = tmp << 7;
            tmp = tmp | (byt & 0x7f);
            if ((byt & 0x80) != 0x80)
            {
                result.Add(tmp);
                tmp = 0x0;
                incompleteSequence = false;
            }
        }
        if (incompleteSequence)
            throw new InvalidOperationException();
        return result.ToArray();
    }
}