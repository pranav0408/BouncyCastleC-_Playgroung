using System;
using System.Collections.Generic;
namespace HwImplement
{
    class HwCommands 
    {     
        public static void Main(string[] args)
        {

            HwInterface.InterfaceInit data = new HwInterface.InterfaceInit();
            byte input;
            short length;
            string stat_info;
            string result;

            while (true)
            {

                Console.WriteLine("Enter 0 to read\nEnter 1 to write");
                try
                {
                    input = Convert.ToByte(Console.ReadLine());
                    if (input == 0)
                    {
                        result = data.Rx();
                        Console.WriteLine(result);
                    }
                    else if (input == 1)
                    {
                        Console.WriteLine("Enter length of status info");
                        length = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Enter status info");
                        stat_info = Console.ReadLine();
                        List<dynamic> stream = new List<dynamic>();
                        stream.Add(length);
                        stream.Add(stat_info);

                        result = data.Tx(stream);
                        Console.WriteLine(result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    continue;
                }
            } // while
        } // main
    }
}
