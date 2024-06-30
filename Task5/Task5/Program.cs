namespace Task5
{

    class Task1
    {
        public Task1()
        {
            Console.WriteLine("MyClass class has initialized!");
        }
    }

    class Task2
    {
        // Method to display the introductory message
        public void DisplayMessage(string name)
        {
            Console.WriteLine($"Hello All, I am {name}");
        }
    }

    class Task3
    {
        public void factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Factorial is not defined for negative numbers.");
            }

            int result = 1;

            for (int i = number; i > 0; i--)
            {
                result *= i;
            }

            Console.WriteLine($"Factorial of {number} is: {result}");
        }
    }


    class Task4
    {
        public void SortArray(int[] array)
        {
            // Sort the array using Array.Sort method
            Array.Sort(array);

            // Print the sorted array
            Console.Write("Sorted array: { ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}");
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" }");
        }
    }
    class Task5
    {
            private DateTime date1;
            private DateTime date2;

            public Task5(DateTime date1, DateTime date2)
            {
                this.date1 = date1;
                this.date2 = date2;
            }

            public void CalculateDifference()
            {
                TimeSpan difference = date2 - date1;

                DateTime differenceDateTime = DateTime.MinValue + difference;

                Console.WriteLine($"Difference: {differenceDateTime.Year - 1} years, {differenceDateTime.Month - 1} months, {differenceDateTime.Day - 1} days.");
            }
        }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1 task1 = new Task1();

            Task2 task2 = new Task2();
            task2.DisplayMessage("ahmad");

            Task3 task3 = new Task3();
            task3.factorial(5);

            Task4 task4 = new Task4();
            int[] array = { 11, -2, 4, 35, 0, 8, -9 };
            task4.SortArray(array);

            DateTime date1 = new DateTime(1981, 11, 03);
            DateTime date2 = new DateTime(2013, 09, 04);

            Task5 calculator = new Task5(date1, date2);

            calculator.CalculateDifference();

            string dateString = "12-08-2004";

            DateTime date = DateTime.ParseExact(dateString, "dd-MM-yyyy", null);
            Console.WriteLine($"Converted Date: {date:yyyy-MM-dd}");

            DateTime dateTime = DateTime.ParseExact(dateString, "dd-MM-yyyy", null);
            Console.WriteLine($"Converted DateTime: {dateTime:yyyy-MM-dd HH:mm:ss}");
        }
    }
}
