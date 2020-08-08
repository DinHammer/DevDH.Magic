using System;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static System.Reflection.Assembly GetAssembly()
            => System.Reflection.Assembly.GetExecutingAssembly();
    }
}
