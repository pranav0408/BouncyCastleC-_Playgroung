namespace HwInterface
{
    interface UART
    {
        void Comms(int port, int baudrate);
        string Stat_Info { get; set; }
        short Length { get; set; }
    }
}
