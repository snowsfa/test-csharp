using System;

namespace TestCSharp.Question2
{
    static class Program
    {
        static void Main(string[] args)
        {
            Car car;
            int model, mileage;

            try
            {
                // parse and validate from input
                try
                {
                    model = int.Parse(Console.ReadLine());
                    if (model < 0 || model > 2)
                    {
                        throw new Exception("Model must be between 0 and 2 inclusive.");
                    }

                    mileage = int.Parse(Console.ReadLine());
                    if (mileage < 5 || mileage > 30)
                    {
                        throw new Exception("Mileage must be between 5 and 30 inclusive.");
                    }
                }
                catch (FormatException)
                {
                    throw new Exception("Model and Mileage must be numeric.");
                }

                // instantiate car
                switch (model)
                {
                    case 1:
                        car = new HondaCity(mileage);
                        break;
                    case 2:
                        car = new InnovaCrysta(mileage);
                        break;
                    default: // 0
                        car = new WagonR(mileage);
                        break;
                }

                // print full description
                string description = $"A {car.GetType().Name} is{(!car.getIsSedan() ? " not" : "")} Sedan, is {car.getSeats()}-seater, and has a mileage of around {car.getMileage()}.";
                Console.WriteLine(description);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
