﻿using System;
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

        public int NumberOfGuitarStrings //свойство для количества струн
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

        public Guitar() : base() //конструктор без параметров
        {
            NumberOfGuitarStrings = 0;
        }

        public Guitar(string instrumentName, IdNumber id, int numberOfGuitarStrings) : base(instrumentName, id) //конструктор с параметрами
        {
            NumberOfGuitarStrings = numberOfGuitarStrings;
        }

        [ExcludeFromCodeCoverage]
        public override void ShowVirtual() //виртуальный метод вывода объектов
        {
            base.ShowVirtual();
            Console.WriteLine($"количество струн: {NumberOfGuitarStrings}");
        }

        [ExcludeFromCodeCoverage]
        public void Show() //невиртуальный метод вывода объектов
        {
            base.Show();
            Console.WriteLine($"количество струн: {NumberOfGuitarStrings}");
        }


        public override bool Equals(object obj) //метод для сравнения объектов
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

        public override void RandomInit() //инициализация объекта с помощью ДСЧ
        {

            InstrumentName = "гитара";
            Random rnd = new Random();

            NumberOfGuitarStrings = rnd.Next(1, 20);

            id.Id = rnd.Next(0, 100);
        }

        [ExcludeFromCodeCoverage]
        public override void Init() //инициализация объекта с клавиатуры
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
    }
}
