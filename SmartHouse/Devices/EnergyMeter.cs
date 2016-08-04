using System.Collections.Generic;

namespace SmartHouse
{
    public class EnergyMeter : Device, ICountEnergy
    {
        public double AllPower;

        public EnergyMeter(string name, bool state)
        {
            this.name = name;
            this.state = state;
        }

        public override void On()
        {
            state = true;
            Power = 0.05;
        }

        public override void Off()
        {
            // no realisation, it's energy meter, it always has to be turned on!
        }

        public void CountEnergy(Dictionary<string, Device> devices) 
        {
            AllPower = 0;
            foreach (KeyValuePair<string, Device> device in devices)
            {
                AllPower += device.Value.Power;
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", потребляемая эл-гия: " + AllPower;
        }
    }
}