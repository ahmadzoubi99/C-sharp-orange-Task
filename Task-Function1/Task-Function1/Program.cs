using System.Data;

namespace Task_Function1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //task1
            void MinutesToSeconds(int minutes)
            {
                Console.WriteLine(minutes * 60);
            }
            MinutesToSeconds(30);

            //task2
            int increments(int number)
            {
                return ++number;
            }

            //task3
            int FirstIndex(int[] number)
            {
                return number[0];
            }

            //task4
            double AreaTriangle(int baseTriangle, int height)
            {

                return (.5 * baseTriangle * height);
            }

            //task5
            int[] evenNumberEvenIndex(int[] number)
            {
                int count = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] % 2 == 0 && i % 2 == 0)
                    {
                        count++;
                    }
                }
                int[] evenArray = new int[count];
                count = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] % 2 == 0 && i % 2 == 0)
                    {
                        evenArray[count++] = number[i];
                    }
                }
                return evenArray;
            }

            int[] nums = { 5, 2, 2, 1, 8, 66, 55, 77, 34, 9, 55, 1 };
            foreach (int i in evenNumberEvenIndex(nums))
            {
                Console.WriteLine(i);
            }

            //task6
            string[] evenIndexOddLength(string[] array)
            {
                int count = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length % 2 != 0 && i % 2 == 0)
                    {
                        count++;
                    }
                }
                string[] oddLength = new string[count];
                count = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length % 2 != 0 && i % 2 == 0)
                    {
                        oddLength[count++] = array[i];
                    }
                }
                return oddLength;
            }
            string[] array = {"alex", "mercer", "madrasa", "rashed2", "emad", "hala"};
            foreach (string i in evenIndexOddLength(array))
            {
                Console.WriteLine(i);
            }


            //task7
            double[] PowerOfIndex(double[] nums)
            {
                for(int i = 0;i < nums.Length;i++)
                {
                    nums[i] = Math.Pow(nums[i],i);
                }
                return nums;
            }
            double[] nums2 = { 44, 5, 4, 3, 2, 10 };
            foreach (int i in PowerOfIndex(nums2))
            {
                Console.Write($" {i}   ");
            }
            Console.WriteLine();    
            //task8
            int multiplication(int num1,int num2)
            {
                return (num1 * num2) ;
            }
            
           Console.WriteLine(multiplication(5, 4));

            //task9
            int muti2(int num1,int num2)
            {
                int num = 1;
                for (int i = num1; i <=num2; i++)
                {
                    num *= i;
                }
                return num;
            }
            Console.WriteLine(muti2(3, 6));

            //task10
            double AVG(int[] nums)
            {
                double avg = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    avg += nums[i];
                }
                return avg/nums.Length;
            }
            int[] numaray1={1,4,3,8,9};
           Console.WriteLine(AVG(numaray1));
        }
    }
}
