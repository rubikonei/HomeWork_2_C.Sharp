namespace SmartHouse
{
    public class Convector : ClimateDevice
    {
        private int temperature;

        public Convector(string name, bool state)
        {
            this.name = name;
            this.state = state;
            if (state == true)
            {
                Temperature = 20;
                Power = 1.5;
            }
        }

        public override int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (value >= 20 && value <= 30 && state == true)
                {
                    temperature = value;
                }
                if (state == false)
                {
                    temperature = value;
                }
            }
        }

        public override void On()
        {
            state = true;
            Power = 1.5;
            Temperature = 20;
        }

        public override void Off()
        {
            state = false;
            Power = 0;
            Temperature = 0;
        }

        public override void SetAutoTemperature()
        {
            if (TemperatureEnvironment <= 10 && TemperatureEnvironment >= -30)
            {
                On();
                Temperature = 20;
                Power += (Temperature - TemperatureEnvironment) * 0.05;
            }
            else
            {
                Off();
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", температура: " + temperature;
        }
    }
}