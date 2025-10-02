using System;

class MainClass
{
    // Метод для ввода чисел с проверкой диапазона
    static int ReadInt(string prompt, int min, int max)
    {
        int value;
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out value))
            {
                if (value >= min && value <= max)
                    return value;
                else
                    Console.WriteLine($"Ошибка! Введите число от {min} до {max}.");
            }
            else
            {
                Console.WriteLine("Ошибка! Введите целое число.");
            }
        }
    }

    // Метод для ввода кличек питомцев
    static string[] WritePetNames(int petCount)
    {
        string[] petNames = new string[petCount];
        for (int i = 0; i < petCount; i++)
        {
            Console.WriteLine($"Введите кличку питомца {i + 1}:");
            petNames[i] = Console.ReadLine();
        }
        return petNames;
    }

    // Метод для ввода любимых цветов
    static string[] FavColors(int countColors)
    {
        string[] favColors = new string[countColors];
        for (int i = 0; i < countColors; i++)
        {
            Console.WriteLine($"Введите любимый цвет {i + 1}:");
            favColors[i] = Console.ReadLine();
        }
        return favColors;
    }

    // Метод для создания анкеты
    public static (string name, string surname, int age, bool hasPet, int petCount, string[] petNames, int countColors, string[] favColors) MakeAnketa()
    {
        (string name, string surname, int age, bool hasPet, int petCount, string[] petNames, int countColors, string[] favColors) anketa;

        Console.WriteLine("Введите ваше имя:");
        anketa.name = Console.ReadLine();

        Console.WriteLine("Введите вашу фамилию:");
        anketa.surname = Console.ReadLine();

        anketa.age = ReadInt("Введите ваш возраст:", 1, 130);

        Console.WriteLine("Есть ли у вас животные? (да/нет):");
        string hasPetInput = Console.ReadLine().Trim().ToLower();
        anketa.hasPet = (hasPetInput == "да" || hasPetInput == "true");

        if (anketa.hasPet)
        {
            anketa.petCount = ReadInt("Сколько у вас питомцев?", 1, 100);
            anketa.petNames = WritePetNames(anketa.petCount);
        }
        else
        {
            anketa.petCount = 0;
            anketa.petNames = new string[0];
        }

        anketa.countColors = ReadInt("Сколько у Вас любимых цветов?", 1, 100);
        anketa.favColors = FavColors(anketa.countColors);

        return anketa;
    }

    // Метод для вывода анкеты на экран
    public static void ShowAnketa((string name, string surname, int age, bool hasPet, int petCount, string[] petNames, int countColors, string[] favColors) anketa)
    {
        Console.WriteLine("Анкета");
        Console.WriteLine($"Имя: {anketa.name}");
        Console.WriteLine($"Фамилия: {anketa.surname}");
        Console.WriteLine($"Возраст: {anketa.age}");
        Console.WriteLine($"Есть питомцы: {anketa.hasPet}");
        if (anketa.hasPet && anketa.petCount > 0)
        {
            Console.WriteLine($"Количество питомцев: {anketa.petCount}");
            Console.WriteLine("Имена питомцев: " + string.Join(", ", anketa.petNames));
        }
        Console.WriteLine($"Количество любимых цветов: {anketa.countColors}");
        if (anketa.countColors > 0)
        {
            Console.WriteLine("Любимые цвета: " + string.Join(", ", anketa.favColors));
        }
    }

    public static void Main(string[] args)
    {
        // Создаём анкету
        var anketa = MakeAnketa();

        // Показываем анкету на экране
        ShowAnketa(anketa);
    }
}
