namespace SmartHouse
{
    public abstract class MultimediaDevice : Device, IVolume, IProgram
    {
        private int volume;

        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (value >= 0 && value <= 100 && state == true)
                {
                    volume = value;
                }
            }
        }

        public abstract void Next();

        public abstract void Previous();

        public abstract void Set(int x);

        public void Increase()
        {
            Volume++;
        }

        public void Decrease()
        {
            Volume--;
        }

        public void SetVolume(int v)
        {
            Volume = v;
        }

        public override string ToString()
        {
            return base.ToString() + ", громкость: " + Volume;
        }
    }
}