namespace SmartHouse
{
    public abstract class Device
    {
        protected string name;
        protected bool state;

        private double power;

        public abstract void On();
        public abstract void Off();

        public double Power
        {
            get
            {
                return power;
            }
            set
            {
                if (value >= 0)
                {
                    power = value;
                }
            }
        }

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