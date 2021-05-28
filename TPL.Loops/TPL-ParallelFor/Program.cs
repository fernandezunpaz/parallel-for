using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_ParallelFor
{
    class Program
    {
        static int[] numbers = new int[] { 1, 10, 4, 3, 10, 20, 30, 5 };
        static int counter = 0;

        static void Main(string[] args)
        {

            //for (int i = 0; i < numbers.Length; i++)
            Parallel.For(

                0, //Inicio del bucle

                numbers.Length, //Fin del bucle

                () => 0, //Inicializador de TLS

                (index, loopState, subtotal) => //Map
                {
                    if (numbers[index] > 5)
                    {
                        subtotal = subtotal + 1;
                    }

                    return subtotal;
                },

                (taskResult) => //Reduce
                {
                    //counter = counter + subtotal
                    Interlocked.Add(ref counter, taskResult);
                }

            );

            Console.WriteLine("La cantidad de números mayores a 5 es: " + counter);
            Console.ReadKey();
        }
    }
}
