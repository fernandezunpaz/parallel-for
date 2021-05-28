using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_Lock
{
    class Program
    {
        static int[] numbers = new int[] { 1, 10, 4, 3, 10, 20, 30, 5 };
        static int counter = 0;

        static void Main(string[] args)
        {
            object obj = new object();
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < numbers.Length; i++)
            {
                Task task = Task.Factory.StartNew((parameter) => {
                    int index = (int)parameter;
                    if (numbers[index] > 5)
                    {
                        lock(obj)
                        {
                            counter = counter + 1;
                        }
                    }
                }, i);
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("La cantidad de números mayores a 5 es: " + counter);
            Console.ReadKey();
        }
    }
}
