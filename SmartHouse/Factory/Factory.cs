using System.Collections.Generic;

namespace SmartHouse
{
    public class Factory
    {
        public Conditioner GetConditioner()
        {
            return new Conditioner("Кондиционер", false, false);
        }

        public Convector GetConvector()
        {
            return new Convector("Конвектор", false);
        }

        public EnergyMeter GetEnergyMeter()
        {
            return new EnergyMeter("Счетчик электроэнергии", false);
        }

        public HomeCinema GetHomeCinema()
        {
            return new HomeCinema("Дом. кинотеатр", false, FilmList.TheShawshankRedemption);
        }

        public Illuminator GetIlluminator()
        {
            return new Illuminator("Лампа", false);
        }

        public Signaling GetSignaling()
        {
            return new Signaling("Сигнализация", false);
        }

        public TV GetTV()
        {
            return new TV("Телевизор", false, ChannelList.Eurosport);
        }

        public ClimateControl GetClimateControl(List<IAutoTemperature> temperatureDevices,
            TemperatureSensor sensor)
        {
            return new ClimateControl(temperatureDevices, sensor, "Климат контроль", false);
        }
        
        public MotionSensor GetMotionSensor()
        {
            return new MotionSensor("Датчик движения", false);
        }

        public TemperatureSensor GetTemperatureSensor()
        {
            return new TemperatureSensor("Датчик температуры", false);
        }
    }
}