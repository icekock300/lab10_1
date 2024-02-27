using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10LibraryWin
{
    public class Guitar : MusicalInstrument
    {
        protected int numberOfGuitarStrings;

        public int NumberOfGuitarStrings
        {
            get => numberOfGuitarStrings;
            set
            {
                if (value < 0)
                    numberOfGuitarStrings = 0;
                else
                    numberOfGuitarStrings = value;
            }
        }

        public Guitar() : base()
        {
            NumberOfGuitarStrings = 0;
        }

        public Guitar(string instrumentName, IdNumber id, int numberOfGuitarStrings) : base(instrumentName, id)
        {
            NumberOfGuitarStrings = numberOfGuitarStrings;
        }

        [ExcludeFromCodeCoverage]
        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.WriteLine($"количество струн гитары: {NumberOfGuitarStrings}");
        }

        [ExcludeFromCodeCoverage]
        public void Show()
        {
            base.Show();
            Console.WriteLine($"количество струн гитары: {NumberOfGuitarStrings}");
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is not Guitar) return false;
            return ((Guitar)obj).InstrumentName == this.InstrumentName && ((Guitar)obj).NumberOfGuitarStrings == this.NumberOfGuitarStrings;
        }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return base.ToString() + $"количество струн: {NumberOfGuitarStrings}";
        }

        public override void RandomInit()
        {

            InstrumentName = "гитара";
            Random rnd = new Random();

            NumberOfGuitarStrings = rnd.Next(1, 20);

            id.Id = rnd.Next(0, 100);
        }

        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            InstrumentName = "гитара";
            Console.WriteLine("Введите количество струн гитары:");
            try
            {
                NumberOfGuitarStrings = int.Parse(Console.ReadLine());
            }
            catch
            {
                NumberOfGuitarStrings = 15;
            }
            Console.WriteLine("Введите id:");
            try
            {
                id.Id = int.Parse(Console.ReadLine());
            }
            catch
            {
                id.Id = 0;
            }
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

    }
}
