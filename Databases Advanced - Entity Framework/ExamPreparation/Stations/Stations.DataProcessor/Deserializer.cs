using System;
using Stations.Data;

namespace Stations.DataProcessor
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Stations.DataProcessor.Dto.Import;
    using Stations.Models;
    using Stations.Models.Enums;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportStations(StationsDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var jsonConvert = JsonConvert.DeserializeObject<StationDto[]>(jsonString);

            List<Station> validStations = new List<Station>();

            foreach (var stationDto in jsonConvert)
            {
                if (!isValid(stationDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (stationDto.Town == null)
                {
                    stationDto.Town = stationDto.Name;
                }

                if (validStations.Any(s => s.Name == stationDto.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var station = Mapper.Map<Station>(stationDto);
                validStations.Add(station);

                sb.AppendLine(string.Format(SuccessMessage, stationDto.Name));


            }


            context.Stations.AddRange(validStations);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportClasses(StationsDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var jsonDeserial = JsonConvert.DeserializeObject<SeatingClassesDto[]>(jsonString);

            List<SeatingClass> validSeatClasses = new List<SeatingClass>();

            foreach (var seatDto in jsonDeserial)
            {
                if (!isValid(seatDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var scExist =
                    validSeatClasses.Any(c => c.Name == seatDto.Name || c.Abbreviation == seatDto.Abbreviation);

                if (scExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatedClass = Mapper.Map<SeatingClass>(seatDto);

                validSeatClasses.Add(seatedClass);
                sb.AppendLine(string.Format(SuccessMessage, seatDto.Name));
            }
            context.SeatingClasses.AddRange(validSeatClasses);

            context.SaveChanges();


            return sb.ToString().TrimEnd();

        }

        public static string ImportTrains(StationsDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var jsonDescerz = JsonConvert.DeserializeObject<TrainDto[]>(jsonString, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            List<Train> validTrains = new List<Train>();

            foreach (var trainDto in jsonDescerz)
            {
                if (!isValid(trainDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var trainAlreadyExists = validTrains.Any(t => t.TrainNumber == trainDto.TrainNumber);

                if (trainAlreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }


                bool seatsExistInDb =
                    trainDto.Seats.All(
                        c => context.SeatingClasses.Any(cs => cs.Name == c.Name && cs.Abbreviation == c.Abbreviation));

                if (!seatsExistInDb)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool vaidSeat = trainDto.Seats.All(isValid);

                if (!vaidSeat)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var type = Enum.Parse<TrainType>(trainDto.Type);

                var trainSeats = trainDto.Seats.Select(sdto => new TrainSeat
                {
                    SeatingClass =
                            context.SeatingClasses.SingleOrDefault(
                                sc => sc.Name == sdto.Name && sc.Abbreviation == sdto.Abbreviation),
                    Quantity = sdto.Quantity.Value
                })
                    .ToArray();


                Train train = new Train
                {
                    TrainNumber = trainDto.TrainNumber,
                    Type = type,
                    TrainSeats = trainSeats
                };

                sb.AppendLine(string.Format(SuccessMessage, trainDto.TrainNumber));

                validTrains.Add(train);
            }
            context.Trains.AddRange(validTrains);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTrips(StationsDbContext context, string jsonString)
        {
            var deserializedTrips = JsonConvert.DeserializeObject<TripsDto[]>(jsonString, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var sb = new StringBuilder();
            var validTrips = new List<Trip>();

            foreach (var tripDto in deserializedTrips)
            {
                if (!isValid(tripDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var train = context.Trains.SingleOrDefault(t => t.TrainNumber == tripDto.Train);

                var originStation = context.Stations.SingleOrDefault(s => s.Name == tripDto.OriginStation);

                var destinationStation = context.Stations.SingleOrDefault(s => s.Name == tripDto.DestinationStation);

                if (train == null || originStation == null || destinationStation == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var departureTime = DateTime.ParseExact(tripDto.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                var arrivalTime = DateTime.ParseExact(tripDto.ArrivalTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                TimeSpan timeDifference;
                if (tripDto.TimeDifference != null)
                {
                    timeDifference = TimeSpan.ParseExact(tripDto.TimeDifference, @"hh\:mm", CultureInfo.InvariantCulture);
                }

                if (departureTime > arrivalTime)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var status = Enum.Parse<TripStatus>(tripDto.Status);

                var trip = new Trip
                {
                    Train = train,
                    OriginStation = originStation,
                    DestinationStation = destinationStation,
                    DepartureTime = departureTime,
                    ArrivalTime = arrivalTime,
                    Status = status,
                    TimeDifference = timeDifference
                };

                validTrips.Add(trip);
                sb.AppendLine($"Trip from {tripDto.OriginStation} to {tripDto.DestinationStation} imported.");
            }

            context.Trips.AddRange(validTrips);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportCards(StationsDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(CardDto[]), new XmlRootAttribute("Cards"));

            CardDto[] deserializer =
                (CardDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));


            List<CustomerCard> validCards = new List<CustomerCard>();

            foreach (var cardDto in deserializer)
            {
                if (!isValid(cardDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                CardType cardType = Enum.TryParse<CardType>(cardDto.CardType, out var card) ? card : CardType.Normal;


                var customerCard = new CustomerCard
                {
                    Name = cardDto.Name,
                    Type = cardType,
                    Age = cardDto.Age
                };

                validCards.Add(customerCard);
                sb.AppendLine(string.Format(SuccessMessage, cardDto.Name));


            }

            context.AddRange(validCards);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportTickets(StationsDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(TicketDto[]), new XmlRootAttribute("Tickets"));
            var deserializedTickets = (TicketDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();

            var validTickets = new List<Ticket>();
            foreach (var ticketDto in deserializedTickets)
            {
                if (!isValid(ticketDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var departureTime =
                    DateTime.ParseExact(ticketDto.Trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var trip = context.Trips
                    .Include(t => t.OriginStation)
                    .Include(t => t.DestinationStation)
                    .Include(t => t.Train)
                    .ThenInclude(t => t.TrainSeats)
                    .SingleOrDefault(t => t.OriginStation.Name == ticketDto.Trip.OriginStation &&
                                          t.DestinationStation.Name == ticketDto.Trip.DestinationStation &&
                                          t.DepartureTime == departureTime);
                if (trip == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                CustomerCard card = null;
                if (ticketDto.Card != null)
                {
                    card = context.Cards.SingleOrDefault(c => c.Name == ticketDto.Card.Name);

                    if (card == null)
                    {
                        sb.AppendLine(FailureMessage);
                        continue;
                    }
                }

                var seatingClassAbbreviation = ticketDto.Seat.Substring(0, 2);
                var quantity = int.Parse(ticketDto.Seat.Substring(2));

                var seatExists = trip.Train.TrainSeats
                    .SingleOrDefault(s => s.SeatingClass.Abbreviation == seatingClassAbbreviation && quantity <= s.Quantity);
                if (seatExists == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seat = ticketDto.Seat;

                var ticket = new Ticket
                {
                    Trip = trip,
                    CustomerCard = card,
                    Price = ticketDto.Price,
                    SeatingPlace = seat
                };

                validTickets.Add(ticket);
                sb.AppendLine(string.Format("Ticket from {0} to {1} departing at {2} imported.",
                    trip.OriginStation.Name,
                    trip.DestinationStation.Name,
                    trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
            }

            context.Tickets.AddRange(validTickets);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool isValid(object obj)
        {
            var validationContext = new ValidationContext(obj);

            var validationResult = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);

            return isValid;
        }
    }
  
}
