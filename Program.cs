using System;
using System.Collections.Generic;

namespace UsedCarLotLab
{

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public Car(string pMake, string pModel, int pYear, decimal pPrice)
        {
            Make = pMake;
            Model = pModel;
            Year = pYear;
            Price = pPrice;
            CarLotApp.CarLot(this);
        }


        public Car()
        {
            Make = "NA";
            Model = "NA";
            Year = 0;
            Price = 0;
            CarLotApp.CarLot(this);
        }
        public override string ToString()
        {
            return ($"{Make} {Model} {Year} {Price}");
        }

        class Used : Car
        {
            private double Mileage { get; set; }
            public Used(string pMake, string pModel, int pYear, decimal pPrice, double pMileage) : base(pMake, pModel, pYear, pPrice)
            {
                Mileage = pMileage;
            }
            public override string ToString()
            {
                return ($"{Make} {Model} {Year} {Price} (Used) {Mileage}");
            }
        }

        class CarLotApp
        {
            public static List<Car> cars = new List<Car>();

            public static void CarLot(Car selectedCar)
            {
                cars.Add(selectedCar);
            }

            public static void PurchaseCar(int i)
            {
                Console.WriteLine($"{CarLotApp.cars[i]}");
                Console.WriteLine("Would you like to buy this car? Please enter (y/n)");
                string buyCar = Console.ReadLine();

                if (buyCar == "Y" || buyCar == "y")
                {
                    Console.WriteLine("Excellent! Our finance department will be in touch shortly");
                    cars.Remove(cars[i]);
                }
                else
                {
                    return;
                }
            }


            public static void AddCar()
            {
                Console.Write("Please enter the make of the car you would like to add: ");
                string newMake = Console.ReadLine();
                Console.Write("Please enter the model of the car you would like to add: ");
                string newModel = Console.ReadLine();
                Console.Write("Please enter the year of the car you would like to add: ");
                int newYear = Int32.Parse(Console.ReadLine());
                Console.Write("Please enter the price of the car you would like to add: ");
                decimal newPrice = decimal.Parse(Console.ReadLine());
                Console.Write("Please enter the mileage of the car you would like to add: ");
                double newMileage = double.Parse(Console.ReadLine());
                new Used(newMake, newModel, newYear, newPrice, newMileage);
            }

            public List<Car> ListCars()
            {
                return cars;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
  
                bool done = false;

                Console.WriteLine($"Welcome to Grant Chirpus' Used Car Emporium!\n");
                Console.Write("  Make");
                Console.Write("    Model");
                Console.Write("   Year");
                Console.Write("  Price");
                Console.Write("           Mileage");
                Console.WriteLine("\n===============================================");
                Console.WriteLine();
                new Car("Nikolai", "Model S ", 2017, 54999.90m);
                new Car("Fourd", "  Escapade", 2017, 31999.90m);
                new Car("Chewie", " Vette   ", 2017, 44989.95m);
                new Used("Hyonda", " Prior   ", 2015, 14795.50m, 35987.60);
                new Used("GC", "     Chirpus ", 2013, 8500.00m, 12345.00);
                new Used("GC", "     Witherell",2016, 14450.00m, 3500.30);

                while (!done)
                {
                    int i = 0;
                    for (i = 0; i < CarLotApp.cars.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{CarLotApp.cars[i]}");
                    }
                    Console.WriteLine($"{CarLotApp.cars.Count + 1}. Add a car");
                    Console.WriteLine($"{CarLotApp.cars.Count + 2}. Quit");

                    Console.WriteLine("\nWhich car would you like?");
                    int userInput = Int32.Parse(Console.ReadLine());

                    if (userInput <= CarLotApp.cars.Count)
                    {
                        CarLotApp.PurchaseCar(userInput - 1);
                    }
                    else if (userInput == (CarLotApp.cars.Count + 1))
                    {
                        CarLotApp.AddCar();
                    }
                    else if (userInput == (CarLotApp.cars.Count + 2))
                    {
                        done = true;
                        Console.WriteLine("Have a great day!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                        continue;
                    }

                }

            }
        }
    }
}
