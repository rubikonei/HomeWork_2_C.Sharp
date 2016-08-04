namespace SmartHouse
{
    public interface IVolume
    {
        int Volume { get; set; }
        void Increase();
        void Decrease();
    }
}