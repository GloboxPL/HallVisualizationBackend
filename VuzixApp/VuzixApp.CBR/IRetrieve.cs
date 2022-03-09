namespace VuzixApp.CBR;

public interface IRetrieve<T>
{
	IDataSource<T> DataSource { get; }

	IEnumerable<T> GetSimilarCases()
	{
		return DataSource.GetFilteredData();
	}
}