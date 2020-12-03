using System;

namespace OptigaCmds
{
    public class Read : AbsPerform, Params
    {
        public string Param
        {
            set;
            get;
        }
        public string InLen
        {
            set;
            get;
        }
        public string[] InData
        {
            set;
            get;
        }
        public string Sta
        {
            set;
            get;
        }
        public string UnDef
        {
            set;
            get;
        }
        public string OutLen
        {
            set;
            get;
        }
        public string OutData
        {
            set;
            get;
        }
        
        public override bool ValidateParam()
        {
            switch (Param)
            {
                case "00":
                    return true;
                case "01":
                    return true;
                default:
                    Console.WriteLine("Err: Invalid Param");
                    return false;
            }
        }
        public override bool ValidateInLen()
        {
            switch (InLen)
            {
                case "00 02":
                    return true;
                case "00 06":
                    if (Param != "00")
                    {
                        Console.WriteLine("Err: Read Metadata has incorrect InLen");
                        return false;
                    }                       
                    else
                        return true;
                default:
                    Console.WriteLine("Err: Invalid InLen");
                    return false;
            }
        }
        public override bool ValidateOID()
        {
            switch (InData[0])
            {
                case "E0 E1":
                    return true;
                case "e0 e1":
                    return true;
                default:
                    Console.WriteLine("Err: Invalid OID");
                    return false;
            }
        }
        public override void DoTask()
        {
            switch (Param)
            {
                case "00":
                    
                    //inner switch InLen for Param case 00
                    switch (InLen)
                    {
                        case "00 02":
                                Console.WriteLine("Sta: 00");
                                Console.WriteLine("UnDef: 00 - FF");
                                Console.WriteLine("OutLen: " + E0E1.Len);
                                Console.WriteLine("OutData: " + E0E1.Data);
                                break;

                        case "00 06":
                                
                                /* some calculation for start index and end index using offset */

                                Console.WriteLine("Sta: 00");
                                Console.WriteLine("UnDef: 00 - FF");
                                if (InData[2].CompareTo(E0E1.Len) > 1)
                                {
                                    Console.WriteLine("OutLen: " + E0E1.Len);
                                }
                                else
                                {
                                    Console.WriteLine("OutLen: " + InData[2]);
                                }
                                Console.WriteLine("OutData: " + E0E1.Data);
                                break;
                    }

                    // switch Param 00 break
                    break;

                case "01":
                    string metaData = "";
                    foreach(var kvp in E0E1.MetaData ){
                        metaData += kvp.Key + " " + kvp.Value + " ";
                    }
                    int len = ((metaData.Trim().Replace(" ", "").Length) / 2);

                    Console.WriteLine("Sta: 00");
                    Console.WriteLine("Undef: 00 - FF");
                    Console.WriteLine("OutLen: " + (len + 2).ToString("X2") );
                    Console.WriteLine("OutData: " + "20 " + len.ToString("X2") + " " + metaData );
                    break;
            }
        }
    }
}
