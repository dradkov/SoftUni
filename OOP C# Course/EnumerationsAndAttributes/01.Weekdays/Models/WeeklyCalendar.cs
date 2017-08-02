﻿using System.Collections.Generic;

public class WeeklyCalendar
{

    private IList<WeeklyEntry> data;

    public WeeklyCalendar()
    {
        this.data = new List<WeeklyEntry>();

    }


    public void AddEntry(string weekday, string notes)
    {
        this.data.Add(new WeeklyEntry(weekday, notes));

    }

    public IEnumerable<WeeklyEntry> WeeklySchedule
    {
        get { return this.data; }
    }
}





