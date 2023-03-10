using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Calculator;

namespace MyNameSpace
{
    public class Calculate : ICalculate, ILogger
    {
        public void Error(string mess)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{mess}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        double ICalculate.Calculate(double x, double y) //явная реализация
        {
            Console.WriteLine($"В резултате сложения чисел {x} и {y} = {x + y}");
            return x + y;
        }
    }

    internal class HW1
    {
        static void Main(string[] args)
        {
            Calculate calculate = new Calculate();
            double a = default;
            double b = default;

            do
            {
                Console.Clear();
                calculate.Info("КАЛЬКУЛЯТОР");

            link1:
                try
                {
                    Console.WriteLine("Введите число Х: ");
                    a = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    calculate.Error(ex.Message);
                    goto link1;
                }

            link2:
                try
                {
                    Console.WriteLine("Введите число Y: ");
                    b = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto link2;
                }

            ((ICalculate)calculate).Calculate(a, b);
                Console.WriteLine("Нажмите любую клавишу для продолжения или клавишу Esc для выхода");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}