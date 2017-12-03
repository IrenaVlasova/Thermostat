using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermostatHometask
{
    class Program
    {
        const string ExitCommand = "exit";
        const string QuitCommand = "quit";

        static void Main(string[] args)
        {
            NestThermostat termostat = new NestThermostat(18,25);
            var shouldRepeat = false;
            var isTemperatureSet = false;
            int temperature;
            do
            {

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enter \"quit\" or \"exit\" to close application");

                if (!isTemperatureSet)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Enter value of temperature in your room:");
                }

                Console.ForegroundColor = ConsoleColor.White;
                string enteredValue = Console.ReadLine();


                if (int.TryParse(enteredValue, out temperature) && !isTemperatureSet)
                {
                    termostat.SetTemperature(temperature);
                    isTemperatureSet = true;
                    shouldRepeat = true;
                }
                else if (enteredValue.Equals(ExitCommand) || enteredValue.Equals(QuitCommand))
                {
                    Environment.Exit(0);
                }
                else
                {
                    shouldRepeat = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(isTemperatureSet ? "Error!": "Enter numeric value!");
                }
            }
            while (shouldRepeat);
        }
    }

    public class NestThermostat
    {
        private int min;
        private int max;
        private string onOff;

        public NestThermostat(int lower,int upper)
        {
            this.min = lower;
            this.max = upper;
        }

        public void SetTemperature(int comfTemp)
        {
            if(comfTemp >= min && comfTemp <= max)
            {
                onOff = "Thermostat switched off";
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if(comfTemp < min )
            {
                onOff = "Thermostat switched on";
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if(comfTemp > max)
            {
                onOff = "Thermostat switched off";
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.WriteLine(onOff);
        }
    }
}
