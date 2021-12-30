using System.Collections.Generic;

namespace Backend.CaseBasedReasoning
{
	public abstract class CBR<T>
	{
		protected readonly IDataSource<T> _dataSource;
		protected abstract IRetrieve<T> Retrieve { get; }
		protected abstract IReuse<T> Reuse { get; }

		protected CBR(IDataSource<T> dataSource)
		{
			_dataSource = dataSource;

		}

		public IEnumerable<T> GetResult()
		{
			var cases = Retrieve.GetSimilarCases();
			return Reuse.GetAdaptedCases(cases);
		}
	}
}
