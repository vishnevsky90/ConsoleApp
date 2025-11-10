using System;

namespace Delegates
{
    public delegate void Sort(int number); //делегат

    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }

    public class LastName //издатель
    {
        private List<string> _lastNames = new List<string>
        {
            "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов"
        };

        public event Sort TakeNumber; //событие
        
        public void SortAscending()
        {
            _lastNames.Sort();
        }

        public void SortDescending()
        {
            _lastNames.Sort(); 
            _lastNames.Reverse();
        }

        public void OnSort(int number)
        {
            if (number == 1)
            {
                SortAscending();
            }
            else if (number == 2)
            {
                SortDescending();
            }
            else
            {
                throw new InvalidInputException("Можно вводить только цифры 1 или 2");
            }
        }

        public void RaiseSortEvent(int number)
        {
            TakeNumber?.Invoke(number);
        }
    }

    public class Program
    {
        static void Main()
        {
            LastName ln = new LastName();
            ln.TakeNumber += ln.OnSort; //регистрируем событие

            try
            {
                Console.WriteLine("Введите 1, если хотите провести сортировку А-Я. Введите 2, если хотите провести сортировку Я-А");
                int answer = Convert.ToInt32(Console.ReadLine());
                ln.RaiseSortEvent(answer); //вызываем событие
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Сортировка завершена");
            }

        }

    }
}