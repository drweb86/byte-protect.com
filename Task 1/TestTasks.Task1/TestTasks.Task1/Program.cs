using System;
using System.Diagnostics;

namespace TestTasks.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //DebugTests();

            int number = InputNumber();

            int a, b, c;
            if (ValidateNumber(number, out a, out b, out c))
            {
                Console.WriteLine($"Да, {a} * {b} * {c} = {number}");
            }
            else
            {
                Console.WriteLine("Нет");
            }
            Console.ReadLine();
        }

        private static void DebugTests()
        {
            int a;
            int b;
            int c;
            Debug.Assert(!ValidateNumber(-2, out a, out b, out c));
            Debug.Assert(!ValidateNumber(0, out a, out b, out c));
            Debug.Assert(!ValidateNumber(1, out a, out b, out c));
            Debug.Assert(!ValidateNumber(2, out a, out b, out c));
            Debug.Assert(!ValidateNumber(3, out a, out b, out c));
            Debug.Assert(!ValidateNumber(4, out a, out b, out c));
            Debug.Assert(ValidateNumber(6, out a, out b, out c) && a == 1 && b == 2 && c == 3);
            Debug.Assert(!ValidateNumber(7, out a, out b, out c));
            Debug.Assert(ValidateNumber(3*5*7, out a, out b, out c)&& a == 3 && b == 5 && c == 7);
            Debug.Assert(!ValidateNumber(2* 3 * 5 * 7, out a, out b, out c));
            Debug.Assert(!ValidateNumber(3 * 5 * 11, out a, out b, out c));
        }

        private static bool ValidateNumber(int number, 
            out int a,
            out int b,
            out int c)
        {
            a = 1;
            b = 2;
            c = 3;

            if (number < a*b*c)
                return false;

            if (number == a * b * c)
                return true;

            for (int i = c; i < number - 1; i++)
            {
                if (IsPrime(i))
                {
                    a = b;
                    b = c;
                    c = i;

                    if (number == a * b * c)
                        return true;
                }
            }

            return false;
        }

        public static bool IsPrime(int number)
        {
            int boundary = (int)Math.Floor(Math.Sqrt(number));

            if (number == 1)
                return false;
            if (number == 2)
                return true;

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        private static int InputNumber()
        {
            while (true)
            {
                Console.Write("Введите число: ");
                var numberText = Console.ReadLine();

                int number;
                if (!int.TryParse(numberText, out number))
                {
                    Console.Error.WriteLine("Введенные данные не являются числом.");
                    continue;
                }

                if (number < 2)
                {
                    Console.Error.WriteLine("Введенное число должно быть больше 1.");
                    continue;
                }

                return number;
            }
        }
    }
}
