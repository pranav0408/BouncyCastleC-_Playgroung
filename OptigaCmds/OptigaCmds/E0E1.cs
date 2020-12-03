using System;
using System.Collections.Generic;

namespace OptigaCmds
{
    public class E0E1
    {
        public  static string Data = "01 02 03 04 05 06 07 08";
        public static string Len = "06 C0";
        public static Dictionary<string, string> MetaData = new Dictionary<string, string>(){
            {"D0","03 E1 FC 07"},
            {"D1","01 00"},
            {"D3","01 00"},
            {"C0","01 01"},
            {"C4","02 06 C0"},
            {"C5","02 06 C0"},
            {"E8","01 12"}
        };
    }
}
