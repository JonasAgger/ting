using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter sleep timer: ");
            int SleepTime = int.Parse(Console.ReadLine());

            for (int i = 0; i < SleepTime; i++)
            {
                System.Threading.Thread.Sleep(1000);
            }

            System.Diagnostics.Process.Start("CMD.exe", "shutdown -s -t 0");
        }
    }
}
