using System;
using Luminous.Core;

namespace DevTestBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dev Console\n");

            Engine.Instance.Intialize();

            Engine.Instance.Run();
        }
    }
}
