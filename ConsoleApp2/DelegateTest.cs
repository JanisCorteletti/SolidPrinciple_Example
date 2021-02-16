using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class DelegateTest
    {
        delegate void Calculation(int a, int b);

        static void TestingDelegate()
        {
            Calculation calculation = new Calculation(MethodNumber);

            calculation.Invoke(2, 4);

            Console.ReadLine();
        }

        static void MethodNumber(int a, int b)
        {
            Console.WriteLine(a + b);
        }


        static void MethodNumberTwo(int a, int b)
        {
            Console.WriteLine(a * b);
        }
    }
}
