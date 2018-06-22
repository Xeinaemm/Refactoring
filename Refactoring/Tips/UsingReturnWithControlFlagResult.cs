using System;
using System.Collections.Generic;

namespace Refactoring.Tips
{
	public class UsingReturnWithControlFlagResult
	{
		private void Before(IEnumerable<string> people)
		{
			var found = "";
			foreach (var person in people)
				if (found.Equals(""))
				{
					if (person.Equals("Don"))
					{
						SendAlert();
						found = "Don";
					}

					if (person.Equals("John"))
					{
						SendAlert();
						found = "John";
					}
				}

			Console.WriteLine(found);
		}

		private static void SendAlert()
		{
			Console.WriteLine("Hello!");
		}

		private void After(IEnumerable<string> people)
		{
			Console.WriteLine(FoundMiscreant(people));
		}

		private static string FoundMiscreant(IEnumerable<string> people)
		{
			foreach (var person in people)
			{
				if (person.Equals("Don"))
				{
					SendAlert();
					return "Don";
				}

				if (person.Equals("John"))
				{
					SendAlert();
					return "John";
				}
			}

			return string.Empty;
		}
	}
}