namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 1
                string str = Console.ReadLine();
                Console.WriteLine(str);
            //-----------------------

            //task2
            double salary = 300002.2;
          
            string str1 = "ahmad";
            char chr= 'A';
            int num1 = 1;

            const double pi=3.14;
            Console.WriteLine(num1);
            Console.WriteLine(salary);
            Console.WriteLine(chr);
            Console.WriteLine(num1);
            Console.WriteLine(pi);

            //task3
            string[] car = new string[] { "Volvo", "BMW", "Ford", "Mazda" };
            for (int i = 0; i < car.Length; i++)
            {
                Console.WriteLine(car[i]);
            }
            //---------------------------------------------
            //task4
            Console.Write("First Name :");
            string firstName=Console.ReadLine();
            Console.Write("Last Name :");
            string lastName=Console.ReadLine();
            Console.Write("Enter Number of year :");
            int year=Convert.ToInt32(Console.ReadLine());
            //------------------------------------------------
            //task5

            int[] array = new int[10];
            Console.WriteLine("Input 10 elements in the array:");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"element - {i} : ");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Elements in array are:");
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
           Console.WriteLine();
            //task 6
            int[] array1=new int[4];
            int sum = 0;
            Console.WriteLine("Input 4 elements in the array:");
            for(int i = 0;i < array1.Length;i++)
            {
                array1[i]=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"element - {i} : {array1[i]} ");
                sum += array1[i];
            }
            Console.WriteLine($" Sum of all elements stored in the array is :{sum}");



        }

    }
}
