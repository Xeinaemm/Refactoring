namespace Refactoring.Tips
{
	public class ExtractInterfaceBefore
	{
		public class BasePagination
		{
			public int TotalCount { get; set; }
			public int PageSize { get; set; }
			public int CurrentPage { get; set; }
			public int TotalPages { get; set; }
		}

		public class HateoasPagination
		{
			public int TotalCount { get; set; }
			public int PageSize { get; set; }
			public int CurrentPage { get; set; }
			public int TotalPages { get; set; }
			public string PreviousPage { get; set; }
			public string NextPage { get; set; }
		}
	}

	public class ExtractInterfaceAfter
	{
		public interface IBasePagination
		{
			int TotalCount { get; set; }
			int PageSize { get; set; }
			int CurrentPage { get; set; }
			int TotalPages { get; set; }
		}

		public interface IHateoasPagination : IBasePagination
		{
			string PreviousPage { get; set; }
			string NextPage { get; set; }
		}

		public class BasePagination : IBasePagination
		{
			public int TotalCount { get; set; }
			public int PageSize { get; set; }
			public int CurrentPage { get; set; }
			public int TotalPages { get; set; }
		}

		public class HateoasPagination : IHateoasPagination
		{
			public int TotalCount { get; set; }
			public int PageSize { get; set; }
			public int CurrentPage { get; set; }
			public int TotalPages { get; set; }
			public string PreviousPage { get; set; }
			public string NextPage { get; set; }
		}
	}
}