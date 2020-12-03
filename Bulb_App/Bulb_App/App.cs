using System;

namespace Bulb_App
{
    public class App
    {
        public static string bulbOperation(dynamic bulb, string switch_status)
        {
            if (switch_status == "on")
            {
                if (bulb.Bulb_Status == "off")
                    bulb.on();
                else if (bulb.Bulb_Status == "on" && bulb.Bulb_Intensity == 200)
                {
                    return ("MAX Intensity Reached");
                }
                else
                    bulb.on(20);
            }
            else if (switch_status == "off")
            {
                if (bulb.Bulb_Status == "off")
                {
                    return ("Bulb is already OFF");
                }
                else if (bulb.Bulb_Status == "on" && bulb.Bulb_Intensity > 100)
                    bulb.off(20);
                else
                {
                    bulb.off();
                    return ("Bulb has been switched: " + bulb.Bulb_Status);
                }
            }
            else
            {
                return ("Invalid switching option selected");
            }
            string bulb_state = "Bulb Type is: " + bulb.Bulb_Type + "\nBulb Status is: " + bulb.Bulb_Status + "\nBulb Color is: " + bulb.Bulb_Color + "\nBulb Intensity is: " + bulb.Bulb_Intensity;
            return bulb_state;
        } // Bulb Operation


        public static void Main(String[] args)
        {
            string[] Bulb_Series = { "LED", "Candescent", "LED", "Candescent", "LED", "Candescent", "LED" }; //  { Sunday -> Saturday }
            DateTime now = DateTime.Now;

            if (Bulb_Series[(int)now.DayOfWeek] == "Candescent")
            {
                Bulb_Candescent.Candescent bulb = new Bulb_Candescent.Candescent();
                Console.WriteLine("Bulb Type is: " + bulb.Bulb_Type);
                Console.WriteLine("Bulb Status is: " + bulb.Bulb_Status);

                string switch_status, bulb_state;
                while (true)
                {
                    Console.WriteLine("Enter bulb switiching option [on/off]");
                    switch_status = Console.ReadLine();

                    bulb_state = bulbOperation(bulb, switch_status);
                    Console.WriteLine(bulb_state);
                }
            }
            else if (Bulb_Series[(int)now.DayOfWeek] == "LED")
            {
                Bulb_Led.Led bulb = new Bulb_Led.Led();
                Console.WriteLine("Bulb Type is: " + bulb.Bulb_Type);
                Console.WriteLine("Bulb Status is: " + bulb.Bulb_Status);

                string switch_status, bulb_state;
                while (true)
                {
                    Console.WriteLine("Enter bulb switiching option [on/off]");
                    switch_status = Console.ReadLine();

                    bulb_state = bulbOperation(bulb, switch_status);
                    Console.WriteLine(bulb_state);
                }
            }
        }
    }
}
