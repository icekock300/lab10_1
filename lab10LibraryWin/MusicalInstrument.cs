using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;

namespace lab10LibraryWin
{
    public class IdNumber
    {
        protected int id; //поле id
        public int Id //свойство для поля id
        {
            get => id;
            set
            {
                if (value < 0)
                    id = 0;
                else
                    id = value;
            }
        }
        public IdNumber(int id) //конструктор с параметром
        {
            Id = id;
        }
        public override string ToString() //перегруженный метод ToString
        {
            return Id.ToString();
        }
        public override bool Equals(object obj) //перегруженный метод Equals
        {
            if (obj == null) return false;
            if (obj is IdNumber i)
                return Id == i.Id;
            return false;
        }
    }

        public class MusicalInstrument : IInit, IComparable, ICloneable
        {
            protected string instrumentName;

            public string InstrumentName { get; set; }
            public IdNumber id;

            public IdNumber Id { get { return id; } }

            public MusicalInstrument() //конструктор без параметров
            {
                InstrumentName = "NoName";
                id = new IdNumber(1);
            }

            public MusicalInstrument(string instrumentName, IdNumber id) //конструктор с параметром
            {
                InstrumentName = instrumentName;
                this.id = id;
            }

            [ExcludeFromCodeCoverage]
            public virtual void ShowVirtual() //виртуальный метод для вывода объекта на печать
            {
                Console.WriteLine($"id: {id}, Название инструмента: {InstrumentName}");
            }

            [ExcludeFromCodeCoverage]
            public void Show() //невиртуальный метод для вывода объекта на печать
            {
                Console.WriteLine($"id: {id}, Название инструмента: {InstrumentName}");
            }


            public override bool Equals(object obj) //метод для сравнивания объектов
            {
                if (obj == null) return false;
                if (obj is not MusicalInstrument) return false;
                return ((MusicalInstrument)obj).InstrumentName == this.InstrumentName;
            }

            [ExcludeFromCodeCoverage]
            public override string ToString()
            {
                return $"id: {id}, Название инструмента: {InstrumentName}";
            }

            public virtual void RandomInit() //виртуальный метод для инициализации объекта с ДСЧ
            {
                string[] lines = {
                "Гитара",
                "Электрогитара",
                "Пианино"
            };

                Random rnd = new Random();

                InstrumentName = lines[rnd.Next(lines.Length)];
                id.Id = rnd.Next(0, 100);
            }

            [ExcludeFromCodeCoverage]
            public virtual void Init() //виртуальный метод для инициализации объекта с клавиатуры
            {
                Console.WriteLine("Введите название инструмента:");
                InstrumentName = Console.ReadLine();

                Console.WriteLine("Введите id");
                try
                {
                    id.Id = int.Parse(Console.ReadLine());
                }
                catch
                {
                    id.Id = 0;
                }
        }

            public virtual int CompareTo(object? obj)
            {
                if (obj == null) return -1;
                if (obj is not MusicalInstrument) return -1;
                MusicalInstrument m = obj as MusicalInstrument;
                return String.Compare(this.InstrumentName, m.InstrumentName);
            }

            public object Clone() //метод для клонирования
            {
                return new MusicalInstrument(InstrumentName, id);
            }

            public MusicalInstrument ShallowCopy() //метод для поверхностного копирования
            {
                return (MusicalInstrument)this.MemberwiseClone();
            }
        }

    }