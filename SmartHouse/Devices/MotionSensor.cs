using System;

namespace SmartHouse
{
    public class MotionSensor : Device
    {
        public event Alarm alarmed;
        private bool isAlarm;

        public MotionSensor(string name, bool state)
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
            GenerateAlarm();
        }

        public override void Off()
        {
            state = false;
            Power = 0;
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
            string mode = ", Чисто";
            if (isAlarm)
            {
                mode = ", Сработал датчик движения!";
            }
            return base.ToString() + mode;
        }
    }
}