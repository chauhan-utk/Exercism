using System;
using System.Collections.Generic;
using System.Linq;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private int m_month;
    private int m_year;
    private List<DateTime> datesInMonth;
    public Meetup(int month, int year)
    {
        m_month = month;
        m_year = year;
        datesInMonth = Enumerable.Range(1, DateTime.DaysInMonth(m_year, m_month)).Select(day => new DateTime(m_year, m_month, day)).ToList();
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        List<DateTime> potentialDates = datesInMonth.Where(day => day.DayOfWeek == dayOfWeek).ToList();
        switch (schedule)
        {
            case Schedule.First:
                return potentialDates.First();
            case Schedule.Second:
                return potentialDates.ElementAt(1);
            case Schedule.Third:
                return potentialDates.ElementAt(2);
            case Schedule.Fourth:
                return potentialDates.ElementAt(3);
            case Schedule.Last:
                return potentialDates.Last();
            case Schedule.Teenth:
                return potentialDates.Where(day => day.Day >= 13 && day.Day <= 19).First();
        }
        return new DateTime();
    }
}