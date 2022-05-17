namespace VuzixApp.CBR;

public abstract class CBR<T, D>
{
	protected abstract IRetrieve<T> Retrieve { get; }
	protected abstract IReuse<T> Reuse { get; }

	public abstract IEnumerable<T> GetResult(D data);
}