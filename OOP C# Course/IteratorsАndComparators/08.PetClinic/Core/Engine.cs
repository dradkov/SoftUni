
using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{

    private IList<Pet> pets;
    private IList<Clinic> clinics;

    public Engine()
    {
        this.pets = new List<Pet>();
        this.clinics = new List<Clinic>();
    }

    public void Run()
    {
        int numCommand = int.Parse(Console.ReadLine());


        for (int i = 0; i < numCommand; i++)
        {


            try
            {
                string[] command = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Create":
                        {
                            if (command[1] == "Pet")
                            {
                                pets.Add(new Pet(command[2], int.Parse(command[3]), command[4]));
                            }
                            else if (command[1] == "Clinic")
                            {
                                clinics.Add(new Clinic(command[2], int.Parse(command[3])));
                            }
                        }
                        break;

                    case "Add":
                        var petName = command[1];
                        var clinicName = command[2];

                        Console.WriteLine(clinics.First(c => c.Name == clinicName).AddPet(pets.First(p => p.Name == petName)));
                        break;
                    case "Release":
                        clinicName = command[1];

                        Console.WriteLine(clinics.First(c => c.Name == clinicName).Release());
                        break;
                    case "Print":
                        {
                            if (command.Length == 2)
                            {
                                clinicName = command[1];
                                var clinic = clinics.First(c => c.Name == clinicName);
                                clinic.Print();

                            }
                            else
                            {
                                clinicName = command[1];
                                var roomId = int.Parse(command[2]);
                                var clinic = clinics.First(c => c.Name == clinicName);
                                clinic.Print(roomId);
                            }
                        }
                        break;
                    default:
                        throw new InvalidOperationException("Invalid Operation!");
                        


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }
    }
}
