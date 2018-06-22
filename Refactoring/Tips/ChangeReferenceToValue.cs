using System;

namespace Refactoring.Tips
{
	public class ChangeReferenceToValue
	{
		public class CurrencyBefore
		{
			private CurrencyBefore(string code) => Code = code;
			public string Code { get; }
		}

		public struct CurrencyAfter : IEquatable<CurrencyAfter>
		{
			public string Code { get; }

			private CurrencyAfter(string code) => Code = code;

			public bool Equals(CurrencyAfter other) => string.Equals(Code, other.Code);

			public override bool Equals(object obj)
			{
				if (obj is null) return false;
				return obj is CurrencyAfter after && Equals(after);
			}

			public override int GetHashCode() => Code != null ? Code.GetHashCode() : 0;
		}
	}
}