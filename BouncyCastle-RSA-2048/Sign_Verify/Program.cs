using System;
using BouncyCastle_Implement;

namespace Sign_Verify
{
    class Program
    {
        static void Main(string[] args)
        {
            string Msg, Signature;
            bool Verify;
            Implement Stream = new Implement();

            Console.WriteLine("Enter message to Sign");
            Msg = Console.ReadLine();
            Signature = Stream.Sign(Msg);
            Console.WriteLine();
            Console.WriteLine("The Generated Signature is:");
            Console.WriteLine(Signature);
            Console.WriteLine();

            Console.WriteLine("Enter message to Verify Signature");
            Msg = Console.ReadLine();
            Verify = Stream.Verify(Msg);

            switch (Verify)
            {
                case true:
                    Console.WriteLine("************************");
                    Console.WriteLine("*  Signature is valid  *");
                    Console.WriteLine("************************");
                    break;

                case false:
                    Console.WriteLine("****************************");
                    Console.WriteLine("*  Signature is not valid  *");
                    Console.WriteLine("****************************");
                    break;
            }
        }
    }
}
