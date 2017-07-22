namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LotParking
    {
        static void Main()
        {
            var carsInfo = Console.ReadLine();

            var parkingLog = new HashSet<string>();
                

            while (carsInfo != "END")
            {
                var carsLog = carsInfo
                    .Split(new[] { ',',' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                var direction = carsLog[0];
                var licencePlate = carsLog[1];

                if (direction=="IN")
                {
                    parkingLog.Add(licencePlate);
                }
                else
                {
                    if (parkingLog.Count>0)
                    {
                        parkingLog.Remove(licencePlate);
                    }
                }
                carsInfo = Console.ReadLine();
            }
            if (parkingLog.Any())
            {
                foreach (var plate in parkingLog.OrderBy(p => p))
                {
                    Console.WriteLine(plate);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            
        }
    }
}
