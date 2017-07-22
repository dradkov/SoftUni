using System;


class Program
{
    static void Main()
    {
        int takenPicture = int.Parse(Console.ReadLine());
        int filterTime = int.Parse(Console.ReadLine());
        int filterFactor = int.Parse(Console.ReadLine());
        int uploadTime = int.Parse(Console.ReadLine());

        long pictureTime = (long)takenPicture * filterTime;
        long filterFactPercent = (long)Math.Ceiling ((double)takenPicture * filterFactor/100) ;
        long upTimeAll = filterFactPercent * uploadTime;

        long totalTime = pictureTime + upTimeAll;

        TimeSpan t = TimeSpan.FromSeconds(totalTime);

        string answer = string.Format("{0:D1}:{1:D2}:{2:D2}:{3:D2}",
                        t.Days,
                        t.Hours,
                        t.Minutes,
                        t.Seconds);

        Console.WriteLine(answer);

    }
}

