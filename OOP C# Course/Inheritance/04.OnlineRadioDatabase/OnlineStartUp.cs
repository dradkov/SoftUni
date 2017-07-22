namespace OnlineRadioDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OnlineStartUp
    {
        static void Main(string[] args)
        {
            var songNum = int.Parse(Console.ReadLine());

            var listSongs = new List<Song>();

            for (int i = 0; i < songNum; i++)
            {

                try
                {
                    var songInfo = Console.ReadLine()
                   .Split(new[] { ';', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    var artist = songInfo[0].Trim();
                    var songName = songInfo[1].Trim();
                    var time = songInfo[2].Split(':');

                    var minutes = 0;
                    var seconds = 0;
                    try
                    {
                        minutes = int.Parse(time[0]);
                        seconds = int.Parse(time[1]);
                    }
                    catch (Exception)
                    {

                        throw new InvalidSongLengthException();
                    }




                    listSongs.Add(new Song(artist, songName, minutes, seconds));
                    Console.WriteLine("Song added.");

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
            var totalMin = listSongs.Sum(x => x.Minutes);
            var totalSec = listSongs.Sum(s => s.Seconds);

            var times = TimeSpan.FromSeconds(totalSec) + TimeSpan.FromMinutes(totalMin);

            Console.WriteLine($"Songs added: {listSongs.Count()}");
            Console.WriteLine($"Playlist length: {times.Hours}h {times.Minutes}m {times.Seconds}s");
        }

    }
}

