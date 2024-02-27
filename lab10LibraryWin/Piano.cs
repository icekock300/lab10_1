using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10LibraryWin
{
    public class Piano : MusicalInstrument, IComparable
    {
        protected string TypeOfPiano { get; set; }
        protected int numberOfPianoKeys;

        public int NumberOfPianoKeys
        {
            get => numberOfPianoKeys;
            set
            {
                if (value < 0)
                    numberOfPianoKeys = 0;
                else
                    numberOfPianoKeys = value;
            }
        }

        public Piano() : base()
        {
            TypeOfPiano = "";
            NumberOfPianoKeys = 0;
        }

        public Piano(string instrumentName, IdNumber id, string typeOfPiano, int numberOfPianoKeys) : base(instrumentName, id)
        {
            TypeOfPiano = typeOfPiano;
            NumberOfPianoKeys = numberOfPianoKeys;
        }

        [ExcludeFromCodeCoverage]
        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.WriteLine($"тип раскладки: {TypeOfPiano}, количество клавиш = {NumberOfPianoKeys}");
        }

        [ExcludeFromCodeCoverage]
        public void Show()
        {
            base.Show();
            Console.WriteLine($"тип раскладки: {TypeOfPiano}, количество клавиш = {NumberOfPianoKeys}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is not Piano) return false;
            return ((Piano)obj).InstrumentName == this.InstrumentName && ((Piano)obj).TypeOfPiano == this.TypeOfPiano;
        }

        public override void RandomInit()
        {
            InstrumentName = "пианино";
            string[] lines = {
                "октавная",
                "шкальная",
                "дигитальная"
            };

            Random rnd = new Random();

            TypeOfPiano = lines[rnd.Next(lines.Length)];

            NumberOfPianoKeys = rnd.Next(20, 100);

            id.Id = rnd.Next(0, 100);
        }

        public int GetNumberOfPianoKeys()
        {
            return NumberOfPianoKeys;
        }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return base.ToString() + $"тип раскладки: {TypeOfPiano}, количество клавиш: {NumberOfPianoKeys}";
        }

        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            InstrumentName = "пианино";
            Console.WriteLine("Введите тип раскладки пианино:");
            TypeOfPiano = Console.ReadLine();
            Console.WriteLine("Введите количество клавиш пианино:");
            try
            {
                NumberOfPianoKeys = int.Parse(Console.ReadLine());
            }
            catch
            {
                NumberOfPianoKeys = 88;
            }
            Console.WriteLine("Введите id:");
            try
            {
                Id.Id = int.Parse(Console.ReadLine());
            }
            catch
            {
                Id.Id = 0;
            }
        }

        public override int CompareTo(object? obj)
        {
            if (obj == null) return -1;
            if (obj is not Piano) return -1;
            Piano p = obj as Piano;
            return String.Compare(this.TypeOfPiano, p.TypeOfPiano);
        }
    }
}
