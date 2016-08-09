namespace SmartHouse
{
    public class Signaling : Device, IAlert
    {
        private string info;

        public Signaling(string name, bool state)
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
            state = false;
            Power = 0;
            info = "";
        }

        public void Alert()
        {
            if (state == true)
            {
                info = " \aВнимание! В Доме воры!";
            }
        }

        public override string ToString()
        {
            return base.ToString() + info;
        }
    }
}