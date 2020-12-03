namespace Bulb_Interface
{
    public interface BulbInterface
    {
        void on();
        void on(int up);
        void off();
        void off(int down);
        string Bulb_Status
        {
            get;
        }
        string Bulb_Type
        {
            get;
        }
        string Bulb_Color
        {
            get;
        }
        int Bulb_Intensity
        {
            get;
        }
    }
}
