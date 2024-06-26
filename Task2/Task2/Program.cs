using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Task2
{
    internal class Program
    {
        public void task5(int num1, int num2, int num3, int num4, int num5)
        {
            int max = num1;
            if (num2 > max)
            {
                max = num2;
            }
            if (num3 > max)
            {
                max = num3;
            }
            if (num4 > max)
            {
                max = num4;
            }
            if (num5 > max)
            {
                max = num5;
            }



        }
        
        public  double task6(double kilometers)
        {
            int miles= kilometers*
            return
        }
        static void Main(string[] args)
        {
           //task1
            int  num1=Convert.ToInt32(Console.ReadLine());
            int num2=Convert.ToInt32(Console.ReadLine());
            if (num1 > num2) { Console.WriteLine($" num2 is smaller than num1"); }
            else if (num1 < num2) { Console.WriteLine($"num1 is smaller than num2"); }
            else { Console.WriteLine("num1 is equal num2"); }
            //----------------
            //task2
            int num3 = Convert.ToInt32(Console.ReadLine());
            if (num3 > 0) { Console.WriteLine(" The sign is + "); }
            if (num3 < 0) { Console.WriteLine(" The sign is - "); }
            if (num3 == 0) { Console.WriteLine(" The sign is = "); }
            

            //task3
            int num4 = Convert.ToInt32(Console.ReadLine());
            int num5 = Convert.ToInt32(Console.ReadLine());
            int num6 = Convert.ToInt32(Console.ReadLine());
            if (num4 < num5)
            {
                if (num4 > num6)
                {
                    Console.WriteLine($"{num5} {num4} {num6}");
                }
                else
                {
                    Console.WriteLine($"{num5} {num6} {num4}");

                }
            }
            if (num5 < num4)
            {
                if (num5 > num6)
                {
                    Console.WriteLine($"{num4} {num5} {num6}");
                }
                else
                {
                    Console.WriteLine($"{num4} {num6} {num5}");

                }
            }
            if (num6 < num4)
            {
                if (num5 > num6)
                {
                    Console.WriteLine($"{num6} {num5} {num6}");
                }
                else
                {
                    Console.WriteLine($"{num6} {num6} {num5}");

                }
            }

            //task 5
           

        }
    }
}
