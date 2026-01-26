using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Boxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // this variable is allocated on the stack. it's that simple! but 
            int x = 100;

            // this creates an objects in the heap that contains that contains the x value
            // and the wrapper lived on the stack like a normal heap reference to that object 
            // so that's called boxing=> box the interger into an object
            //It’s like an upcast to object, but for value types it involves boxing(allocation + copy).

            // we can call it also up casting because integer is a struct and struct is inherete from the ValueType class
            // and ValueType class inherates also from object class
            Object wrapper = x;

           // ---     REAL BOXING USE CASE IN .NET
            ArrayList arr = new ArrayList();
            arr.Add(10);
            arr.Add("x");
            Console.WriteLine(arr.Count);  // 2



            // NOW TO THE UNBOXING
            // in short unboxing it's the inverse process of boxing
            // it's the process of extracting a value type from an object
            //it allows us to convert the value of the object on the heap to it's original data type like this:
            int Original_x = (int)wrapper;
            // now Original_x is an Interger
            //Note: you must convert the object to it's valid original type otherwise you will get an Error called : InvalidCastException
            Console.WriteLine(Original_x);

            // In modern .Net we're using the generics more than boxing
            // we will cover this in the next lessons
        }
    }
}
