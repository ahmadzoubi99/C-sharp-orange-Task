using static System.Net.Mime.MediaTypeNames;
using System.Linq;

namespace Task_Function2
{
    internal class Program
    {
        public static int GetDays(DateTime firstDate, DateTime secondDate)
        {
            TimeSpan difference = secondDate - firstDate;
            return (int)difference.TotalDays;
        }
       
        static void Main(string[] args)
        {
            //task1
            DateTime date1 = new DateTime(2019, 6, 14);
            DateTime date2 = new DateTime(2019, 6, 20);

            int daysBetween = GetDays(date1, date2);
            Console.WriteLine("Number of days between {0} and {1}: {2}", date1.ToShortDateString(), date2.ToShortDateString(), daysBetween);

            //task2
            string[] test1 = { "1a", "a", "2b", "b" };
            string[] test2 = { "abc", "abc10" };
            string[] test3 = { "no", "numbers", "here" };


            string[] NumInStr(string[] array)
            {
                List<string> result = new List<string>();
                foreach (string str in array)
                {
                    if (str.Any(char.IsDigit)){
                        result.Add(str);
                    }
                }
                return result.ToArray();
            }
            string[] result1 = NumInStr(test1);
            foreach (string str in result1)
            {
                Console.Write($"{str} ");
            }
            Console.WriteLine();
            //task3
            void reverseOddLength(string statment)
            {

                List<string> result=new List<string>();
                string[] array = statment.Split(' ');
                string str = "";
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length % 2 != 0)
                    {
                        for (int j = array[i].Length - 1; j >= 0; j--)
                        {
                            str += array[i][j];
                        }
                        result.Add((string)str);
                        str = "";
                    }

                }
                foreach (string str1 in result.ToArray())
                {
                    Console.WriteLine(str1);
                }
            }
            reverseOddLength("One two three four");

            //task4
            bool pandigitalNumber(string str)
            {
                for (int i = 0; i <= 9; i++)
                {
                    bool found = false;
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (str[j] == (char)(i + '0'))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        return false;
                    }
                }
                return true;
            }

            Console.WriteLine(pandigitalNumber("98140723568910"));
        }
    }
}
