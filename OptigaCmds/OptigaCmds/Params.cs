using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptigaCmds
{
    internal interface Params
    {
        string Param     { set; get; }
        string InLen     { set; get; }
        string[] InData  { set; get; }
        string Sta { set; get; }
        string UnDef { set; get; }
        string OutLen { set; get; }
        string OutData { set; get; }
    }
}
