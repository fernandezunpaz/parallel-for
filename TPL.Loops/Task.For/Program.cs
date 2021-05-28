using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTPL.For
{
    class Program
    {
        static int[] numbers = new int[] { 1, 10, 4, 3, 10, 20, 30, 5 };
        static int counter = 0;

        static void Main(string[] args)
        {
            List<Task<int>> tasks = new List<Task<int>>();

            for (int i = 0; i < numbers.Length; i++)
            {
                Task<int> task = Task.Factory.StartNew<int>((parameter) => {
                    int index = (int)parameter;
                    if (numbers[index] > 5)
                    {
                        return 1;
                    }
                    return 0;
                }, i);
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
            foreach (Task<int> task in tasks)
            {
                counter += task.Result;
            }

            Console.WriteLine("La cantidad de números mayores a 5 es: " + counter);
            Console.ReadKey();
        }
    }
}
