using System.Collections.Generic;

namespace SmartHouse
{
    public class ClimateControl : Device, IAutoMode
    {
        public List<IAutoTemperature> temperatureDevices;
        public TemperatureSensor sensor;

        public ClimateControl(List<IAutoTemperature> temperatureDevices, 
            TemperatureSensor sensor, string name, bool state)
        {
            this.name = name;
            this.state = state;
            this.temperatureDevices = temperatureDevices;
            this.sensor = sensor;
        }

        public override void On()
        {
            state = true;
            Power = 0.05;
        }

        public override void Off()
        {
            state = false;
            Power = 0;
            foreach (IAutoTemperature device in temperatureDevices)
            {
                ((ClimateDevice)device).Off();
            }
        }

        public void SetAutoMode()
        {
            if (sensor.state == true && state == true)
            {
                foreach (IAutoTemperature device in temperatureDevices)
                {
                    device.SetAutoTemperature(sensor.temperatureEnvironment);
                }
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}