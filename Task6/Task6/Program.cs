using Microsoft.VisualBasic;

namespace Task6
{

    public class Car
    {
        public string Make { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Model { get; set; }
        public string PalletNo { get; set; }
        public string Color { get; set; }
        private bool EngineRunning { get; set; }

        public Car(string make, int year, string type, decimal price, string model, string palletNo, string color)
        {
            Make = make;
            Year = year;
            Type = type;
            Price = price;
            Model = model;
            PalletNo = palletNo;
            Color = color;
            EngineRunning = false;
        }

        public string StartEngine()
        {
            if (!EngineRunning)
            {
                EngineRunning = true;
                return "Engine started.";
            }
            else
            {
                return "Engine is already running.";
            }
        }

        public string StopEngine()
        {
            if (EngineRunning)
            {
                EngineRunning = false;
                return "Engine stopped.";
            }
            else
            {
                return "Engine is not running.";
            }
        }

        public override string ToString()
        {
            return $"Make: {Make}, Year: {Year}, Type: {Type}, Price: {Price}, Model: {Model}, Pallet No: {PalletNo}, Color: {Color}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("Toyota", 2021, "Sedan", 30000.00m, "Camry", "12345XYZ", "Blue");

            Console.WriteLine(myCar.ToString());

            Console.WriteLine(myCar.StartEngine());
            Console.WriteLine(myCar.StopEngine());
        }
    }
}
