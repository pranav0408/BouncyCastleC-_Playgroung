using System;

namespace Bulb_Candescent
{
    public class Candescent : Bulb_Interface.BulbInterface
    {
        string _Bulb_Type, _Bulb_Color, _Bulb_Status;
        int _Bulb_Intensity;

        public Candescent()
        {
            this._Bulb_Type = "Candescent";
            this._Bulb_Color = "Yellow";
            this._Bulb_Intensity = 0;
            this._Bulb_Status = "off";
        }
        public void on()
        {
            this._Bulb_Status = "on";
            this._Bulb_Intensity = 100;
        }
        public void on(int up)
        {
            this._Bulb_Intensity += up;
        }
        public void off()
        {
            this._Bulb_Intensity = 0;
            this._Bulb_Status = "off";
        }
        public void off(int down)
        {
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
