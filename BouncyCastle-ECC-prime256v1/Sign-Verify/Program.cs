using System;
using System.Text;
using BouncyCastle_Implement;

namespace Sign_Verify
{
    class Program
    {
        static void Main(string[] args)
        {
            string Msg;
            byte[] sig;
            bool Verify;
            Implement Stream = new Implement();
            
            Console.WriteLine("Enter message to Sign");
            Msg = Console.ReadLine();
            sig = Stream.Sign(Msg);
            
       
            
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
