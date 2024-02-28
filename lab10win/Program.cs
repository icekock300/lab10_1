using lab10LibraryWin;
using System.Xml.Serialization;
namespace lab10win
{
    class Program
    {
        static void Main(string[] args)
        {
            //создание объектов иерархии
            Guitar guitar = new Guitar("Гитара", new IdNumber(1), 3); //создание объекта гитара
            guitar.Show();
            ElectricGuitar electricGuitar = new ElectricGuitar(); //создание объекта электрогитара
            electricGuitar.RandomInit(); //инициализация с помощью ДСЧ
            electricGuitar.Show();
            Piano piano = new Piano("пианино", new IdNumber(2), "октавная", 80); //создание объекта пианино
            piano.Show();

            Random oneTwoThree = new Random(); //ДСЧ

            Console.WriteLine("\nВведите желаемую длину массива от 20 до 100:");
            MusicalInstrument[] arr = new MusicalInstrument[IsInt(20, 100)]; //создание массива arr

            for (int i = 0; i < arr.Length; i++) //цикл для заполнения массива случайными иерархии объектами со случайными атрибутами
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

            //вывод созданного массива с помощью разных методов (невиртуальный и виртуальный)
            Console.WriteLine("\nВывод массива с помощью НЕвиртуальных методов");
            foreach (MusicalInstrument item in arr)
            {
                item.Show();
            }
            Console.WriteLine("\nВывод массива с помощью виртуальных методов");
            foreach (MusicalInstrument item in arr)
            {
                item.ShowVirtual();
            }

            //ЗАПРОСЫ (реализовано с помощью статических функций)
            Console.WriteLine($"\nКоличество пианино, у которых клавиш больше, чем 60 = {CountPiano(arr)}");
            Console.WriteLine($"Количество электрогитар, питающихся от аккумуляторов = {CountBattaries(arr)}");
            Console.WriteLine($"Количество гитар в коллекции = {CountGuitars(arr)}");

            //бинарный поиск в отсортированном массиве
            Piano pianoForSearch = new Piano("пианино", new IdNumber(4), "октавная", 77); //добавление в массив определенного объекта
            arr[0] = pianoForSearch;

            Console.WriteLine("\nВыведем отсортированный массив");
            Array.Sort(arr); //сортировка массива
            foreach (MusicalInstrument item in arr) //вывод отсортированного массива
            {
                item.ShowVirtual();
            }

            int pos = Array.BinarySearch(arr, new Piano("пианино", new IdNumber(4), "октавная", 77)); //бинарный поиск элемента в отсортированном массиве
            if (pos < 0)
            {
                Console.WriteLine("\nТакого элемента нет в массиве");
            }
            else
            {
                Console.WriteLine($"\nЭлемент находится на {pos + 1} позиции");
            }

            //сортировка с помощью IComparer
            Console.WriteLine("\nВведите длину массива из гитар от 20 до 50");
            MusicalInstrument[] arrGuitar = new MusicalInstrument[IsInt(20, 50)]; //создание массива, состоящего из гитар
            for (int i = 0; i < arrGuitar.Length; i++) //заполнение массива гитарами (обычная и электро) с помощью ДСЧ
            {
                int type = oneTwoThree.Next(1, 3);
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

            Console.WriteLine("\nВыведем массив гитар:");
            foreach (MusicalInstrument item in arrGuitar) //вывод массива гитар с помощью виртуального метода
            {
                item.ShowVirtual();
            }

            Array.Sort(arrGuitar, new SortByNumberOfStrings()); //сортировка массива гитар по количеству струн
            Console.WriteLine("\nВыведем массив гитар, отсортированного по количеству струн:");
            foreach (MusicalInstrument item in arrGuitar) //вывод отсортированного массива гитар по количеству струн
            {
                item.ShowVirtual();
            }


            //интерфейсы
            IInit[] arrInterface = new IInit[20]; //создание массива с помощью интерфейсов
            for (int i = 0; i < arrInterface.Length / 2; i++) //заполнение массива объектами из иерархии
            {
                Random rnd = new Random();
                int choice = rnd.Next(1, 4);
                if (choice == 1)
                {
                    Guitar g = new Guitar();
                    g.RandomInit();
                    arrInterface[i] = g;
                }
                else
                if (choice == 2)
                {
                    ElectricGuitar e = new ElectricGuitar();
                    e.RandomInit();
                    arrInterface[i] = e;
                }
                else
                {
                    Piano p = new Piano();
                    p.RandomInit();
                    arrInterface[i] = p;
                }
            }

            for (int i = 10; i < arrInterface.Length; i++) //заполнение массива объектами из класса ЛР9
            {
                Student s = new Student();
                s.RandomInit();
                arrInterface[i] = s;
            }

            Console.WriteLine("\nВывод массива, созданного с помощью интерфейсов");
            foreach (IInit item in arrInterface) //цикл для вывода элементов массива, созданного с помощью интерфейса
            {
                Console.WriteLine(item);
            }

            //клонирование и поверхностная копия
            MusicalInstrument clonedMusicalInstrument = (MusicalInstrument)arr[0].Clone(); //клонирование
            MusicalInstrument shallowCopy = arr[0].ShallowCopy(); //копия

            Console.WriteLine("\nCloned:");
            clonedMusicalInstrument.Show(); //вывод клонированного объекта

            Console.WriteLine("\nShallow Copy:");
            shallowCopy.Show(); //вывод объекта, созданного с помощью поверхностной копии
        }

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

        static int CountPiano(MusicalInstrument[] arr) //функция для запроса #1 (количество пианино, клавиш которого больше 60)
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

        static int CountBattaries(MusicalInstrument[] arr) //функция для запроса #2 (количество электрогитар с источником питания аккумуляторами)
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

        static int CountGuitars(MusicalInstrument[] arr) //функция для запроса #3 (количество гитар)
        {
            int counterGuitar = 0;
            foreach (MusicalInstrument item in arr)
            {
                if (typeof(Guitar) == item.GetType())
                    counterGuitar++;
            }
            return counterGuitar;
        }
    }
}