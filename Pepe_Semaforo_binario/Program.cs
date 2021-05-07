using System;
using System.Threading;

namespace Pepe_Semaforo_binario
{
    class Program
    {
        static int n;
        static SemaphoreSlim s = new SemaphoreSlim(1);
        static void Main(string[] args)
        {
            while (true)
            {
                n = 0;
                Thread t1 = new Thread(() => Incrementa());
                Thread t2 = new Thread(() => Decrementa());
                t1.Start();
                t2.Start();
                while (t1.IsAlive) { }
                while (t2.IsAlive) { }
                Console.WriteLine(n);
                Console.ReadLine();
            }
        }
        private static void Incrementa()
        {
            for (int i = 0; i <= 1000000; i++)
            {
                s.Wait();
                n++;
                s.Release();
            }
        }
        private static void Decrementa()
        {
            for (int i = 0; i <= 1000000; i++)
            {
                s.Wait();
                n--;
                s.Release();
            }
        }
    }
}
