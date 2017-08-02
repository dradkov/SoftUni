namespace _09.TrafficLights.Core
{
    using _09.TrafficLights.Models;
    using System;
    using System.Collections.Generic;
    using _09.TrafficLights.Enums;


    public class Engine
    {
        private IList<TrafficLights> trafficLightses;

        public Engine()
        {
            this.trafficLightses = new List<TrafficLights>();
        }

        public void Run()
        {
            var command = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var light in command)
            {
                trafficLightses.Add(new TrafficLights(light));
            }

            var numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {

                foreach (var light in trafficLightses)
                {
                    light.CheckColors();
                }
                Console.WriteLine(string.Join(" ",trafficLightses));
            }

        }
    }
}
