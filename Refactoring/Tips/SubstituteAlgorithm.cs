using System.Collections.Generic;
using System.Linq;

namespace Refactoring.Tips
{
	public class SubstituteAlgorithm
	{
		private string FoundPersonBefore(IEnumerable<string> people)
		{
			foreach (var person in people)
			{
				if (person.Equals("Don")) return "Don";
				if (person.Equals("John")) return "John";
				if (person.Equals("Kent")) return "Kent";
			}

			return string.Empty;
		}

		private string FoundPersonAfter(IEnumerable<string> people)
		{
			var candidates = new[] {"Don", "John", "Kent"};
			foreach (var person in people)
				if (candidates.Contains(person))
					return person;

			return string.Empty;
		}
	}
}