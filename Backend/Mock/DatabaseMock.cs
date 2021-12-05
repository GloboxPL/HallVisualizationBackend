using Backend.Models;
using Backend.Services;
using System.Collections.Generic;

namespace Backend.Mock
{
	public class DatabaseMock : IDatabaseManager
	{
		public IEnumerable<Device> GetAllDevices(int hallId = 0)
		{
			return _devices;
		}

		public Device GetDevice(string id)
		{
			return _devices.Find(x => x.Id == id);
		}

		private static readonly List<Device> _devices = new()
		{
			new Device()
			{
				Id = "605b8f861553126224f50c88", //"605b8f861553126224f50c96",
				CustomId = 10000015,
				HallId = 0,
				Symbol = "10000-15",
				ShortName = "Zwick",
				FullName = "Zwick",
				Efficiency = 100,
				Socket = "Zwick",
				Height = 1
			},
			new Device()
			{
				Id = "605b8f861553126224f50c89", //"605b8f861553126224f50c97",
				CustomId = 10000016,
				HallId = 0,
				Symbol = "10000-16",
				ShortName = "Prasa500T",
				FullName = "Prasa500T",
				Efficiency = 100,
				Socket = "Prasy",
				Height = 1
			}
		};
	}
}