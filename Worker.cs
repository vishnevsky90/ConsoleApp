
namespace Interface
{
    public class Worker : IWorker
    {
        ILogger Logger { get; }
        ICalculate Calculator { get; }

        public Worker(ILogger logger, ICalculate calculator)
        {
            Logger = logger;
            Calculator = calculator;
        }

        public void Work()
        {
            try
            {
                Logger.Event("Worker начал работу калькулятора");

                Console.Write("Введите первое число: ");
                int a = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите второе число: ");
                int b = Convert.ToInt32(Console.ReadLine());

                int result = Calculator.Add(a, b);
                Logger.Event($"Результат сложения: {result}");
            }
            catch (FormatException)
            {
                Logger.Error("Ошибка: введено некорректное число!");
            }
            catch (Exception ex)
            {
                Logger.Error($"Неизвестная ошибка: {ex.Message}");
            }
            finally
            {
                Logger.Event("Worker завершил работу калькулятора");
            }
        }
    }
}
