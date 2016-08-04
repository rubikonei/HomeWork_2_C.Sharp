namespace SmartHouse
{
    public interface IFan
    {
        bool Fan { get; set; }
        void FanOn();
        void FanOff();
    }
}