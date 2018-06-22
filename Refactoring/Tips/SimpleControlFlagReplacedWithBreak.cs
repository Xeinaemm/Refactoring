using System;
using System.Collections.Generic;

namespace Refactoring.Tips
{
	public class SimpleControlFlagReplacedWithBreak
	{
		private void Before(IEnumerable<string> people)
		{
			var found = false;
			foreach (var person in people)
				if (!found)
				{
					if (person.Equals("Don"))
					{
						SendAlert();
						found = true;
					}

					if (person.Equals("John"))
					{
						SendAlert();
						found = true;
					}
				}
		}

		private static void SendAlert()
		{
			Console.WriteLine("Hello!");
		}

		private void After(IEnumerable<string> people)
		{
			foreach (var person in people)
			{
				if (person.Equals("Don"))
				{
					SendAlert();
					break;
				}

				if (person.Equals("John"))
				{
					SendAlert();
					break;
				}
			}
		}
	}
}