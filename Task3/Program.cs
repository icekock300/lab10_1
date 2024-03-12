using System.Diagnostics;
using lab10LibraryWin;

namespace Task3;

class Program
{
    static void Main(string[] args)
    {
        TestCollections testCollections = new TestCollections();

        // Извлечение первого элемента из SortedDictionary
        var firstKeyValuePair = testCollections.collection1.First();
        MusicalInstrument firstMusicalInstrument = firstKeyValuePair.Key;
        Guitar firstGuitar = firstKeyValuePair.Value;

        // Извлечение элемента из SortedDictionary, находящегося в середине
        int middleIndex = testCollections.collection1.Count / 2;
        var middleKeyValuePair = testCollections.collection1.Skip(middleIndex).First();
        MusicalInstrument middleMusicalInstrument = middleKeyValuePair.Key;
        Guitar middleGuitar = middleKeyValuePair.Value;

        // Извлечение последнего элемента из SortedDictionary
        var lastKeyValuePair = testCollections.collection1.Last();
        MusicalInstrument lastMusicalInstrument = lastKeyValuePair.Key;
        Guitar lastGuitar = lastKeyValuePair.Value;

        Guitar first = new Guitar(firstGuitar.InstrumentName, new IdNumber(firstGuitar.id.Id), firstGuitar.NumberOfGuitarStrings);
        Guitar middle = new Guitar(middleGuitar.InstrumentName, new IdNumber(middleGuitar.id.Id), middleGuitar.NumberOfGuitarStrings);
        Guitar last = new Guitar(lastGuitar.InstrumentName, new IdNumber(lastGuitar.id.Id), lastGuitar.NumberOfGuitarStrings);
        Guitar other = new Guitar("гитара", new IdNumber(int.MaxValue), 7);

        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine("SortedDictionary Guitar");
        long time1 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection1.ContainsValue(first);
            stopwatch.Stop();
            time1 += stopwatch.ElapsedMilliseconds;
        }
        time1 = time1 / 10;

        Console.WriteLine($"First element = {time1}");

        long time2 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection1.ContainsValue(middle);
            stopwatch.Stop();
            time2 += stopwatch.ElapsedMilliseconds;
        }
        time2 = time2 / 10;

        Console.WriteLine($"Middle element = {time2}");

        long time3 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection1.ContainsValue(last);
            stopwatch.Stop();
            time3 += stopwatch.ElapsedMilliseconds;
        }
        time3 = time3 / 10;

        Console.WriteLine($"Last element = {time3}");

        long time4 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection1.ContainsValue(other);
            stopwatch.Stop();
            time4 += stopwatch.ElapsedMilliseconds;
        }
        time4 = time4 / 10;

        Console.WriteLine($"Unknown element = {time4}");

        Console.WriteLine("\nSortedDictionary string");
        time1 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection2.ContainsKey(first.ToString());
            stopwatch.Stop();
            time1 += stopwatch.ElapsedMilliseconds;
        }
        time1 = time1 / 10;

        Console.WriteLine($"First element = {time1}");

        time2 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection2.ContainsKey(middle.ToString());
            stopwatch.Stop();
            time2 += stopwatch.ElapsedMilliseconds;
        }
        time2 = time2 / 10;

        Console.WriteLine($"Middle element = {time2}");

        time3 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection2.ContainsKey(last.ToString());
            stopwatch.Stop();
            time3 += stopwatch.ElapsedMilliseconds;
        }
        time3 = time3 / 10;

        Console.WriteLine($"Last element = {time3}");

        time4 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection2.ContainsKey(other.ToString());
            stopwatch.Stop();
            time4 += stopwatch.ElapsedMilliseconds;
        }
        time4 = time4 / 10;

        Console.WriteLine($"Unknown element = {time4}");

        Console.WriteLine("\nHashSet");
        long time5 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection3.Contains(first);
            stopwatch.Stop();
            time5 += stopwatch.ElapsedMilliseconds;
        }
        time5 = time5 / 10;

        Console.WriteLine($"First element = {time5}");

        long time6 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection3.Contains(middle);
            stopwatch.Stop();
            time6 += stopwatch.ElapsedMilliseconds;
        }
        time6 = time6 / 10;

        Console.WriteLine($"Middle element = {time6}");

        long time7 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection3.Contains(last);
            stopwatch.Stop();
            time7 += stopwatch.ElapsedMilliseconds;
        }
        time7 = time7 / 10;

        Console.WriteLine($"Last element = {time7}");

        long time8 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection3.Contains(other);
            stopwatch.Stop();
            time8 += stopwatch.ElapsedMilliseconds;
        }
        time8 = time8 / 10;

        Console.WriteLine($"Unknown element = {time8}");

        Console.WriteLine("\nHashset string");
        time5 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection4.Contains(first.ToString());
            stopwatch.Stop();
            time5 += stopwatch.ElapsedMilliseconds;
        }
        time5 = time5 / 10;

        Console.WriteLine($"First element = {time5}");

        time6 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection4.Contains(middle.ToString());
            stopwatch.Stop();
            time6 += stopwatch.ElapsedMilliseconds;
        }
        time6 = time6 / 10;

        Console.WriteLine($"Middle element = {time6}");

        time7 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection4.Contains(last.ToString());
            stopwatch.Stop();
            time7 += stopwatch.ElapsedMilliseconds;
        }
        time7 = time7 / 10;

        Console.WriteLine($"Last element = {time7}");

        time8 = 0;
        for (int i = 0; i < 10; i++)
        {
            stopwatch.Start();
            bool check = testCollections.collection4.Contains(other.ToString());
            stopwatch.Stop();
            time8 += stopwatch.ElapsedMilliseconds;
        }
        time8 = time8 / 10;

        Console.WriteLine($"Unknown element = {time8}");
    }
}

