using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;

namespace lab10LibraryWin
{
    //public class IdNumber
    //{
    //    public int number;

    //    public int Number
    //    {
    //        get => number;
    //        set
    //        {
    //            if (value < 0)
    //                number = 0;
    //            else
    //                number = value;
    //        }
    //    }
    //    public IdNumber(int number)
    //    {
    //        Number = number;
    //    }
    //    public override string ToString()
    //    {
    //        return number.ToString();
    //    }

    //    public override bool Equals(object? obj)
    //    {
    //        if (obj is IdNumber n)
    //            return this.number == n.number;
    //        return false;
    //    }
    //}
    public class MusicalInstrument : IInit, IComparable//, ICloneable
    {
        protected string instrumentName;

        public string InstrumentName { get; set; }

        //public IdNumber id;

        public MusicalInstrument() //конструктор без параметров
        {
            InstrumentName = "NoName";
            //id = new IdNumber(1);
        }

        public MusicalInstrument(string instrumentName/*, int number*/) //конструктор с параметром
        {
            InstrumentName = instrumentName;
            //id = new IdNumber(number);
        }

        [ExcludeFromCodeCoverage]
        public virtual void ShowVirtual()
        {
            Console.WriteLine($"Название инструмента: {InstrumentName}");
        }

        [ExcludeFromCodeCoverage]
        public void Show()
        {
            Console.WriteLine($"Название инструмента: {InstrumentName}");
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is not MusicalInstrument) return false;
            return ((MusicalInstrument)obj).InstrumentName == this.InstrumentName;
        }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"id: , Название инструмента: {InstrumentName}";
        }

        public virtual void RandomInit()
        {
            string[] lines = {
                "Гитара",
                "Электрогитара",
                "Пианино"
            };

            Random rnd = new Random();

            InstrumentName = lines[rnd.Next(lines.Length)];
            //id.number = rnd.Next(1,100);
        }

        [ExcludeFromCodeCoverage]
        public virtual void Init()
        {
            //Console.WriteLine("Введите id");
            //try
            //{
            //    id.number = int.Parse(Console.ReadLine());
            //}
            //catch
            //{
            //    id.number = 0;
            //}
            Console.WriteLine("Введите название инструмента:");
            InstrumentName = Console.ReadLine();
        }

        public virtual int CompareTo(object? obj)
        {
            if (obj == null) return -1;
            if (obj is not MusicalInstrument) return -1;
            MusicalInstrument m = obj as MusicalInstrument;
            return String.Compare(this.InstrumentName, m.InstrumentName);
        }

        //public object Clone()
        //{
        //    return new MusicalInstrument(InstrumentName, id.number);
        //}

        //public object ShallowCopy()
        //{
        //    return this.MemberwiseClone();
        //}
    }
}
