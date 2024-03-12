using lab10LibraryWin;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace lab10win
{

    public static class QueueExtensions
    {
        public static Queue<T> Clone<T>(this Queue<T> original) where T : ICloneable
        {
            Queue<T> clonedQueue = new Queue<T>();

            foreach (T item in original)
            {
                clonedQueue.Enqueue((T)item.Clone());
            }

            return clonedQueue;
        }
    }

    class Program
    {
        static int IsInt(int min, int max) //функция для проверки на Int (параметры - минимальное и максимальное значение)
        {
            bool isConvert;
            int number;
            do
            {
                string buf = Console.ReadLine();
                isConvert = int.TryParse(buf, out number);
                if (!isConvert || number < min || number > max)
                {
                    Console.WriteLine($"Неправильно введено число. Введите значение от {min} до {max}");
                }
            } while (!isConvert || number < min || number > max);
            return number;
        }

        static int CountPiano(ArrayList arr) //функция для запроса #1 (количество пианино, клавиш которого больше 60)
        {
            int counterPiano = 0;
            foreach (MusicalInstrument item in arr)
            {
                Piano t = item as Piano;
                if (t != null)
                    if (t.GetNumberOfPianoKeys() > 60)
                    {
                        counterPiano++;
                    }
            }
            return counterPiano;
        }

        static int CountBattaries(ArrayList arr) //функция для запроса #2 (количество электрогитар с источником питания аккумуляторами)
        {
            int counterBatteries = 0;
            foreach (MusicalInstrument item in arr)
            {
                if (item is ElectricGuitar t)
                    if (t.GetPowerSource() == "аккумуляторы")
                    {
                        counterBatteries++;
                    }
            }
            return counterBatteries;
        }

        static int CountGuitars(ArrayList arr) //функция для запроса #3 (количество гитар)
        {
            int counterGuitar = 0;
            foreach (MusicalInstrument item in arr)
            {
                if (typeof(Guitar) == item.GetType())
                    counterGuitar++;
            }
            return counterGuitar;
        }

        static int CountPianoQueue(Queue<MusicalInstrument> queue)
        {
            int counterPiano = 0;
            foreach (MusicalInstrument item in queue)
            {
                if (item.InstrumentName == "пианино")
                    counterPiano++;
            }
            return counterPiano;
        }

        static int CountGuitarsQueue(Queue<MusicalInstrument> queue)
        {
            int counterGuitars = 0;
            foreach (MusicalInstrument item in queue)
            {
                if (item.InstrumentName == "гитара")
                    counterGuitars++;
            }
            return counterGuitars;
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();

            //часть 2
            Queue<MusicalInstrument> queue = new Queue<MusicalInstrument>();
            Console.WriteLine($"В очереди {queue.Count} элементов");

            for (int i = 0; i < 5; i++)
            {
                MusicalInstrument m = new MusicalInstrument();
                m.RandomInit();
                queue.Enqueue(m);
            }
            for (int i = 0; i < 5; i++)
            {
                Guitar g = new Guitar();
                g.RandomInit();
                queue.Enqueue(g);
            }

            foreach (MusicalInstrument item in queue)
            {
                Console.WriteLine(item);
            }

            //добавление элементов
            Console.WriteLine("Введите, сколько элементов вы хотите добавить (от 1 до 20): ");
            int countForAddQueue = IsInt(1, 20);
            for (int i = 0; i < countForAddQueue; i++)
            {
                int choice = rnd.Next(1, 3);
                if (choice == 1)
                {
                    Guitar g = new Guitar();
                    g.RandomInit();
                    queue.Enqueue(g);
                }
                else
                if (choice == 2)
                {
                    MusicalInstrument m = new MusicalInstrument();
                    m.RandomInit();
                    queue.Enqueue(m);
                }
            }

            Guitar elemForSearchQueue = new Guitar();
            Console.WriteLine("Введите гитару для поиска");
            elemForSearchQueue.Init();
            if (queue.Contains(elemForSearchQueue))
                Console.WriteLine("Найден");
            else
                Console.WriteLine("Не найден");


            //удаление элементов
            Queue<MusicalInstrument> temp = new Queue<MusicalInstrument>();
            while (queue.Count > 0)
            {
                MusicalInstrument m = queue.Dequeue();
                if (!m.Equals(elemForSearchQueue))
                    temp.Enqueue(m);
                else
                    Console.WriteLine($"Удаляем {m}");
            }
            queue = temp;

            //клонирование
            Queue<MusicalInstrument> clonedQueue = queue.Clone();
            Console.WriteLine("\nВывод склонированной очереди");
            foreach (MusicalInstrument item in clonedQueue)
            {
                Console.WriteLine(item);
            }

            //запросы
            Console.WriteLine("\nВыведем все гитары из очереди");
            foreach (MusicalInstrument item in queue)
            {
                if (item is Guitar)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine($"Количество пианино в очереди = {CountPianoQueue(queue)}");
            Console.WriteLine($"Количество пианино в очереди = {CountGuitarsQueue(queue)}");

            Console.WriteLine(queue.Peek());
        }
    }
}