using System.Diagnostics;

internal class Program
{
    static bool ExitProgram()
    {
        Console.WriteLine("Вы выбрали пункт 5 ");
        bool running3 = true;
        bool running = true;
        do
        {
            Console.WriteLine("Вы действительно хотите выйти? ");
            string a1 = Console.ReadLine();

            if (a1 == "д")
            {
                Console.WriteLine("Вы вышли");
                running = false;
                running3 = false;
            }
            else if (a1 == "н")
            {
                Console.WriteLine("Вы решили остаться");
                running = true;
                running3 = false;
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
                running3 = true;
            }

        }
        while (running3);
        return running;
    }

    static void MathGame()
    {
        double al = InputDouble("Введите значение a:", "Неправильный ввод a!");
        double bet = InputDouble("Введите значение b:", "Неправильный ввод b!");

        if (bet > 0)
        {
            double res5 = ResFunk(al, bet);
            Attempts(res5);
        }
        else
        {
            Console.WriteLine("Такое значение b не правильно");
        }
    }

    static void Attempts(double res5)
    {
        int attempts = 0;
        bool running1 = true;
        while (running1)
        {
            Console.WriteLine($"Правильный результат {res5}");
            Console.WriteLine("Введите вашу догадку: ");
            double res6 = 0;
            string strZ = Console.ReadLine();
            bool exp = double.TryParse(strZ, out res6);
            if (res5 == res6)
            {
                Console.WriteLine("Вы угадали, поздравляю !!!");
                running1 = false;
            }
            else
            {
                attempts++;
                Console.WriteLine($"Вы не угадали. У вас осталось {3 - attempts} попыток.");

                if (attempts == 3)
                {
                    Console.WriteLine($"Вы проиграли :( Правильным числом было {res5}");
                    exp = false;
                    running1 = false;
                }
            }
        }
    }

    static double InputDouble(string inputText, string errorText)
    {
        Console.WriteLine("Вы выбрали пункт 1");
        double al = 0;
        bool input1 = false;
        while (!input1)
        {
            Console.Write($"{inputText} ");
            string strA = Console.ReadLine();
            input1 = double.TryParse(strA, out al) && al != 0; // Проверка на 0
            if (!input1)
            {
                Console.WriteLine($"{errorText}");
            }
        }
        return al;
    }


    static double ResFunk(double al, double bet)
    {
        // Конвертация в радианы
        double radians = al * (Math.PI / 180); // преобразование градусов в радианы
        double result1 = Math.Sqrt(bet + Math.Sin(radians)); // sin(al) должен быть в радианах
        double result2 = Math.Pow(Math.Cos(radians), 3); // cos(al) должен быть в радианах
        double result3 = Math.Log(result1 / result2, bet);
        return Math.Round(result3, 2); // Округление до 2 знаков после запятой
    }


    static void Info()
    {
        Console.WriteLine("Вы выбрали пункт 2 ");
        Console.WriteLine("Пересыпкин Евгений Дмитриевич, группа 6101");
    }

    static double Menu()
    {
        Console.WriteLine("Меню");
        Console.WriteLine("1.Отгадайте число");
        Console.WriteLine("2.Об авторе");
        Console.WriteLine("3.Сортировка Массива");
        Console.WriteLine("4.Игра поиск сокровищ");
        Console.WriteLine("5.Выход");
        Console.WriteLine("Введите ваш вариант меню");
        double x1 = DoubleParse();
        return x1;
    }

    static int IntParse()
    {
        int x = 0;
        bool inputCorrect = false;
        while (!inputCorrect)
        {
            string strA = Console.ReadLine();
            inputCorrect = int.TryParse(strA, out x);
            if (!inputCorrect)
            {
                Console.WriteLine("Ошибка ввода");
            }
        }
        return x;
    }

    static double DoubleParse()
    {
        double x = 0;
        bool inputCorrect = false;
        while (!inputCorrect)
        {
            string strA = Console.ReadLine();
            inputCorrect = double.TryParse(strA, out x);
            if (!inputCorrect)
            {
                Console.WriteLine("Ошибка ввода");
            }
        }
        return x;
    }

