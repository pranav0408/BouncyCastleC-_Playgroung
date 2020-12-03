namespace HwInterface
{
    interface I2C
    {
        void Comms(int slave_addr, int bitrate);
        string Stat_Info { get; set; }
        short Length { get; set; }
    }
}
