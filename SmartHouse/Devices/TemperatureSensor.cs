using System;

namespace SmartHouse
{
    public class TemperatureSensor : Device
    {
        public int temperatureEnvironment;

        public TemperatureSensor(string name, bool state)
        {
            this.name = name;
            this.state = state;
            if (state == true)
            {
                Power = 0.05;
            }
        }

        public override void On()
        {
            state = true;
            Power = 0.05;
            GetTemperature();
        }

        public override void Off()
        {
            state = false;
            Power = 0;
        }

        private void GetTemperature()
        {
            Random r = new Random();
            temperatureEnvironment = r.Next(-30, 41);
        }

        public override string ToString()
        {
            return base.ToString() + ", наружная температура: " + temperatureEnvironment;
        }
    }
}