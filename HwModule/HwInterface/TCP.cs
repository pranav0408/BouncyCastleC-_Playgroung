namespace HwInterface
{
    interface TCP
    {
        void Comms(string ip, int app_port);
        string Stat_Info { get; set; }
        short Length { get; set; }
    }
}
