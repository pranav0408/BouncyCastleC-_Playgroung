using System;
using System.Collections.Generic;

namespace HwInterface
{
    public abstract class HwInterfaceAbstract 
    {
        string _Stat_Info = null;
        public short Length { get; set; }
        public string Stat_Info
        {
            get { return _Stat_Info; }
            set { 
                if( value.Length == 5)
                    _Stat_Info = value;
            }
        } 

        public abstract string Rx();
        public abstract string Tx(List<dynamic> data);
    }
}
