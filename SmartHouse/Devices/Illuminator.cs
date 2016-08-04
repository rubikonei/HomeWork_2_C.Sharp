using System;

namespace SmartHouse
{
    public class Illuminator : Device, IAlert, IProgram
    {
        public BrightnessLevel level;

        public Illuminator(string name, bool state)
        {
            this.name = name;
            this.state = state;
            if (state == true)
            {
                Power = 0.1;
            }
        }

        public override void On()
        {
            state = true;
            Power = 0.1;
        }

        public override void Off()
        {
            state = false;
            Power = 0;
        }


        public void Next()
        {
            if ((int)level < Enum.GetValues(typeof(BrightnessLevel)).Length && state == true)
            {
                level++;
            }
            if ((int)level == Enum.GetValues(typeof(BrightnessLevel)).Length && state == true)
            {
                level = (BrightnessLevel)1;
            }
        }

        public void Previous()
        {
            if ((int)level > 1 && state == true)
            {
                level--;
            }
            if ((int)level == 1 && state == true)
            {
                level = (BrightnessLevel)Enum.GetValues(typeof(BrightnessLevel)).Length;
            }
        }

        public void Set(int l)
        {
            if(state == true && l >= 1 && l <= 3)
            {
                level = (BrightnessLevel)l;
            }
        }

        public void Alert()
        {
            On();
            level = BrightnessLevel.High;
        }

        public override string ToString()
        {
            string mode;
            if (level == BrightnessLevel.Low)
            {
                mode = "слабая";
            }
            else if (level == BrightnessLevel.Medium)
            {
                mode = "средняя";
            }
            else
            {
                mode = "высокая";
            }
            return base.ToString() + ", яркость: " + mode;
        }
    }
}