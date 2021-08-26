using System.Collections.Generic;
using Backend.Models;

namespace Backend.Services
{
    public interface IDatabaseManager
    {
        Device GetDevice(string id);
        IEnumerable<Device> GetAllDevices(int hallId = 0);
    }
}