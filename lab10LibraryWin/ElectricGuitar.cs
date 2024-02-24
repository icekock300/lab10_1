using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10LibraryWin
{
    public class ElectricGuitar : Guitar
    {
        protected string PowerSource { get; set; }

        public ElectricGuitar() : base()
        {
            PowerSource = "";
        }

        public ElectricGuitar(string instrumentName, int numberOfGuitarStrings, string powerSource) : base(instrumentName, numberOfGuitarStrings)
        {
            NumberOfGuitarStrings = numberOfGuitarStrings;
            PowerSource = powerSource;
        }

        [ExcludeFromCodeCoverage]
        public override void ShowVirtual()
        {
            Console.WriteLine($"Название инструмента: {InstrumentName}, количество струн электрогитары: {NumberOfGuitarStrings} источник питания электрогитары: {PowerSource}");
        }

        [ExcludeFromCodeCoverage]
        public void Show()
        {
            Console.WriteLine($"Название инструмента: {InstrumentName}, количество струн электрогитары: {NumberOfGuitarStrings} источник питания электрогитары: {PowerSource}");
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is not ElectricGuitar) return false;
            return ((ElectricGuitar)obj).InstrumentName == this.InstrumentName && ((ElectricGuitar)obj).PowerSource == this.PowerSource;
        }

        public override void RandomInit()
        {
            base.RandomInit();
            InstrumentName = "электрогитара";
            string[] lines = {
                "батарейки",
                "аккумуляторы",
                "фиксированный источник питания",
                "USB"
            };

            Random rnd = new Random();

            PowerSource = lines[rnd.Next(lines.Length)];
        }

        public string GetPowerSource()
        {
            return PowerSource;
        }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return base.ToString() + $"источник питания электрогитары: {PowerSource}";
        }

        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            InstrumentName = "электрогитара";
            Console.WriteLine("Введите количество струн электрогитары:");
            try
            {
                NumberOfGuitarStrings = int.Parse(Console.ReadLine());
            }
            catch
            {
                NumberOfGuitarStrings = 15;
            }
            Console.WriteLine("Введите источник питания электрогитары:");
            Console.ReadLine();
        }
    }
}
