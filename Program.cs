using System;

namespace Interface
{
    public interface ICalculate
    {
        int Add(int num1, int num2);
    }

    public class Calculate : ICalculate
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }
    }

    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }

    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;     
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;    
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    public interface IWorker
    {
        void Work();
    }

    class Program

    {
        static void Main()
        {
            ILogger logger = new Logger();
            ICalculate calculator = new Calculate();
            IWorker worker = new Worker(logger, calculator);

            worker.Work();
        }

    }
}