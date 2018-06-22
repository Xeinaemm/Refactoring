using System;
using System.Collections.Generic;

namespace Refactoring.Tips
{
	public class SeparateQueryFromModifier
	{
		private string FoundMiscreantBefore(IEnumerable<string> people)
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

		private void CheckSecurityBefore(IEnumerable<string> people)
		{
			var person = FoundMiscreantBefore(people);
		}

		private static void SendAlert()
		{
			Console.WriteLine("Hello!");
		}

		private static void SendAlertAfter(IEnumerable<string> people)
		{
			if (!FoundPerson(people).Equals("")) SendAlert();
		}

		private static string FoundPerson(IEnumerable<string> people)
		{
			foreach (var person in people)
			{
				if (person.Equals("Don")) return "Don";
				if (person.Equals("John")) return "John";
			}

			return string.Empty;
		}

		private void CheckSecurityAfter(string[] people)
		{
			SendAlertAfter(people);
			var person = FoundPerson(people);
		}
	}
}