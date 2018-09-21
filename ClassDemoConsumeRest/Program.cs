using System;

namespace ClassDemoConsumeRest
{
    class Program
    {
        static void Main(string[] args)
        {
            RestConsumer consumer = new RestConsumer();
            consumer.Start();

            Console.ReadLine();
        }
    }
}
