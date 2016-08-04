using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class Menu
    {
        public static Dictionary<string, Device> devices = new Dictionary<string, Device>();
        public static List<IAutoTemperature> tempDevices = new List<IAutoTemperature>();
        public static Factory factory = new Factory();

        public void Show()
        {
            devices.Add("Conditioner", factory.GetConditioner());
            devices.Add("Convector", factory.GetConvector());
            devices.Add("EnergyMeter", factory.GetEnergyMeter());
            devices.Add("HomeCinema", factory.GetHomeCinema());
            devices.Add("Illuminator", factory.GetIlluminator());
            devices.Add("MotionSensor", factory.GetMotionSensor());
            devices.Add("Signaling", factory.GetSignaling());
            devices.Add("TempSensor", factory.GetTemperatureSensor());
            devices.Add("TV", factory.GetTV());

            foreach (KeyValuePair<string, Device> device in devices)
            {
                if (device.Value is IAutoTemperature)
                {
                    tempDevices.Add((IAutoTemperature)device.Value);
                }
            }

            devices.Add("ClimateControl",
                factory.GetClimateControl(tempDevices, (TemperatureSensor)devices["TempSensor"]));

            foreach (KeyValuePair<string, Device> device in devices)
            {
                if (device.Value is IAlert)
                {
                    ((MotionSensor)devices["MotionSensor"]).alarmed += ((IAlert)device.Value).Alert;
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
                string[] commands = Console.ReadLine().Split(' ');
                if (commands[0].ToLower() == "exit")
                {
                    return;
                }
                if (commands.Length > 3 || commands.Length < 2)
                {
                    Help();
                    continue;
                }
                if (commands.Length == 2 && !devices.ContainsKey(commands[1]))
                {
                    Help();
                    continue;
                }
                if (commands.Length == 3 && !devices.ContainsKey(commands[2]))
                {
                    Help();
                    continue;
                }
                if (commands.Length == 2)
                {
                    Options(commands[0], commands[1]);
                }
                else
                {
                    Options(commands[0], commands[1], commands[2]);
                }
            }
        }

        private static void Options(string command, string name)
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
            if (devices[name] is MultimediaDevice)
            {
                switch (command)
                {
                    case "decrVol":
                        ((MultimediaDevice)devices[name]).Decrease();
                        break;
                    case "incrVol":
                        ((MultimediaDevice)devices[name]).Increase();
                        break;
                    case "next":
                        ((MultimediaDevice)devices[name]).Next();
                        break;
                    case "prev":
                        ((MultimediaDevice)devices[name]).Previous();
                        break;
                    default:
                        Console.WriteLine("Неизвестная комманда");
                        break;
                }
            }
            if (devices[name] is IProgram)
            {
                switch (command)
                {
                    case "next":
                        ((IProgram)devices[name]).Next();
                        break;
                    case "prev":
                        ((IProgram)devices[name]).Previous();
                        break;
                    default:
                        Console.WriteLine("Неизвестная комманда");
                        break;
                }
            }
            if (devices[name] is ClimateDevice)
            {
                switch (command)
                {
                    case "decrTemp":
                        ((ClimateDevice)devices[name]).Decrease();
                        break;
                    case "incrTemp":
                        ((ClimateDevice)devices[name]).Decrease();
                        break;
                    case "setAutoTemp":
                        ((ClimateDevice)devices[name]).SetAutoTemperature(((TemperatureSensor)devices["TempSensor"]).temperatureEnvironment);
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
                    case "fanOn":
                        ((IFan)devices[name]).FanOn();
                        break;
                    case "fanOff":
                        ((IFan)devices[name]).FanOff();
                        break;
                    default:
                        Console.WriteLine("Неизвестная комманда");
                        break;
                }
            }
            if (devices[name] is IConditionerMode)
            {
                switch (command)
                {
                    case "freshAir":
                        ((IConditionerMode)devices[name]).FreshAir();
                        break;
                    case "nightMode":
                        ((IConditionerMode)devices[name]).SetNightMode();
                        break;
                    default:
                        Console.WriteLine("Неизвестная комманда");
                        break;
                }
            }
            if (devices[name] is IAutoMode)
            {
                switch (command)
                {
                    case "setAutoMode":
                        ((IAutoMode)devices[name]).SetAutoMode();
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
                    case "countEnergy":
                        ((ICountEnergy)devices[name]).CountEnergy(devices);
                        break;
                    default:
                        Console.WriteLine("Неизвестная комманда");
                        break;
                }
            }
        }

        private static void Options(string command, string number, string name)
        {
            if (devices[name] is MultimediaDevice)
            {
                switch (command)
                {
                    case "set":
                        ((MultimediaDevice)devices[name]).Set(Convert.ToInt32(number));
                        break;
                    case "setVol":
                        ((MultimediaDevice)devices[name]).SetVolume(Convert.ToInt32(number));
                        break;
                    default:
                        Console.WriteLine("Неизвестная комманда");
                        break;
                }
            }
            if (devices[name] is IProgram)
            {
                switch (command)
                {
                    case "set":
                        ((IProgram)devices[name]).Set(Convert.ToInt32(number));
                        break;
                    default:
                        Console.WriteLine("Неизвестная комманда");
                        break;
                }
            }
        }

        private static void Help()
        {
            Console.WriteLine("Доступные команды для всех устройств:");
            //Console.WriteLine("\tadd keyDevice");
            //Console.WriteLine("\tdel keyDevice");
            Console.WriteLine("\ton keyDevice");
            Console.WriteLine("\toff keyDevice");

            Console.WriteLine("Доступные команды для мультимедийных устройств:");
            Console.WriteLine("\tdecrVol keyDevice");
            Console.WriteLine("\tincrVol keyDevice");
            Console.WriteLine("\tnext keyDevice");
            Console.WriteLine("\tprev keyDevice");
            Console.WriteLine("\tset number keyDevice, number=1...6");
            Console.WriteLine("\tsetVol number keyDevice, number=1...100");

            Console.WriteLine("Доступные команды для климатических устройств:");
            Console.WriteLine("\tdecrTemp keyDevice");
            Console.WriteLine("\tincrTemp keyDevice");
            Console.WriteLine("\tsetAutoTemp keyDevice");

            Console.WriteLine("Доступные команды для кондиционера:");
            Console.WriteLine("\tfanOn keyDevice");
            Console.WriteLine("\tfanOff keyDevice");
            Console.WriteLine("\tfreshAir keyDevice");
            Console.WriteLine("\tnightMode keyDevice");

            Console.WriteLine("Доступные команды для климат контроля:");
            Console.WriteLine("\tsetAutoMode keyDevice");

            Console.WriteLine("Доступные команды для освещения:");
            Console.WriteLine("\tset number keyDevice, number=1...3");

            Console.WriteLine("Доступные команды для сигнализации:");
            Console.WriteLine("\talert keyDevice");

            Console.WriteLine("Доступные команды для Счетчика электроэнергии:");
            Console.WriteLine("\tcountEnergy keyDevice");

            Console.WriteLine("Стандартные ключи устройств:");
            Console.WriteLine("\tConditioner");
            Console.WriteLine("\tConvector");
            Console.WriteLine("\tEnergyMeter");
            Console.WriteLine("\tHomeCinema");
            Console.WriteLine("\tIlluminator");
            Console.WriteLine("\tMotionSensor");
            Console.WriteLine("\tSignaling");
            Console.WriteLine("\tTempSensor");
            Console.WriteLine("\tTV");
            Console.WriteLine("\tClimateControl");

            Console.WriteLine("exit - Выход");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
        }
    }
}