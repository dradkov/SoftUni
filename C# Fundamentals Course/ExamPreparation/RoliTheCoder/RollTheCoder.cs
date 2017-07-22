namespace RollTheCoder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class RollTheCoder
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Dictionary<string, Event> events = new Dictionary<string, Event>();

            while (!command.Equals("Time for Code"))
            {
                string pattern = @"[0-9a-zA-Z]+\s+#[0-9a-zA-Z]+\s*(@[a-zA-Z]+\s*)*";
                Regex regex = new Regex(pattern);

                if (regex.IsMatch(command))
                {
                    string[] commandLine = command
                                  .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string id = commandLine[0];
                    string eventName = commandLine[1];

                    List<string> participants = new List<string>();

                    for (int i = 2; i < commandLine.Length; i++)
                    {

                        participants.Add(commandLine[i].Substring(1));
                    }

                    Event roliEvent = new Event();

                    roliEvent.id = id;
                    roliEvent.name = eventName;
                    roliEvent.participants = participants;

                    List<string> part = new List<string>();
                    part = roliEvent.participants.Distinct().ToList();

                    roliEvent.participants = part;

                    if (!events.ContainsKey(id))
                    {
                        events.Add(id, roliEvent);
                    }
                    else
                    {
                        if (events[id].name == roliEvent.name)
                        {
                            events[id].participants.AddRange(participants);

                            List<string> distinctPart = new List<string>();
                            distinctPart = events[id].participants.Distinct().ToList();

                            events[id].participants = distinctPart;

                        }
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var roliEvent in events.OrderByDescending(x => x.Value.participants.Count).ThenBy(x => x.Value.name))
            {

                Console.WriteLine("{0} - {1}", roliEvent.Value.name.Substring(1), roliEvent.Value.participants.Count);

                roliEvent.Value.participants.Sort();

                foreach (var participant in roliEvent.Value.participants)
                {
                    Console.WriteLine($"@{participant}");
                }
            }
        }
    }


    public class Event
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<string> participants { get; set; }
    }
}