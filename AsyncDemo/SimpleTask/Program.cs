using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleTask
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(Go).Start();  // .NET 1.0开始就有的
            Task.Factory.StartNew(Go); // .NET 4.0 引入了 TPL
            Task.Run(new Action(Go)); // .NET 4.5 新增了一个Run的方法
            Console.WriteLine("我是Main线程 {0}", Thread.CurrentThread.ManagedThreadId.ToString());
            var dayName = Task.Run<string>(() => { return GetDayOfThisWeek(); });
            Console.WriteLine("今天是：{0}", dayName.Result);
            Console.ReadLine();
            
        }
        public static void Go()
        {
            Console.WriteLine("我是另一个线程 {0}", Thread.CurrentThread.ManagedThreadId.ToString());
        }

        public static string  GetDayOfThisWeek()
        {
            return string.Format("结果{0}", Thread.CurrentThread.ManagedThreadId.ToString());


            //Console.WriteLine("结果{0}", Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }
}
