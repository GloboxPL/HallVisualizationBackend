using Backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace Backend.CaseBasedReasoning
{
	public class ReservationSimilarity : ISimilarity<Reservation>
	{
		private string person;
		public ReservationSimilarity(string person)
		{
			this.person = person;
		}
		public IEnumerable<Reservation> GetSimilarCases(IEnumerable<Reservation> allCases)
		{
			return allCases.Where(x => x.Person == person);
		}
	}
}
