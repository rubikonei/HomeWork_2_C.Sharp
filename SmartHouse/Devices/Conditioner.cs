﻿namespace SmartHouse
{
    public class Conditioner : ClimateDevice, IFan
    {
        private int temperature;
        private bool fan;

        public Conditioner(string name, bool state, bool fan)
        {
            this.name = name;
            this.state = state;
            if (state == true)
            {
                Temperature = 22;
                Power = 2;
            }
            Fan = fan;
        }

        public override int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (value >= 15 && value <= 25 && state == true)
                {
                    temperature = value;
                }
                if (state == false)
                {
                    temperature = value;
                }
            }
        }

        public bool Fan
        {
            get
            {
                return fan;
            }
            set
            {
                if (value == true && Fan == false && state == true)
                {
                    fan = value;
                    Power += 0.2;
                }
                if (value == false && Fan == true && state == true)
                {
                    fan = value;
                    Power -= 0.2;
                }
            }
        }

        public override void On()
        {
            state = true;
            Power = 2;
            Temperature = 22;
        }

        public override void Off()
        {
            state = false;
            Power = 0;
            Temperature = 0;
        }

        public void FanOn()
        {
            Fan = true;
        }

        public void FanOff()
        {
            Fan = false;
        }

        public override void SetAutoTemperature()
        {
            if (TemperatureEnvironment >= 25 && TemperatureEnvironment <= 40)
            {
                On();
                Temperature = 22;
                Power += (TemperatureEnvironment - Temperature) * 0.05;
            }
            else
            {
                Off();
            }
        }

        public override string ToString()
        {
            string fanState;
            if (fan)
            {
                fanState = "включен";
            }
            else
            {
                fanState = "выключен";
            }
            return base.ToString() + ", температура: " + temperature + ", венитялтор: " + fanState;
        }
    }
}