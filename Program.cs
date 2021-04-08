using System;
using System.Collections.Generic;

namespace Lab5._3UsedCarLot
{
    class Car
    {
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public double price { get; set; }
        public Car(string aMake, string aModel, int aYear, double aPrice)
        {
            make = aMake;
            model = aModel;
            year = aYear;
            price = aPrice;
        }
        public Car()
        {

        }
        public override string ToString()
        {
            return $"{make}\t{model}\t{year}\t{price}"; //Need to create a formatted string with the car details
        }
    }
    class UsedCar : Car
    {
        public double mileage { get; set; }

        public UsedCar(string aMake, string aModel, int aYear, double aPrice, double aMileage) : base(aMake, aModel, aYear, aPrice)
        {
            make = aMake;
            model = aModel;
            year = aYear;
            price = aPrice;
            mileage = aMileage;
        }
        public override string ToString()
        {
            return $"{make}\t{model}\t{year}\t{price}\t(Used)\t{mileage}"; //Need to create a formatted string with the car details, including mileage
        }

    }
    class NewCar : Car
    {
        public NewCar(string aMake, string aModel, int aYear, double aPrice): base(aMake, aModel, aYear, aPrice)
        {
            make = aMake;
            model = aModel;
            year = aYear;
            price = aPrice;
        }
    }
    class CarLot
    {
        public static List<Car> cars = new List<Car>();
        public CarLot()
        {

        }
        public static void AddCar(Car newCar)
        {
            cars.Add(newCar);
        }
        public static void RemoveCar(Car carToRemove)
        {
            cars.Remove(carToRemove);
        }
        public static void ListCars(List<Car> carsInLot)
        {
            int carNum = 1;
            foreach (Car item in cars)
            {
                Console.WriteLine($"{carNum}\t" + item.ToString()); 
                carNum++;
            }
            Console.WriteLine($"{carNum}.\tAdd a car");
            Console.WriteLine($"{carNum + 1}.\tQuit");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Kyle Nedbal's Used Car Emporium!");
            Console.WriteLine();

            CarLot.cars.Add(new NewCar("Tesla", "Roadster", 2021, 130000.00));
            CarLot.cars.Add(new NewCar("Ford", "Mustang Mach-EV", 2021, 42500.00));
            CarLot.cars.Add(new NewCar("GMC", "Hummer EV", 2021, 105000.00));
            CarLot.cars.Add(new UsedCar("Lincoln", "Continental", 2018, 32000.00, 25000.00));
            CarLot.cars.Add(new UsedCar("Chevrolet", "Blazer RS", 2019, 29000.00, 36000.00));
            CarLot.cars.Add(new UsedCar("Jeep", "Grand Cherokee", 2017, 28000.00, 40000.00));

            bool userWantsToContinue = true;
            bool userChoice;
            do
            {
                do
                {
                    CarLot.ListCars(CarLot.cars);
                    Console.Write("Which car would you like?: ");
                    int validUserChoice;
                    userChoice = Int32.TryParse(Console.ReadLine(), out validUserChoice);
                    Console.WriteLine();

                    if (userChoice && validUserChoice > 0 && validUserChoice <= CarLot.cars.Count + 2)
                    {
                        if (validUserChoice > 0 && validUserChoice <= CarLot.cars.Count)
                        {
                            CarLot.cars[validUserChoice - 1].ToString();

                            Console.Write("Would you like to buy this car? (y/n): ");
                            string buyYN = Console.ReadLine().ToLower();
                            while (buyYN != "n" && buyYN != "y")
                            {
                                Console.Write("Please enter y or n to choose whether you'd like to buy this car: ");
                                buyYN = Console.ReadLine().ToLower();
                            }

                            if (buyYN == "y")
                            {
                                CarLot.RemoveCar(CarLot.cars[validUserChoice - 1]);
                                Console.WriteLine("Excellent! Our finance department will be in touch shortly");
                                Console.WriteLine();
                            }
                        }

                        else if (validUserChoice == CarLot.cars.Count + 1)
                        {
                            Console.Write("Enter the make: ");
                            string userMake = Console.ReadLine();
                            Console.Write("Enter the model: ");
                            string userModel = Console.ReadLine();
                            Console.Write("Enter the year: ");
                            int userYear = Int32.Parse(Console.ReadLine());
                            Console.Write("Enter the value of the car: ");
                            double userPrice = Double.Parse(Console.ReadLine());
                            Console.Write("Enter the mileage: ");
                            double userMileage = Double.Parse(Console.ReadLine());

                            CarLot.AddCar(new UsedCar(userMake, userModel, userYear, userPrice, userMileage));
                        }
                        else
                        {
                            userWantsToContinue = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter the corresponding number to your choice showing on the list");
                    }
                } while (userChoice == false);

            } while (userWantsToContinue == true);

            Console.WriteLine("Have a great day!");
        }
    }
}
