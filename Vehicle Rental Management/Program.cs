using System;
using System.Collections.Generic;

public class Vehicle
{
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public int Year { get; set; }
    public decimal RentalPrice { get; set; }

    public Vehicle(string model, string manufacturer, int year, decimal rentalPrice)
    {
        Model = model;
        Manufacturer = manufacturer;
        Year = year;
        RentalPrice = rentalPrice;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Model: {Model}, Manufacturer: {Manufacturer}, Year: {Year}, Rental Price: {RentalPrice:C}");
    }
}

public class Car : Vehicle
{
    public int Seats { get; set; }
    public string EngineType { get; set; }
    public string Transmission { get; set; }
    public bool Convertible { get; set; }

    public Car(string model, string manufacturer, int year, decimal rentalPrice, int seats, string engineType, string transmission, bool convertible)
        : base(model, manufacturer, year, rentalPrice)
    {
        Seats = seats;
        EngineType = engineType;
        Transmission = transmission;
        Convertible = convertible;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Seats: {Seats}, Engine Type: {EngineType}, Transmission: {Transmission}, Convertible: {Convertible}");
    }
}

public class Truck : Vehicle
{
    public double Capacity { get; set; }
    public string TruckType { get; set; }
    public bool FourWheelDrive { get; set; }

    public Truck(string model, string manufacturer, int year, decimal rentalPrice, double capacity, string truckType, bool fourWheelDrive)
        : base(model, manufacturer, year, rentalPrice)
    {
        Capacity = capacity;
        TruckType = truckType;
        FourWheelDrive = fourWheelDrive;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Capacity: {Capacity}, Truck Type: {TruckType}, Four Wheel Drive: {FourWheelDrive}");
    }
}

public class Motorcycle : Vehicle
{
    public double EngineCapacity { get; set; }
    public string FuelType { get; set; }
    public bool HasFairing { get; set; }

    public Motorcycle(string model, string manufacturer, int year, decimal rentalPrice, double engineCapacity, string fuelType, bool hasFairing)
        : base(model, manufacturer, year, rentalPrice)
    {
        EngineCapacity = engineCapacity;
        FuelType = fuelType;
        HasFairing = hasFairing;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Engine Capacity: {EngineCapacity}, Fuel Type: {FuelType}, Has Fairing: {HasFairing}");
    }
}

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

class Program
{
    static void Main()
    {
        RentalAgency rentalAgency = new RentalAgency();

        Car car = new Car("Model S", "Tesla", 2022, 100m, 5, "Electric", "Automatic", true);
        Truck truck = new Truck("F-150", "Ford", 2021, 150m, 1000, "Pickup", true);
        Motorcycle motorcycle = new Motorcycle("Ninja", "Kawasaki", 2020, 75m, 600, "Gasoline", true);

        rentalAgency.AddVehicle(car);
        rentalAgency.AddVehicle(truck);
        rentalAgency.AddVehicle(motorcycle);

        Console.WriteLine("Fleet:");
        rentalAgency.DisplayFleet();

        rentalAgency.RentVehicle(car);
        Console.WriteLine("\nAfter renting a car:");
        rentalAgency.DisplayFleet();

        Console.WriteLine($"\nTotal Revenue: {rentalAgency.TotalRevenue:C}");
    }
}
