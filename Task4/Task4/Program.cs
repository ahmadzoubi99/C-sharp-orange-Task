using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Task1
            void PrintSumAndAVG()
            {
                double sum = 0;
                double num;
                for (int i = 1; i <= 10; i++)
                {
                    Console.Write("Number-" + i + ": ");
                    num = Convert.ToInt32(Console.ReadLine());
                    sum += num;

                }
                Console.WriteLine($"the sum:{sum}");
                Console.WriteLine($"AVG is:{sum / 10}");

            }
            PrintSumAndAVG();

            void Cube(int num)
            {
                for (int i = 1; i <= num; i++)
                {
                    Console.WriteLine($"Number is : {i} and cube of the {i} is :{i * i * i}");
                }
            }
            Cube(5);





            //Task3

            int[] years = { 1763, 1972, 1925, 1916, 1984, 1124, 1950, 2020 };
            List<int> getYears(int[] year)
            {
                List<int> list = new List<int>();
                for (int i = 0; i < year.Length; i++)
                {
                    if (year[i] > 1950)
                    {
                        list.Add(year[i]);
                    }
                }
                return list;
            }
            foreach (int year in getYears(years))
            {
                Console.WriteLine(year);
            }




            //task 4
            int ageInDays(int ageInYear)
            {
                return 365 * ageInYear;
            }


            //Task5
            int CountLegs(int chickens, int cows, int pigs)
            {
                int allLegs = chickens * 2 + cows * 4 + pigs * 4;
                return allLegs;
            }



            //task6

            void login(string username, string password)
            {
                var users = new List<(string Username, string Password)>
        {
            ("user1", "password1"),
            ("user2", "password2")
        };

                // Check if the user exists with the correct password
                foreach (var user in users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        Console.WriteLine("Pass");
                    }
                }
                Console.WriteLine("Failed");
            }


            //task7

            void powerOfNumber(int number, int power)
            {
                Console.WriteLine(Math.Pow(number, power));
            }


            //task8
            string LeepYear(int year)
            {
                if (year < 1900 || year > 2024)
                {
                    return "Year out of range";
                }

                // Check if the year is a leap year
                if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                {
                    return "Leap year";
                }

                return "Not a leap year";

            }

            //task9
            void CheckPrimeNumbers(int number)
            {

                for (int i = 2; i < number ; i++)
                {
                    if (number % i != 0)
                    {
                        Console.WriteLine($"{number} is prime number");
                            break;
                    }
                    else
                    {
                        Console.WriteLine($"{number} not prime number");
                        break;

                    }
                }
            }
            CheckPrimeNumbers(5);

            //task10
            int numberOfWord(string sentence)
            {

                string[] word= sentence.Split(' ');
                return word.Length;
            }
            Console.WriteLine(numberOfWord("ahmad alzoubi"));
        
        }

          
    }
}
