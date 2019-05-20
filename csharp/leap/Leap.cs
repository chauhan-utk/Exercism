using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        if (year <= 0)
            throw new ArgumentException();

        //throw new NotImplementedException("You need to implement this function.");
        if (year % 100 == 0 && year % 400 != 0) return false;
        if (year % 4 == 0) return true;
        return false;
    }
}