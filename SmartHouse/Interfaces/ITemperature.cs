namespace SmartHouse
{
    public interface ITemperature
    {
        int Temperature { get; set; }
        void Increase();
        void Decrease();
    }
}