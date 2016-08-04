namespace SmartHouse
{
    public abstract class ClimateDevice : Device, ITemperature, IAutoTemperature
    {
        public abstract int Temperature { get; set; }

        public void Increase()
        {
            Temperature++;
        }

        public void Decrease()
        {
            Temperature--;
        }

        public abstract void SetAutoTemperature(int temperatureEnvironment);

        public override string ToString()
        {
            return base.ToString();
        }
    }
}