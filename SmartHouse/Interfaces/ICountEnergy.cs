using System.Collections.Generic;

namespace SmartHouse
{
    public interface ICountEnergy
    {
        void CountEnergy(Dictionary<string, Device> devices);
    }
}