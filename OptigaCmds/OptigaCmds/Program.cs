using System;

namespace OptigaCmds
{
    class Program
    {
        public static void OpenApp()
        {
            string cmd;
            Console.WriteLine("Enter Cmd:");
            cmd = Console.ReadLine();

            switch (cmd)
            {
                case "01":
                    Read rd = new Read();
                    Console.WriteLine("Enter values for:");
                    Console.WriteLine("Param:");
                    rd.Param = Console.ReadLine();
                    Console.WriteLine("InLen:");
                    rd.InLen = Console.ReadLine();

                    if (rd.ValidateParam() && rd.ValidateInLen())
                    {
                        string[] InData = new string[3];
                        switch (rd.InLen)
                        {
                            case "00 02":
                                Console.WriteLine("InData:");
                                InData[0] = Console.ReadLine();
                                break;
                            case "00 06":
                                Console.WriteLine("InData:");
                                InData[0] = Console.ReadLine();
                                InData[1] = Console.ReadLine();
                                InData[2] = Console.ReadLine();
                                break;
                        }
                        rd.InData = InData;

                        if (rd.ValidateOID())
                        {
                            rd.DoTask();
                        }
                        else
                        {
                            Console.WriteLine("Sta: FF");
                            Console.WriteLine("UnDef: 00 - FF");
                            Console.WriteLine("OutLen: 00 00");
                            Console.WriteLine("OutData: ");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Sta: FF");
                        Console.WriteLine("UnDef: 00 - FF");
                        Console.WriteLine("OutLen: 00 00");
                        Console.WriteLine("OutData: ");
                    }
                    break;

                case "02":
                    Write w = new Write();
                    Console.WriteLine("Enter values for:");
                    Console.WriteLine("Param:");
                    w.Param = Console.ReadLine();
                    Console.WriteLine("InLen:");
                    w.InLen = Console.ReadLine();

                    if (w.ValidateParam() && w.ValidateInLen())
                    {
                        string[] InData = new String[3];
                        Console.WriteLine("InData:");
                        InData[0] = Console.ReadLine();
                        if (w.Param != "40")
                        {
                            InData[1] = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Ignoring Offset since it is Erase and Write.");
                            Console.WriteLine("Enter data:");
                        }
                        InData[2] = Console.ReadLine();

                        w.InData = InData;

                        if (w.ValidateOID())
                        {
                            w.DoTask();
                        }
                        else
                        {
                            Console.WriteLine("Sta: FF");
                            Console.WriteLine("UnDef: 00 - FF");
                            Console.WriteLine("OutLen: 00 00");
                            Console.WriteLine("OutData: ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sta: FF");
                        Console.WriteLine("UnDef: 00 - FF");
                        Console.WriteLine("OutLen: 00 00");
                        Console.WriteLine("OutData: ");
                    }

                    break;
                default:
                    Console.WriteLine("Not implemented");
                    break;
            }
        }
        
        public static void Main(string[] args)
        {
            do
            {
                OpenApp();
                Console.WriteLine();
            }
            while (true);
        }
    }
}
