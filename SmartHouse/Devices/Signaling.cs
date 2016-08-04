namespace SmartHouse
{
    public class Signaling : Device, IAlert
    {
        public string info;

        public Signaling(string name, bool state)
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

        public void Alert()
        {
            if (state == true)
            {
                info = " \aThere are thiefs in the house";
            }
        }

        public override string ToString()
        {
            return base.ToString() + info;
        }
    }
}