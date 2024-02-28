using lab10LibraryWin;
using System.Xml.Serialization;
namespace lab10win
{
    class Program
    {
        static void Main(string[] args)
        {
            Guitar guitar = new Guitar("Гитара", new IdNumber(1), 3);
            guitar.Show();
            ElectricGuitar electricGuitar = new ElectricGuitar();
            electricGuitar.RandomInit();
            electricGuitar.Show();
            Piano piano = new Piano("пианино", new IdNumber(2), "октавная", 80);
            piano.Show();

            Random oneTwoThree = new Random();

            Console.WriteLine("Введите желаемую длину массива от 20 до 100:");
            MusicalInstrument[] arr = new MusicalInstrument[IsInt(20, 100)];

            for (int i = 0; i < arr.Length; i++)
            {
                int type = oneTwoThree.Next(1, 4);
                if (type == 1)
                {
                    Guitar g = new Guitar();
                    g.RandomInit();
                    arr[i] = g;
                }
                else
                if (type == 2)
                {
                    ElectricGuitar e = new ElectricGuitar();
                    e.RandomInit();
                    arr[i] = e;
                }
                else
                {
                    Piano p = new Piano();
                    p.RandomInit();
                    arr[i] = p;
                }
            }

            Console.WriteLine("Вывод массива с помощью не виртуальных методов");
            foreach (MusicalInstrument item in arr)
            {
                item.Show();
            }
            Console.WriteLine("Вывод массива с помощью виртуальных методов");
            foreach (MusicalInstrument item in arr)
            {
                item.ShowVirtual();
            }

            int counterAkk = 0;
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
            Console.WriteLine($"Количество пианино, у которых клавиш больше, чем 60 = {counterPiano}");

            foreach (MusicalInstrument item in arr)
            {
                if (item is ElectricGuitar t)
                    if (t.GetPowerSource() == "аккумуляторы")
                    {
                        counterAkk++;
                    }
            }
            Console.WriteLine($"Количество электрогитар, питающихся от аккумуляторов = {counterAkk}");

            int counterGuitar = 0;
            foreach (MusicalInstrument item in arr)
            {
                if (typeof(Guitar) == item.GetType())
                    counterGuitar++;
            }
            Console.WriteLine($"Количество гитар в коллекции = {counterGuitar}");

            Piano pian = new Piano("пианино", new IdNumber(4), "октавная", 77);
            arr[0] = pian;

            Console.WriteLine("Выведем отсортированный массив");
            Array.Sort(arr);
            foreach (MusicalInstrument item in arr)
            {
                item.ShowVirtual();
            }

            int pos = Array.BinarySearch(arr, new Piano("пианино", new IdNumber(4), "октавная", 77));
            if (pos < 0)
            {
                Console.WriteLine("Такого элемента нет в массиве");
            }
            else
            {
                Console.WriteLine($"Элемент находится на {pos + 1} позиции");
            }


            Console.WriteLine("Введите длину массива из гитар от 20 до 50");
            MusicalInstrument[] arrGuitar = new MusicalInstrument[IsInt(20, 50)];
            for (int i = 0; i < arrGuitar.Length; i++)
            {
                int type = oneTwoThree.Next(1, 2);
                if (type == 1)
                {
                    Guitar g = new Guitar();
                    g.RandomInit();
                    arrGuitar[i] = g;
                }
                else if (type == 2)
                {
                    ElectricGuitar e = new ElectricGuitar();
                    e.RandomInit();
                    arrGuitar[i] = e;
                }
            }

            Console.WriteLine("Выведем массив гитар:");
            foreach (MusicalInstrument item in arrGuitar)
            {
                item.ShowVirtual();
            }

            Array.Sort(arrGuitar, new SortByNumberOfStrings());
            Console.WriteLine("Выведем массив гитар, отсортированный по количеству струн:");
            foreach (MusicalInstrument item in arrGuitar)
            {
                item.ShowVirtual();
            }


            //Интерфейсы
            IInit[] arr2 = new IInit[20];
            for (int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                int choice = rnd.Next(1, 4);
                if (choice == 1)
                {
                    Guitar g = new Guitar();
                    g.RandomInit();
                    arr2[i] = g;
                }
                else
                if (choice == 2)
                {
                    ElectricGuitar e = new ElectricGuitar();
                    e.RandomInit();
                    arr2[i] = e;
                }
                else
                {
                    Piano p = new Piano();
                    p.RandomInit();
                    arr2[i] = p;
                }
            }

            for (int i = 10; i < 20; i++)
            {
                Student s = new Student();
                s.RandomInit();
                arr2[i] = s;
            }

            Console.WriteLine("\narr2 с помощью интерфейсов");
            foreach (IInit item in arr2)
            {
                Console.WriteLine(item);
            }

            MusicalInstrument clonedMusicalInstrument = (MusicalInstrument)arr[0].Clone();

            MusicalInstrument shallowCopy = arr[0].ShallowCopy();

            Console.WriteLine("Cloned:");
            clonedMusicalInstrument.Show();

            Console.WriteLine("Shallow Copy:");
            shallowCopy.Show();

        }
        static int IsInt(int min, int max)
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

    }
}