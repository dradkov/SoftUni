namespace Stations.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;

    public class TrainDto
    {
        [Required]
        [MaxLength(10)]
        public string TrainNumber { get; set; }

        public string Type { get; set; } = "HighSpeed";

        public SeatingDto[] Seats { get; set; } = new SeatingDto[0];
     
    }
}
