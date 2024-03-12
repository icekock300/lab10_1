using System;
namespace lab10LibraryWin
{
	public class TestCollections
	{
		public SortedDictionary<MusicalInstrument, Guitar> collection1 = new SortedDictionary<MusicalInstrument, Guitar>();
		public SortedDictionary<string, Guitar> collection2 = new SortedDictionary<string, Guitar>();
		public HashSet<Guitar> collection3 = new HashSet<Guitar>();
		public HashSet<string> collection4 = new HashSet<string>();

		public TestCollections()
		{
			for (int i = 0; i < 1000; i++)
			{
				Guitar guitar = new Guitar();
				guitar.RandomInit();

				guitar.InstrumentName += i.ToString();
				collection1.Add(guitar.GetBase, guitar);
				collection2.Add(guitar.ToString(), guitar);
				collection3.Add(guitar);
				collection4.Add(guitar.ToString());
            }
		}
	}
}

