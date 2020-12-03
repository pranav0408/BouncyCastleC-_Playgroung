using System;

namespace Bulb_Led
{
    public class Led : Bulb_Interface.BulbInterface
    {
        string _Bulb_Type, _Bulb_Color, _Bulb_Status;
        int _Bulb_Intensity;
        public Led()
        {
            int hour = DateTime.Now.Hour;
            this._Bulb_Type = "LED";
            this._Bulb_Intensity = 0;
            this._Bulb_Status = "off";
            if (hour > 0 && hour <= 3)
                this._Bulb_Color = "Violet";
            if (hour >= 4 && hour <= 7)
                this._Bulb_Color = "Indigo";
            if (hour >= 8 && hour <= 11)
                this._Bulb_Color = "Blue";
            if (hour >= 12 && hour <= 15)
                this._Bulb_Color = "Green";
            if (hour >= 16 && hour <= 19)
                this._Bulb_Color = "Yellow";
            if (hour >= 20 && hour <= 23)
                this._Bulb_Color = "Orange";
            if (hour == 0)
                this._Bulb_Color = "Red";
        }
        public void on()
        {
            this._Bulb_Status = "on";
            this._Bulb_Intensity = 100;
        }
        public void on(int up)
        {
            if (this._Bulb_Intensity < 200)
                this._Bulb_Intensity += up;
        }
        public void off()
        {
            this._Bulb_Intensity = 0;
            this._Bulb_Status = "off";
        }
        public void off(int down)
        {
            if (this._Bulb_Intensity > 100)
                this._Bulb_Intensity -= down;
        }
        public string Bulb_Status
        {
            get { return _Bulb_Status; }
        }
        public string Bulb_Type
        {
            get { return _Bulb_Type; }
        }
        public string Bulb_Color
        {
            get { return _Bulb_Color; }
        }
        public int Bulb_Intensity
        {
            get { return _Bulb_Intensity; }
        }
    }
}
