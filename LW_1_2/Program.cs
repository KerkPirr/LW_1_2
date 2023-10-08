//Создать очередь, содержащий 14 целых чисел из интервала (-8, 35). Вывести элементы очереди.
//Реализовать основные операции над очередью и процедуру/функцию, которая  добавляет элемент, равный следующему за первым отрицательным элементом очереди.
//Автор: Сушко Алексей
//Версия 1.3 от 08.10.2023
namespace Queue
{
    class Program
    { 

        static void Main() {
            Queue<int> ints = new Queue<int>();
            //Random random = new Random();
            //for (int i = 0; i < 14; i++)
            //{
            //    int randomInt = random.Next(-8, 36);
            //    ints.Enqueue(randomInt);
            //}
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Заполнить очередь случайными числами");
                Console.WriteLine("2 - Занести эл-т в очередь");
                Console.WriteLine("3 - Извлечь элемент из очереди");
                Console.WriteLine("4 - Проверка на непустоту");
                Console.WriteLine("5 - Вывести первый элемент в очереди");
                Console.WriteLine("6 - проверить наличие элемента в очереди");
                Console.WriteLine("7 - Удалить очередь");
                Console.WriteLine("8 - Добавить эл-т, равный следующему за первым отрицательным элементом очереди");
                Console.WriteLine("9 - Выход");

                int.TryParse(Console.ReadLine(), out int a);
                switch (a)
                {
                    case 1:
                        Console.Clear();
                        fillingWithRand(ints);
                        Console.WriteLine("Числа:");
                            foreach (int i in ints)
                        {
                            Console.WriteLine(i);
                        }
                        Console.WriteLine("добавлены в очередь.\nНажмите Enter для продолжения.");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Введите число:");
                        if(int.TryParse(Console.ReadLine(), out int val))
                        {
                            ints.Enqueue(val);
                            Console.WriteLine($"Число {val} успешно добавлено!\nНажмите Enter для продолжения.");
                        }
                        else
                        {
                            Console.WriteLine("Невозможно добавить введеное значение! Попробуйте еще раз.\nДля продолжения нажмите Enter");
                            Console.ReadLine();
                            goto case 1;
                        }
                       
                        break;
                    case 3: 
                        Console.Clear();
                        if (ints.Count() > 0)
                        {
                            Console.WriteLine($"Число {ints.Dequeue()} успешно извлечено!\nНажмите Enter для продолжения.");
                        }
                        else
                        {
                            Console.WriteLine("Очередь пуста!");
                        }
                        break;
                    case 4:
                        Console.Clear();
                        if (ints.Count() > 0)
                        {
                            Console.WriteLine("Числа в очереди:");
                            foreach (int i in ints)
                            {
                               Console.WriteLine(i);
                            }
                            Console.WriteLine("Для продолжения нажмите Enter");
                        }
                        else
                        {
                            Console.WriteLine("Очередь пуста!");
                        }
                        break;
                    case 5:
                        Console.Clear();
                        if (ints.Count() > 0)
                        {
                            Console.WriteLine($"Первое число в списке: {ints.Peek()}\nНажмите Enter для продолжения.");
                        }
                        else
                        {
                            Console.WriteLine("Очередь пуста!");
                        }
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Введите число, которое нужно найти:");
                        if(int.TryParse(Console.ReadLine(), out int b) && ints.Contains(b))
                        {
                            Console.Clear();
                            Console.WriteLine($"Число {b} находится в очереди");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Искомого числа в очереди нет");
                        }
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Вы действительно хотите очистить очередь?\nВведите 1 чтоб подтвердить.\nНажмите любую другую клавишу для отмены");
                        int.TryParse(Console.ReadLine(), out b);
                        Console.Clear();
                        switch (b)
                        {
                            case 1:
                                ints.Clear();
                                Console.WriteLine("Очередь успешна очищена!\nНажмите Enter для продолжнеия");
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Отмена очистки очереди.\nНажмите Enter для продолжения");
                                break;
                        }
                        break; 
                    case 8:
                        Console.Clear();
                        enqueNegativeInt(ints);
                        Console.WriteLine("Нажмите Enter для продолжения");
                        break;
                    case 9:
                        Console.Clear();
                        Console.WriteLine("Для выхода нажмите Esc");
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода!\nДля продолжения нажмите Enter");
                        break;
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        static void enqueNegativeInt(Queue<int> queue) { 
            Queue<int> tempQ = new Queue<int>();
            int negative = 1;
            int added;
            foreach (int i in queue)
            {
                tempQ.Enqueue(i);
            }
            while(tempQ.Count>0 && negative > 0)
            {
                if (tempQ.Peek() < 0 && tempQ.Count>0)
                {
                    negative = tempQ.Dequeue();
                    added = tempQ.Dequeue();
                    queue.Enqueue(added);
                    Console.WriteLine($"Число {added} добавлено в очередь");
                }
                else
                {
                    if (tempQ.Count() > 0)
                    {
                        tempQ.Dequeue();
                    }
                }
            }
            if(negative > 0)
            {
                Console.WriteLine("Невозможно добавить!");
            }

        }
        static void fillingWithRand(Queue<int> queue)
        {
            Random random = new Random();
            queue.Clear();
            for (int i = 0; i < 14; i++)
            {
                int randomInt = random.Next(-8, 36);
                queue.Enqueue(randomInt);
            }
        }
    }
}
