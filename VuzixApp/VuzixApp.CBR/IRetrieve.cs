namespace VuzixApp.CBR;

public interface IRetrieve<T>
{
	IEnumerable<T> GetSimilarCases(params object[] objs);
}