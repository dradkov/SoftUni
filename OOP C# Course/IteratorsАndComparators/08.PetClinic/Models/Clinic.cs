﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Clinic
{


    public Clinic(string name, int rooms)
    {
        if (rooms % 2 == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }
        this.Name = name;
        this.Rooms = new Room[rooms];
        for (int i = 0; i < this.Rooms.Length; i++)
        {
            this.Rooms[i] = new Room();
        }

    }


    public string Name { get; private set; }

    public Room[] Rooms { get; set; }



    public bool AddPet(Pet pet)
    {
        int centerId = ((int)Math.Ceiling(this.Rooms.Length / (double)2)) - 1;

        if (!this.HasEmptyRooms())
        {
            return false;
        }

        int steps = 1;
        int i = centerId;
        for (int j = 0; j < this.Rooms.Length; j++)
        {
            if (this.Rooms[i].SickPet is null)
            {
                this.Rooms[i].SickPet = pet;
                return true;
            }

            if (i >= centerId)
            {
                i = centerId - steps;
            }
            else
            {
                i = centerId + steps;
                steps++;
            }
        }

        return false;


    }
  
    public bool HasEmptyRooms()
    {

        return this.Rooms.Any(r => r.SickPet is null);

    }
    public bool Release()
    {

        int centerId = ((int)Math.Ceiling(this.Rooms.Length / (double)2)) - 1;

        for (int i = centerId; i < this.Rooms.Length; i++)
        {
            if (this.Rooms[i].SickPet != null)
            {
                this.Rooms[i].SickPet = null;
                return true;
            }
        }

        for (int i = 0; i < centerId; i++)
        {
            if (this.Rooms[i].SickPet != null)
            {
                this.Rooms[i].SickPet = null;
                return true;
            }
        }

        return false;
    }
    public void Print()
    {
        Console.WriteLine(string.Join(Environment.NewLine, this.Rooms.ToList()));
    }

    public void Print(int roomId)
    {
        Console.WriteLine(this.Rooms[roomId - 1].ToString());
    }

}
