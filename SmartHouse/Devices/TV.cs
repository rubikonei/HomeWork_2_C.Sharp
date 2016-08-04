using System;

namespace SmartHouse
{
    public class TV : MultimediaDevice
    {
        public ChannelList channel;

        public TV(string name, bool state, ChannelList channel)
        {
            this.name = name;
            this.state = state;
            this.channel = channel;
            if (state == true)
            {
                Power = 0.2;
            }
        }

        public override void On()
        {
            state = true;
            Power = 0.2;
            channel = (ChannelList)1;
        }

        public override void Off()
        {
            state = false;
            Power = 0;
            channel = (ChannelList)1;
        }

        public override void Next()
        {
            if ((int)channel < Enum.GetValues(typeof(ChannelList)).Length && state == true)
            {
                channel++;
            }
            if ((int)channel == Enum.GetValues(typeof(ChannelList)).Length && state == true)
            {
                channel = (ChannelList)1;
            }
        }

        public override void Previous()
        {
            if ((int)channel > 1 && state == true)
            {
                channel--;
            }
            if ((int)channel == 1 && state == true)
            {
                channel = (ChannelList)Enum.GetValues(typeof(ChannelList)).Length;
            }
        }

        public override void Set(int ch)
        {
            if (state == true && ch >= 1 && ch <= 7)
            {
                channel = (ChannelList)ch;
            }
        }

        public override string ToString()
        {
            string channel;
            if (this.channel == ChannelList.AnimalPlanet)
            {
                channel = "Animal Planet";
            }
            else if (this.channel == ChannelList.Discovery)
            {
                channel = "Discovery";
            }
            else if (this.channel == ChannelList.Eurosport)
            {
                channel = "Eurosport";
            }
            else if (this.channel == ChannelList.Football)
            {
                channel = "Football";
            }
            else if (this.channel == ChannelList.Fox)
            {
                channel = "Fox";
            }
            else
            {
                channel = "National Geographic";
            }
            return base.ToString() + ", телеканал: " + channel;
        }
    }
}