using System;

namespace SmartHouse
{
    public class MotionSensor : Device, IAlarmed
    {
        private bool isAlarm;
        private string info;

        public MotionSensor(string name, bool state)
        {
            this.name = name;
            this.state = state;
        }

        public event Alarm alarmed;

        public override void On()
        {
            state = true;
            Power = 0.05;
            GenerateAlarm();
        }

        public override void Off()
        {
            state = false;
            Power = 0;
            isAlarm = false;
        }

        private void GenerateAlarm()
        {
            Random r = new Random();
            if (r.Next(1, 101) <= 25)
            {
                isAlarm = true;
            }
            else
            {
                isAlarm = false;
            }
            if (alarmed != null && isAlarm)
            {
                alarmed();
            }
        }

        public override string ToString()
        {
            if (isAlarm)
            {
                info = ", Сработал датчик движения!";
            }
            else
            {
                info = "";
            }
            return base.ToString() + info;
        }
    }
}