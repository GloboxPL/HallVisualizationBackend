using System.Collections.Generic;

namespace Backend.CaseBasedReasoning
{
	public interface IReuse<T>
	{
		IEnumerable<T> GetAdaptedCases(IEnumerable<T> cases)
		{
			List<T> list = new();
			foreach (var item in cases)
			{
				var obj = Adapt(item);
				if (obj != null)
				{
					list.Add(obj);
				}
			}
			return list;
		}
		protected T? Adapt(T obj);
	}
}
