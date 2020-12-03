using System;

namespace OptigaCmds
{
    public class Write : AbsPerform, Params
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
                case "02":
                    Console.WriteLine("Param 0x02 -> Not Implemented");
                    return false;
                case "40":
                    return true;
                default:
                    Console.WriteLine("Err: Invalid Param");
                    return false;
            }
        }
        public override bool ValidateInLen()
        {
            bool flag = false;
            if (InLen.CompareTo("00 04") > 0)
            {
                flag = true;
            }
            else
            {
                Console.WriteLine("Err: Invalid Length");
            }
            return flag;
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
                    E0E1.Data = InData[2];    
                    Console.WriteLine("Sta: 00");
                    Console.WriteLine("UnDef: 00 - FF");
                    Console.WriteLine("OutLen: 00 00");
                    Console.WriteLine("OutData: ");
                    break;

                case "01":
                    //D0 03 E1 FC 07
                    string key = InData[2].Substring(0, 2);
                    string value = InData[2].Substring(3);

                    if (InData[1] != "00 00")
                    {
                        Console.WriteLine("Err: Invalid Offset Value");
                        Console.WriteLine("Sta: FF");
                        Console.WriteLine("UnDef: 00 - FF");
                        Console.WriteLine("OutLen: 00 00");
                        Console.WriteLine("OutData: ");
                        return;
                    }

                    if (E0E1.MetaData.ContainsKey(key))
                    {
                        E0E1.MetaData[key] = value;
                        Console.WriteLine("Sta: 00");
                        Console.WriteLine("UnDef: 00 - FF");
                        Console.WriteLine("OutLen: 00 00");
                        Console.WriteLine("OutData: ");
                    }
                    else
                    {
                        Console.WriteLine("Err: Invalid MetaData TAG");
                        Console.WriteLine("Sta: FF");
                        Console.WriteLine("UnDef: 00 - FF");
                        Console.WriteLine("OutLen: 00 00");
                        Console.WriteLine("OutData: ");
                    }
                    break;

                case "40":
                    E0E1.Data = InData[2];
                    E0E1.Len = (InData[2].Replace(" ", "").Length / 2).ToString("X4").Insert(2," ");
                    E0E1.MetaData["C5"] = "02 " + E0E1.Len;
                    Console.WriteLine("Sta: 00");
                    Console.WriteLine("UnDef: 00 - FF");
                    Console.WriteLine("OutLen: 00 00");
                    Console.WriteLine("OutData: ");
                    break;
            }
        }
    }
}
