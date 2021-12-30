using VuzixApp.CBR;
using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.ReservationCBR;

public class ReservationRetrieve : IRetrieve<Reservation>
{
	private readonly string _person;
	private readonly string _deviceFullName;

	public IDataSource<Reservation> DataSource { get; }

	public ReservationRetrieve(IDataSource<Reservation> dataSource, string person, string deviceFullName)
	{
		DataSource = dataSource;
		_person = person;
		_deviceFullName = deviceFullName;
	}

	IEnumerable<Reservation> IRetrieve<Reservation>.GetSimilarCases()
	{
		return DataSource.GetFilteredData(new object[] { _person, _deviceFullName });
	}
}