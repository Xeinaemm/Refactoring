namespace Refactoring.Tips
{
	public class ReplaceArrayWithObject
	{
		public void Before()
		{
			var row = new string[3];
			row[0] = "Liverpool";
			row[1] = "15";
		}

		public void After()
		{
			var row = new Performance
			{
				Name = "Liverpool",
				Wins = "15"
			};
		}
	}

	public class Performance
	{
		public string Name { get; set; }
		public string Wins { get; set; }
	}
}