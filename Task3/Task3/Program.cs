using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Task1
      /*      int[] ARR = { 1, 7, 9, 45 };
            string[] arr2 = { "Str", "alex", "moh" };
            string[] arr3 = { "the", "fox", "over", "lazy", "dog" };


            //task2
            *//*            2 - What the index of "Banana","Tomato" ?
            *//*
            String[] fruits = { "Tomato", "Banana", "Watermelon" };
            Console.WriteLine(Index(fruits, "Banana"));

            int Index(string[] array, string str)
            {
                int index = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (array[i] == str)
                    {
                        index = i;
                    }
                }
                return index;
            }

            //task3
            string[] favoriteFood = { "Pizza", "Sushi", "Burger", "Pasta", "Ice Cream" };
            string[] favoriteSport = { "Soccer", "Basketball", "Tennis" };
            string[] favoriteMovie = { "Inception", "The Matrix", "Interstellar", "The Dark Knight" };
            void PrintArray(string[] array)
            {
                foreach (string str in array)
                {
                    Console.WriteLine(str);
                }
            }
            PrintArray(favoriteFood);
            PrintArray(favoriteSport);
            PrintArray(favoriteMovie);


            //task4

            void sumOfThreeNumber()
            {
                string inputUser = Console.ReadLine();
                string[] splitstring = inputUser.Split(',');
                int num1 = int.Parse(splitstring[0]);
                int num2 = int.Parse(splitstring[1]);
                int num3 = int.Parse(splitstring[2]);
                int sum = num1 + num2 + num3;

            }
            //task 5
            void sumOdd()
            {
                int sum = 0;
                for(int i = 0; i < 100; i++)
                {
                    if (i % 0 != 1)
                    {
                        sum += i;
                    }
                }
                Console.WriteLine(sum);
            }*/
            
            void PrintStar()
            {
                for(int i = 0;i < 3; i++)
                {
                    for (int j = 0;j <= i;j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
            PrintStar();
            void PrintStarTow()
            {
                int count = 1;

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 3; j > i; j--)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j <= i; j++)
                    {
                        Console.Write(count++);
                    }
                    Console.WriteLine();
                }
       
            }
            PrintStarTow();


        }
    }
}
