using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.cnblogs.com/zhaoshujie/p/11082753.html
            //方式一、new Task 无返回值
            var task1 = new Task(() =>
            {
                Console.WriteLine("Task 1 Begin");
                for (int i = 2; i < 11; i++)
                {
                    Console.WriteLine("Task "+i);
                }
                
                Console.WriteLine("Task 1 Finish");
            });
            task1.Start();

            //new Task 有返回值的方式，Task 与 ContinueWith
            //先执行Task
            Task<int> task = new Task<int>(() => {
                return 0;
            });
            //其次执行ContinueWith
            /*task.ContinueWith(t =>
            {
                int result = t.Result;
            });*/
            task.Start();
            Console.WriteLine(task.Result.ToString());

            //Task任务并行
            List<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() =>
            {
                Console.WriteLine("Task任务并行 1");
            }));
            taskList.Add(Task.Run(() =>
            {
                Console.WriteLine("Task任务并行 2");
            }));
            taskList.Add(Task.Run(() =>
            {
                Console.WriteLine("Task任务并行 3");
            }));
            //方式四、直接异步的方法
            Task.Factory.StartNew(() => TaskMethod("Task 3"));

            Console.WriteLine("Hello World!");
        }
        static void TaskMethod(string name)
        {
            Console.WriteLine("Task {0} is running on a thread id {1}. Is thread pool thread: {2}",
                              name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
        }
    }
}
