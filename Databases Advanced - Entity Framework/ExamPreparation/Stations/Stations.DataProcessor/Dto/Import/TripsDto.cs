namespace Stations.DataProcessor.Dto.Import
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Stations.Models.Enums;

    public class TripsDto
    {
        [Required]
        public string OriginStation { get; set; }    

        [Required]
        public string DestinationStation { get; set; }

        [Required]
        public string DepartureTime { get; set; }

        [Required]
        public string ArrivalTime { get; set; }

        [Required]
        public string Train { get; set; }

        public string Status { get; set; } = "OnTime";

        public string TimeDifference { get; set; }
    }
}
