using Backend.Mock;
using Backend.Models;
using System.Collections.Generic;

namespace Backend.CBR
{
	public class CBRMain
	{
		IRetrieve<Reservation> retrieve = new Retrieve(new TempSimilarity(CBRMock.Bob), new CBRMock());

		public IEnumerable<Reservation> GetResult()
		{
			var cases = retrieve.GetSimilarCases();
			var adaptation = new Adaptation(cases);
			var res = adaptation.Adapt();
			return res;
		}
	}
}
