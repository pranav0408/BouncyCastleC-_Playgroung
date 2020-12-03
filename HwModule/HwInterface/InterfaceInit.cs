using System;
using System.Xml.Linq;
using System.Collections.Generic;
namespace HwInterface
{
    public class InterfaceInit : HwInterfaceAbstract, I2C, UART, TCP
    {
        string Ip;
        int SlaveAddr, Bitrate, AppAort, Port, Baudrate;
        static readonly string InterfaceUsed;

        void I2C.Comms(int slave_addr, int bitrate)
        {
            SlaveAddr = slave_addr;
            Bitrate = bitrate;
        }
        void TCP.Comms(string ip, int app_port)
        {
            Ip = ip;
            AppAort = app_port;
        }
        void UART.Comms(int port, int baudrate)
        {
            Port = port;
            Baudrate = baudrate;
        }

        public override string Rx()
        {
            short Length = this.Length;
            string Stat_Info = this.Stat_Info;
            string protocol = InterfaceUsed;
            return ("Length of stat info is: " + Length + "\nStatus Information is: " + Stat_Info + "\nRead with interface: " + protocol);
        }
        public override string Tx(List<dynamic> data)
        {
            this.Length = data[0];
            this.Stat_Info = data[1];
            return ("Above information has been sent using interface: " + InterfaceUsed);
        }
        public InterfaceInit(){}
        static InterfaceInit()
        {
            string InterfaceType = null;
            string Ip = "192.196.23.21";
            int SlaveAddr = 23456, Bitrate = 204, AppPort = 8080, Port = 5000, Baudrate = 240;
            string file = "C:/Users/zeus811/Documents/Visual Studio 2013/Projects/HwModule/HwInterface/Config.xml";
            
            XDocument xml = XDocument.Load(file);
            InterfaceType = xml.Element("options").Element("interface").Value;
            if (InterfaceType == "i2c")
            {
                InterfaceUsed = "I2C";
                if (xml.Element("options").Element("slave_addr") != null)
                    SlaveAddr = Convert.ToInt32(xml.Element("options").Element("slave_addr").Value);
                if (xml.Element("options").Element("bitrate") != null)
                    Bitrate = Convert.ToInt32(xml.Element("options").Element("bitrate").Value);

                I2C ob = new InterfaceInit();
                ob.Comms(SlaveAddr, Bitrate);
            }
            else if (InterfaceType == "tcp")
            {
                InterfaceUsed = "TCP";
                if (xml.Element("options").Element("ip") != null)
                    Ip = xml.Element("options").Element("ip").Value;
                if (xml.Element("options").Element("app_port") != null)
                    AppPort = Convert.ToInt32(xml.Element("options").Element("app_port").Value);
                TCP ob = new InterfaceInit();
                    ob.Comms(Ip, AppPort);
            }
            else if (InterfaceType == "uart")
            {
                InterfaceUsed = "UART";
                if (xml.Element("options").Element("port") != null)
                    Port = Convert.ToInt32(xml.Element("options").Element("port") != null);
                if (xml.Element("options").Element("baudrate") != null)
                    Baudrate = Convert.ToInt32(xml.Element("options").Element("baudrate").Value);
                UART ob = new InterfaceInit();
                ob.Comms(Port, Baudrate);
            }
        } // constructor
    }
}
