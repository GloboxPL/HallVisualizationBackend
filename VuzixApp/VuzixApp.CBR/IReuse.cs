namespace VuzixApp.CBR;

public interface IReuse<T>
{
	IEnumerable<T> AdaptCases(IEnumerable<T> cases);
}