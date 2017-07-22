namespace DateModifier
{
    using System;
    using System.Linq;

    public class DateModifier
    {
        public static void FindDateDiffrences(string firstDate, string secondDate)
        {
            var dateFirst = firstDate.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var dateSecond = secondDate.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


            var date1 = new DateTime(dateFirst[0], dateFirst[1], dateFirst[2]);
            var date2 = new DateTime(dateSecond[0], dateSecond[1], dateSecond[2]);

            var timeSpan = date1.Subtract(date2);
            Console.WriteLine(Math.Abs(timeSpan.TotalDays));
        }
    }
}

