using System;
using System.Collections.Generic;

public class WeeklyEntry : IComparable<WeeklyEntry>
{


    public WeeklyEntry(string weekday, string notes)
    {
        this.Weekday = (WeekDay)Enum.Parse(typeof(WeekDay), weekday);
        this.Notes = notes;
    }

    public WeekDay Weekday { get; private set; }
    public string Notes { get; private set; }

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var weekdayComparison = Weekday.CompareTo(other.Weekday);
        if (weekdayComparison != 0) return weekdayComparison;
        return string.Compare(Notes, other.Notes, StringComparison.Ordinal);
    }

    public override string ToString()
    {
        return $"{this.Weekday} - {this.Notes}";
    }
}