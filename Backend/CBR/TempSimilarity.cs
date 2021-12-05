using Backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace Backend.CBR
{
	public class TempSimilarity : ISimilarityMeasure<Reservation>
	{
		private string person;
		public TempSimilarity(string person)
		{
			this.person = person;
		}
		public IEnumerable<Reservation> GetSimilarCases(IEnumerable<Reservation> allCases)
		{
			return allCases.Where(x => x.Person == person);
		}
	}
}
