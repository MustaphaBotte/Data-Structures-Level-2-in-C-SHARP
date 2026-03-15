using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Jagged_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] JaggedArray = new int[5][];
            //it's just an array that stores 5 references, each pointing to a separate heap-allocated array

            JaggedArray[0] = new int[5] { 10, 20, 30, 40, 50 };
            JaggedArray[1] = new int[3] { 10, 20, 30};
            JaggedArray[2] = new int[4] { 10, 20, 30, 40 };
            JaggedArray[3] = new int[2] { 10, 20 };
            JaggedArray[4] = new int[5] { 10, 20, 30, 40, 50 };


            //NOTE : each row is independent, so rows can have different lengths


            Console.WriteLine("\n\nUsing For Loop");

            int Rows = JaggedArray.Length;
            for(int i=0; i< Rows; i++)
            {
                int InnerArrayLength = JaggedArray[i].Length;
                for (int j = 0; j < InnerArrayLength; j++)
                {
                    Console.Write($"{JaggedArray[i][j]} ");
                }
                Console.WriteLine();
            }

            // ============or use ==================
            Console.WriteLine("\n\nUsing Foreach");
            foreach (int[] InnerArray in  JaggedArray)
            {

                foreach(int Number in InnerArray)
                {
                    Console.Write($"{Number} ");
                }
                Console.WriteLine();
            }

            // ================ Using LINQ ===============

            Console.WriteLine("\n\nUsing Linq");

            var Numbers = JaggedArray.SelectMany(SubArray => SubArray);


            Console.WriteLine("Numbers>=30");
            var Filtred = Numbers.Where(num => num >= 30);
            foreach (int Number in Filtred)
            {
                Console.Write($"{Number} ");
            }
            Console.WriteLine();

            var firstElements = JaggedArray.Where(array => array.Length >= 5)
                                      .Select(array => array.First());

            Console.WriteLine("First element in long arrays");
            foreach (int Number in firstElements)
            {
                Console.Write($"{Number} ");
            }


            Console.WriteLine("\nThe Max Number         : "+  Numbers.Max());
            Console.WriteLine("The Min Number         : " + Numbers.Min());
            Console.WriteLine("The Average of Numbers : " + Numbers.Average());
            Console.WriteLine("The Total of Numbers   : " + Numbers.Sum());


        }
    }
}
