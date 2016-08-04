namespace SmartHouse
{
    public class Convector : ClimateDevice
    {
        private int temperature;

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

        public override void SetAutoTemperature(int temperatureEnvironment)
        {
            if (temperatureEnvironment <= 10 && temperatureEnvironment >= -30)
            {
                On();
                Temperature = 20;
                Power += (Temperature - temperatureEnvironment) * 0.05;
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