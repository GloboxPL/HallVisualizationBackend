namespace VuzixApp.Domain.Models;

public enum DeviceStatus
{
    Working = 0,
    StopBreakdown = 1,
    Fault = 3,
    Repairs = 4,
    Modernization = 5,
    Review = 6,
    Off = 7
}