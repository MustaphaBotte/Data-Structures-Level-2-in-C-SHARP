using System.Collections;
using System.Globalization;
using System.Text;

namespace BIt_Array
{
    internal class Program
    {
        private static void PrintTheBits(BitArray Bits)
        {
            Console.WriteLine(" ============== Printing The Bist =================");
            for(int i=0; i<Bits.Count;i++)
            {
                Console.WriteLine($" Bit In Index {i} = {Bits[i]} ");

            }
            Console.WriteLine(" ==================================================");
        }

        private static string BitArrayToString(BitArray Bits)
        {
            StringBuilder stringBuilder = new StringBuilder(Bits.Length);

            int length = Bits.Length;
            for (int i=0;i<length;i++)
            {
                stringBuilder.Append( Bits[i] ? '1' : '0');
            }
            return stringBuilder.ToString();
        }

        static void Main(string[] args)
        {

            // Create a Bit Array of ten Bits

            BitArray Bits = new BitArray(10);
            PrintTheBits(Bits);


            // Create a BitArray from an array of booleans 
            bool[] booleans = new bool[5] { true, false, true, false, true };
            BitArray Bits2 = new BitArray(booleans);

            PrintTheBits(Bits2);

            byte[] byteArray ={ 0xAA, 0x55 };
            BitArray Bits3 = new BitArray(byteArray);

            PrintTheBits(Bits3);


            Console.WriteLine("Modifying the index 2 in Bits ");
            Bits[2] = !Bits[2];
            //  Or using the class method:
            Bits.Set(2, true);
            PrintTheBits(Bits);
            Bits.SetAll(true); // set all the bits to true;

            Console.WriteLine("All bits are on ? "+(Bits.HasAllSet()? "Yes ":"No"));

            Bits.SetAll(false);
            Console.WriteLine("has at least one bit on  ? " + (Bits.HasAnySet() ? "Yes " : "No"));



            Bits.Length = Bits.Length * 2; // double the count of the elements and set the new ones to false
            Console.WriteLine($"Total bits in the array {Bits.Length}"); // output : 20
            PrintTheBits(Bits);

            // This Class uses internally an array of integers for less memory usage 
            // compared to using an array of booleans : (an int can store 32 element 4Bytes * 8 )


            Console.WriteLine("=================== Bitwise Operators:=====================");

            BitArray booleans1 = new BitArray(new bool[5] { true, false, true, false, true });
            BitArray booleans2 = new BitArray(new bool[5] { false, true, true, true, true });



            Console.WriteLine("booleans1  : " + BitArrayToString(booleans1));
            Console.WriteLine("booleans2  : " + BitArrayToString(booleans2));
            booleans1.And(booleans2);
            Console.WriteLine("BitwiseAnd : " + BitArrayToString(booleans1));




            Console.WriteLine("\nbooleans1  : " + BitArrayToString(booleans1));
            Console.WriteLine("booleans2  : " + BitArrayToString(booleans2));
            booleans1.Or(booleans2);
            Console.WriteLine("BitwiseOr  : " + BitArrayToString(booleans1));



            Console.WriteLine("\nbooleans1   : " + BitArrayToString(booleans1));
            Console.WriteLine("booleans2   : " + BitArrayToString(booleans2));
            booleans1.Xor(booleans2);
            Console.WriteLine("Xor         : " + BitArrayToString(booleans1));


            Console.WriteLine("\nbooleans1   : " + BitArrayToString(booleans1));
            booleans1.Not();
            Console.WriteLine("Not         : " +   BitArrayToString(booleans1));





            // example of permissions
            // 1 = read  , 2 = update  ,  3 = insert, 4 = delete

            bool[] UserPermissions = new bool[4] { true, true, true, false};

            BitArray Permissions = new BitArray(UserPermissions);


            Console.WriteLine("\nPermissions   : " + BitArrayToString(Permissions));

            BitArray temp = new BitArray(4, true);

            temp.And(Permissions);
            Console.WriteLine("Can read   ? " + (temp[0]?"Yes":"No"));
            Console.WriteLine("Can update ? " + (temp[1]?"Yes":"No"));
            Console.WriteLine("Can insert ? " + (temp[2]?"Yes":"No"));
            Console.WriteLine("Can delete ? " + (temp[3]?"Yes":"No"));

        }
    }
}
