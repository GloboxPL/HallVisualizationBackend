using Backend.Models;
using System.Collections.Generic;

namespace Backend.CBR
{
	public class Retrieve : IRetrieve<Reservation>
	{
		public ISimilarityMeasure<Reservation> SimilarityMeasure { get; init; }
		public ICBRDataSource<Reservation> DataSource { get; init; }

		public Retrieve(ISimilarityMeasure<Reservation> similarityMeasure, ICBRDataSource<Reservation> dataSource)
		{
			SimilarityMeasure = similarityMeasure;
			DataSource = dataSource;
		}

		public IEnumerable<Reservation> GetSimilarCases()
		{
			var data = DataSource.GetData();
			return SimilarityMeasure.GetSimilarCases(data);
		}
	}
}
