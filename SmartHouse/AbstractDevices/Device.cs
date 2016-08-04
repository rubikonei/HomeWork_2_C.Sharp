namespace SmartHouse
{
    public abstract class Device
    {
        public string name;
        public bool state;
        public double Power { get; protected set; }
        public abstract void On();
        public abstract void Off();
        public override string ToString()
        {
            string state;
            if (this.state)
            {
                state = "включен";
            }
            else
            {
                state = "выключен";
            }
            return name + ": " + state + ", мощность: " + Power;
        }
    }
}