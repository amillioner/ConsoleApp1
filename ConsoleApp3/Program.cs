using ConsoleApp3.Solutions.Task2;
using System;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    var t = new FirstTask();
        //    var r = t.ReverseString("Anwar");
        //    Console.WriteLine("Hello, World!");


        //    var s = new SecondTask();
        //    var res = s.ProcessData();
        //    Console.WriteLine("Karam");
        //}

        static async Task Main(string[] args)
        {
            var s = new Solution2();
            var res = await s.ProcessData();

            //Console.WriteLine(res);

            Console.WriteLine("Press any key to exist.");
            Console.ReadKey();
        }
    }
}