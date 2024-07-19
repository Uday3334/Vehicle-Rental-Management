using System;
using System.Collections.Generic;

public class RentalAgency
{
    private List<Vehicle> Fleet { get; set; } = new List<Vehicle>();
    public decimal TotalRevenue { get; private set; }

    public void AddVehicle(Vehicle vehicle)
    {
        Fleet.Add(vehicle);
        Console.WriteLine("Vehicle added to fleet.");
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        if (Fleet.Remove(vehicle))
        {
            Console.WriteLine("Vehicle removed from fleet.");
        }
        else
        {
            Console.WriteLine("Vehicle not found in fleet.");
        }
    }

    public void RentVehicle(Vehicle vehicle)
    {
        if (Fleet.Contains(vehicle))
        {
            TotalRevenue += vehicle.RentalPrice;
            Fleet.Remove(vehicle);
            Console.WriteLine("Vehicle rented successfully.");
        }
        else
        {
            Console.WriteLine("Vehicle not available for rent.");
        }
    }

    public void DisplayFleet()
    {
        foreach (var vehicle in Fleet)
        {
            vehicle.DisplayDetails();
            Console.WriteLine();
        }
    }
}
