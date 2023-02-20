using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncWork
{
	internal class Program
	{
		static void Main(string[] args)
		{
			WaitCallback callback = new WaitCallback(Sum);
			//ThreadPool.QueueUserWorkItem(callback, 100);
			ThreadPool.SetMaxThreads(10, 10);

			for (int i = 0; i <= 20; i++)
			{
				
				ThreadPool.QueueUserWorkItem(callback, i * 10000);
			}
			Console.WriteLine("Hello, word");
			Console.ReadLine();
		}
		static void Sum(object count)
		{
			int result = 0;
			for (int i = 0; i < (int)count; i++)
			{
				result += i;
				//Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			}
			
			Console.WriteLine("Номер потока: + Thread.CurrentThread.ManagerThreadId");
			Console.WriteLine(result);
		}
	}
}


	

