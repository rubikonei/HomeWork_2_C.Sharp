namespace SmartHouse
{
    public abstract class ClimateDevice : Device, ITemperature
    {
        public int TemperatureEnvironment { get; set; }
        public abstract int Temperature { get; set; }
        
        public void Increase()
        {
            Temperature++;
        }

        public void Decrease()
        {
            Temperature--;
        }

        public abstract void SetAutoTemperature();

        public override string ToString()
        {
            return base.ToString();
        }
    }
}