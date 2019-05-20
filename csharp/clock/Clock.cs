using System;

public class Clock : IEquatable<Clock>
{
    private int m_hours;
    private int m_minutes;

    private void fixMinutesAndHours()
    {
        // adjust minutes
        if (m_minutes < 0)
        {
            int hoursToRemove = m_minutes % 60 == 0 ? (int)(m_minutes / 60) : (int)(m_minutes / 60) - 1;
            hoursToRemove *= -1; // make it a positive quantity
            m_hours -= hoursToRemove;
            m_minutes = hoursToRemove * 60 + m_minutes;
        }
        else
        {
            m_hours += (int)(m_minutes / 60);
            m_minutes = m_minutes % 60;
        }
        m_hours = m_hours % 24;
        m_hours = m_hours < 0 ? 24 + m_hours : m_hours;
    }
    public Clock(int hours, int minutes)
    {
        m_hours = hours;
        m_minutes = minutes;
        fixMinutesAndHours();
    }
    public int Hours
    {
        get
        {
            return m_hours;
        }
    }

    public int Minutes
    {
        get
        {
            return m_minutes;
        }
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(m_hours, m_minutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(m_hours, m_minutes - minutesToSubtract);
    }

    public override string ToString()
    {
        return m_hours.ToString("00") + ":" + m_minutes.ToString("00");
    }

    public bool Equals(Clock other)
    {
        if (other.Hours != this.Hours || other.Minutes != this.Minutes)
            return false;
        return true;
    }
}