    static int MassivSize()
    {
        int x;
        bool i = true;
        while (i)
        {
            Console.WriteLine("Введите длину массива");
            x = IntParse();
            if (x > 0)
            {
                return x;
            }
            else
            {
                Console.WriteLine("Размер массива должен быть больше нуля");
            }
        }
        return 0;
    }

    static int[] MassivInicialization(int a)
    {
        int[] array = new int[a];
        Random rnd = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rnd.Next(10);
        }
        return array;
    }

    static void PrintArray(int[] array)
    {
        if (array.Length <= 10)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10");
        }
    }

    static int[] CopyArray(int[] arr)
    {
        int[] copy = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            copy[i] = arr[i];
        }
        return copy;
    }

    static int[] SelectionSort(int[] array1)
    {
        for (int i = 0; i < array1.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array1.Length; j++)
            {
                if (array1[j] < array1[minIndex])
                {
                    minIndex = j;
                }
            }
            // Меняем местами
            int temp = array1[minIndex];
            array1[minIndex] = array1[i];
            array1[i] = temp;
        }
        return array1; // Возвращаем отсортированный массив
    }

    static int[] ShellSort(int[] array2)
    {
        int j;
        int step = array2.Length / 2;
        while (step > 0)
        {
            for (int i = 0; i < (array2.Length - step); i++)
            {
                j = i;
                while ((j >= 0) && (array2[j] > array2[j + step]))
                {
                    int tmp = array2[j];
                    array2[j] = array2[j + step];
                    array2[j + step] = tmp;
                    j -= step;
                }
            }
            step = step / 2;
        }
        return array2; // Возвращаем отсортированный массив
    }

    private static double SelectionTime(int[] array1)
    {
        Stopwatch a = new Stopwatch();
        a.Start();
        SelectionSort(array1);
        a.Stop();
        return a.Elapsed.TotalMilliseconds;
    }

    static double ShellTime(int[] array2)
    {
        Stopwatch a = new Stopwatch();
        a.Start();
        ShellSort(array2);
        a.Stop();
        return a.Elapsed.TotalMilliseconds;
    }

    static void Sorter(double TimeSelection, double TimeShell, int q, int[] RandArray, int[] NewMassiv)
    {
        if (q <= 10)
        {
            Console.Write("Массив после сортировки выбором: ");
            PrintArray(RandArray);
            Console.WriteLine("Время выполнения сортировки выбором: " + TimeSelection);
            Console.Write("Массив после сортировки Шелла: ");
            PrintArray(NewMassiv);
            Console.WriteLine("Время выполнения сортировки методом Шелла: " + TimeShell);
            if (TimeSelection > TimeShell)
            {
                Console.WriteLine("Сортировка Шелла оказалась быстрее");
            }
            else if (TimeSelection < TimeShell)
            {
                Console.WriteLine("Сортировка выбором оказалась быстрее");
            }
            else
            {
                Console.WriteLine("Время выполнения сортировок одинаковое");
            }
        }
        else
        {
            Console.WriteLine("Вывести массив не получится, размер массива больше 10");
            PrintArray(RandArray);
            Console.WriteLine("Время выполнения сортировки выбором: " + TimeSelection);
            PrintArray(NewMassiv);
            Console.WriteLine("Время выполнения сортировки методом Шелла: " + TimeShell);
        }
    }

    static void PlayTreasureHunt()
        {
            char[,] board = new char[10, 10]; // Игровое поле
            int treasuresToFind = 10; // Количество сокровищ
            int trapsToPlace = 5; // Количество ловушек
            int treasuresFound = 0; // Найденные сокровища

            InitializeGame(board, treasuresToFind, trapsToPlace); // Инициализация игры
            PlayGame(board, treasuresToFind, ref treasuresFound); // Начало игры
        }

        static void InitializeGame(char[,] board, int treasuresToFind, int trapsToPlace)
        {
            // Инициализация игрового поля
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = '.'; // Заполняем поле пустыми клетками
                }
            }

            // Размещение сокровищ
            PlaceItems(board, 'С', treasuresToFind);
            // Размещение ловушек
            PlaceItems(board, 'Л', trapsToPlace);
        }

        static void PlaceItems(char[,] board, char item, int count)
        {
            Random rand = new Random();
            int placedCount = 0;

            while (placedCount < count)
            {
                int x = rand.Next(10);
                int y = rand.Next(10);
                if (board[x, y] == '.')
                {
                    board[x, y] = item; // Размещаем сокровище или ловушку
                    placedCount++;
                }
            }
        }

        static void PlayGame(char[,] board, int treasuresToFind, ref int treasuresFound)
        {
            bool gameInProgress = true; // Флаг для продолжения игры

            while (gameInProgress)
            {
                Console.Clear();
                PrintBoard(board);
                Console.WriteLine($"Найдено сокровищ: {treasuresFound}/{treasuresToFind}");

                string input = GetUserInput(); // Получаем ввод пользователя

                if (input.ToLower() == "exit") // Проверяем команду выхода
                {
                    gameInProgress = false; // Завершение игры
                }
                else
                {
                    bool validInput = false; // Флаг для проверки корректности ввода
                    int row = -1, col = -1;

                    // Проверка ввода
                    if (input.Length == 2)
                    {
                        col = input[0] - 'A'; // Преобразует букву в индекс столбца (A=0)

                        // Проверяем, является ли второй символ цифрой и преобразуем его в индекс строки
                        if (char.IsDigit(input[1]) && int.TryParse(input[1].ToString(), out int rowInput))
                        {
                            row = rowInput; // Преобразует 0-9 в 0-9
                                            // Проверяем, что столбец и строка находятся в допустимых пределах
                            if (col >= 0 && col < 10 && row >= 0 && row < 10)
                            {
                                validInput = true; // Устанавливаем флаг в true
                            }
                        }
                    }

                    if (validInput)
                    {
                        char cell = board[row, col];
                        if (cell == 'С')
                        {
                            Console.WriteLine("Вы нашли сокровище!");
                            treasuresFound++;
                            board[row, col] = '.'; // Удаляем найденное сокровище
                        }
                        else if (cell == 'Л')
                        {
                            Console.WriteLine("Вы попали в ловушку! Игра окончена!");
                            gameInProgress = false; // Завершение игры
                        }
                        else
                        {
                            Console.WriteLine("Эта клетка пустая. Продолжайте искать!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод! Пожалуйста, введите координаты в формате A0.");
                    }
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();

                // Проверяем условие победы
                if (treasuresFound == treasuresToFind)
                {
                    Console.Clear();
                    PrintBoard(board);
                    Console.WriteLine("Поздравляем! Вы нашли все сокровища!");
                    gameInProgress = false; // Завершение игры
                }
            }

            Console.WriteLine("Спасибо за игру!");
        }

        static void PrintBoard(char[,] board)
        {
            Console.WriteLine("  A B C D E F G H I J");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + " "); // Выводим номер строки, начиная с 0
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(board[i, j] + " "); // Выводим содержимое ячейки
                }
                Console.WriteLine();
            }
        }

        static string GetUserInput()
        {
            string input = string.Empty; // Переменная для хранения ввода
            bool validInputReceived = false; // Флаг для проверки корректности ввода

            while (!validInputReceived) // Цикл продолжается, пока не получен корректный ввод
            {
                Console.Write("Введите координаты (например, A0) или 'exit' для выхода: ");
                input = Console.ReadLine();

                if (input.Length == 2 || input.ToLower() == "exit") // Проверяем, что ввод корректный
                {
                    validInputReceived = true; // Устанавливаем флаг, если ввод корректный
                }
                else
                {
                    Console.WriteLine("Некорректный ввод! Пожалуйста, введите координаты в формате A0.");
                }
            }

            return input; // Возвращаем корректный ввод
        }
    

    static void Main(string[] args)
            {
                bool running = true;
                while (running)
                {
                    double x = Menu();
                    switch (x)
                    {
                        case 1:
                            MathGame();
                            break;
                        case 2:
                            Info();
                            break;
                        case 3:
                            int b = MassivSize();

                            int[] RandArray = MassivInicialization(b);
                            int[] NewMassiv = CopyArray(RandArray);
                            Console.WriteLine("Начальный массив:");
                            PrintArray(NewMassiv);
                            double TimeSelection = SelectionTime(RandArray);
                            double TimeShell = ShellTime(NewMassiv);
                            Sorter(TimeSelection, TimeShell, b, RandArray, NewMassiv);
                            break;
                         case 4:
                         PlayTreasureHunt();
                            break;
                         case 5:
                            running = ExitProgram();
                            break;
                    }

                }
    }
}
   

