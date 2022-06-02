using VuzixApp.CBR;
using VuzixApp.Models;

namespace VuzixApp.ReservationDatesPrediction;

public class ReservationCBR : CBR<Reservation, DataR>
{
	protected override IRetrieve<Reservation> Retrieve { get; }
	protected override IReuse<Reservation> Reuse { get; }

	public ReservationCBR(IRetrieve<Reservation> retrieve, IReuse<Reservation> reuse)
	{
		Retrieve = retrieve;
		Reuse = reuse;
	}

	public override IEnumerable<Reservation> GetResult(DataR data)
	{
		var cases = Retrieve.GetSimilarCases(new string[] { data.UserId, data.DeviceId });
		return Reuse.AdaptCases(cases);
	}
}