﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphoreDemo
{
    class Program
    {
        static SemaphoreSlim _sem = new SemaphoreSlim(3);// 我们限制能同时访问的线程数量是3
        static void Main(string[] args)
        {

            for (int i = 1; i <= 5; i++) new Thread(Enter).Start(i);

            Console.ReadLine();

        }

        static void Enter(object id)
        {

            Console.WriteLine(id + " 开始排队...");

            _sem.Wait();

            Console.WriteLine(id + " 开始执行！");

            Thread.Sleep(1000 * (int)id);

            Console.WriteLine(id + " 执行完毕，离开！");

            _sem.Release();

        }
    }
}
