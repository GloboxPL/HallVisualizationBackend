namespace VuzixApp.Domain.Models;

public enum DeviceStatus
{
    Pracuje = 0,
    StopAwaria = 1,
    Usterka = 3,
    Remont = 4,
    Modernizacja = 5,
    Przegląd = 6,
    Wyłączona = 7
}