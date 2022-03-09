namespace VuzixApp.CBR;

public interface IDataSource<T>
{
	IEnumerable<T> GetFilteredData(params object[] args);
}