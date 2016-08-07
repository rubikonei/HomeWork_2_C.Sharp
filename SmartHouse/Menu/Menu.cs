using System;
using System.Collections.Generic;

namespace SmartHouse
{
    public class Menu
    {
        public Dictionary<string, Device> devices = new Dictionary<string, Device>();
        public Factory factory = new Factory();

        public void Show()
        {
            devices.Add("cond", factory.GetConditioner());
            devices.Add("conv", factory.GetConvector());
            devices.Add("energy", factory.GetEnergyMeter());
            devices.Add("motion", factory.GetMotionSensor());
            devices.Add("sign", factory.GetSignaling());
            devices.Add("temp", factory.GetTemperatureSensor());

            foreach (KeyValuePair<string, Device> device in devices)
            {
                if (device.Value is IAlert)
                {
                    ((IAlarmed)devices["motion"]).alarmed += ((IAlert)device.Value).Alert;
                }
            }

            while (true)
            {
                Console.Clear();
                foreach (KeyValuePair<string, Device> device in devices)
                {
                    Console.WriteLine(device.Value);
                }
                Console.WriteLine();
                Console.Write("Введите команду: ");
                try
                {
                    string[] commands = Console.ReadLine().Split(' ');
                    if (commands[0].ToLower() == "exit")
                    {
                        return;
                    }
                    if (!devices.ContainsKey(commands[1]))
                    {
                        Help();
                        continue;
                    }
                    Options(commands[0].ToLower(), commands[1].ToLower());
                }
                catch (IndexOutOfRangeException)
                {
                    Help();
                    continue;
                }
            }
        }

        private void Options(string command, string name)
        {
            switch (command)
            {
                case "on":
                    devices[name].On();
                    break;
                case "off":
                    devices[name].Off();
                    break;
                default:
                    Console.WriteLine("Неизвестная комманда");
                    break;
            }
            if (devices[name] is ClimateDevice)
            {
                switch (command)
                {
                    case "decr":
                        ((ClimateDevice)devices[name]).Decrease();
                        break;
                    case "incr":
                        ((ClimateDevice)devices[name]).Increase();
                        break;
                    case "auto":
                        ((ClimateDevice)devices[name]).TemperatureEnvironment =
                            ((ITemperatureSensor)devices["temp"]).TemperatureEnvironment;
                        ((ClimateDevice)devices[name]).SetAutoTemperature();
                        break;
                    default:
                        Console.WriteLine("Неизвестная комманда");
                        break;
                }
            }
            if (devices[name] is IFan)
            {
                switch (command)
                {
                    case "fanon":
                        ((IFan)devices[name]).FanOn();
                        break;
                    case "fanoff":
                        ((IFan)devices[name]).FanOff();
                        break;
                    default:
                        Console.WriteLine("Неизвестная комманда");
                        break;
                }
            }
            if (devices[name] is IAlert)
            {
                switch (command)
                {
                    case "alert":
                        ((IAlert)devices[name]).Alert();
                        break;
                    default:
                        Console.WriteLine("Неизвестная комманда");
                        break;
                }
            }
            if (devices[name] is ICountEnergy)
            {
                switch (command)
                {
                    case "count":
                        ((ICountEnergy)devices[name]).CountEnergy(devices);
                        break;
                    default:
                        Console.WriteLine("Неизвестная комманда");
                        break;
                }
            }
        }

        private void Help()
        {
            Console.WriteLine("Доступные команды для всех устройств:");
            Console.WriteLine("\ton keyDevice");
            Console.WriteLine("\toff keyDevice");

            Console.WriteLine("Доступные команды для климатических устройств:");
            Console.WriteLine("\tdecr keyDevice");
            Console.WriteLine("\tincr keyDevice");
            Console.WriteLine("\tauto keyDevice");

            Console.WriteLine("Доступные команды для кондиционера:");
            Console.WriteLine("\tfanOn keyDevice");
            Console.WriteLine("\tfanOff keyDevice");

            Console.WriteLine("Доступные команды для сигнализации:");
            Console.WriteLine("\talert keyDevice");

            Console.WriteLine("Доступные команды для Счетчика электроэнергии:");
            Console.WriteLine("\tcount keyDevice");

            Console.WriteLine("Стандартные ключи устройств:");
            Console.WriteLine("\tcond - Кондиционер");
            Console.WriteLine("\tconv - Конвектор");
            Console.WriteLine("\tenergy - Счетчик электроэнергии");
            Console.WriteLine("\tmotion - Датчик движения");
            Console.WriteLine("\tsign - Сигнализация");
            Console.WriteLine("\ttemp - Датчик температуры");

            Console.WriteLine("exit - Выход");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
        }
    }
}