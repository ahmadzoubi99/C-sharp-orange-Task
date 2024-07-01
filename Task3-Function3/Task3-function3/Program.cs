using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace Task3_function3
{
    class task_Function3
    {
        static int add(int x, int y)
        {
            return x + y;
        }
        static string removeLeadingTrailing(string str)
        {
            

            str = str.TrimStart('0');
            if (str.Contains('.'))
            {
                str = str.TrimEnd('0');
                if (str.EndsWith("."))
                {
                    str = str.TrimEnd('.');
                }
            }
            return str;
        }
        public static int secondLargest(int[] numbers)
        {


            var sortedNumbers = numbers.OrderByDescending(x => x).ToArray();
            return sortedNumbers[1];
        }


        public static bool IsRepdigit(int num)
        {
            if (num < 0)
                return false;

            string numStr = Math.Abs(num).ToString();
            return numStr.Distinct().Count() == 1;
        }

        public static string ReverseWords(string str)
        {
            string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Array.Reverse(words);

            return String.Join(" ", words);
        }


        public static string SevenBoom(int[] arr)
        {
            foreach (int num in arr)
            {
                if (num.ToString().Contains('7'))
                {
                    return "Boom!";
                }
            }
            return "there is no 7 in the array";
        }


        public static string InsertWhitespace(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder result = new StringBuilder();
            result.Append(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]) && char.IsLower(input[i - 1]))
                {
                    result.Append(' ');
                }
                result.Append(input[i]);
            }

            return result.ToString();
        }

        public static int CountTrue(bool[] arr)
        {
            int count = 0;
            foreach (bool value in arr)
            {
                if (value)
                {
                    count++;
                }
            }
            return count;
        }

        public static string CapToFront(string s)
        {
            StringBuilder upperCase = new StringBuilder();
            StringBuilder lowerCase = new StringBuilder();

            foreach (char c in s)
            {
                if (char.IsUpper(c))
                {
                    upperCase.Append(c);
                }
                else
                {
                    lowerCase.Append(c);
                }
            }

            return upperCase.ToString() + lowerCase.ToString();
        }

        public static bool MatchLastItem(object[] items)
        {
            if (items == null || items.Length < 2)
                return false;

            StringBuilder allButLast = new StringBuilder();
            for (int i = 0; i < items.Length - 1; i++)
            {
                allButLast.Append(items[i].ToString());
            }

            return allButLast.ToString() == items[^1].ToString();
        }


        public static int FindNaN(double[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (double.IsNaN(numbers[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public static int[] RemoveDupsInts(int[] items)
        {
            List<int> uniqueItems = new List<int>();
            HashSet<int> seen = new HashSet<int>();

            foreach (int item in items)
            {
                if (seen.Add(item))
                {
                    uniqueItems.Add(item);
                }
            }

            return uniqueItems.ToArray();
        }

        public static string[] RemoveDupsStrings(string[] items)
        {
            List<string> uniqueItems = new List<string>();
            HashSet<string> seen = new HashSet<string>();

            foreach (string item in items)
            {
                if (seen.Add(item))
                {
                    uniqueItems.Add(item);
                }
            }

            return uniqueItems.ToArray();
        }


        public static string ConvertTime(string time12hr)
        {
            DateTime time = DateTime.ParseExact(time12hr, "hh:mm:sstt", CultureInfo.InvariantCulture);

            return time.ToString("HH:mm:ss");
        }


        public static string RemoveLastVowel(string sentence)
        {
            string[] words = sentence.Split(' ');
            string vowels = "aeiouAEIOU";
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = words[i].Length - 1; j >= 0; j--)
                {
                    if (vowels.Contains(words[i][j]))
                    {
                        words[i] = words[i].Substring(0, j) + words[i].Substring(j + 1);
                        break;
                    }
                }
            }
            return string.Join(" ", words);
        }


        public static int SumOfCubes(int[] nums)
        {
            int sum = 0;
            foreach (int num in nums)
            {
                sum += (int)Math.Pow(num, 3);
            }
            return sum;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

          

        }
    }
}
