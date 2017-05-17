using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lockdemo
{
    class Program
    {
        private static bool _isDone = false;
        private static object _lock = new object();

        static void Main(string[] args)
        {
            Task.Run(()=> { Output(1); });
            Task.Run(() => { Output(2); });
            Console.ReadLine();
        }

        static void Output(int i)
        {
            lock (_lock)
            {
                if (!_isDone)
                {
                    Console.WriteLine("Out put {0}",i);
                    _isDone = true;
                }
            }
        }
    }
}
