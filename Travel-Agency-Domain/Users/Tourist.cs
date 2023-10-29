using System.Collections;
using Travel_Agency_Core;
using Travel_Agency_Domain.Payments;

namespace Travel_Agency_Domain.Users;

public class Tourist : User
{
    public string Nationality { get; set; }

    public Tourist(string name, string email, string password, string nationality) : base(name, email, password,
        Roles.Tourist)
    {
        this.Nationality = nationality;
    }

    public ICollection<ReserveTourist> Reserves { get; set; } = null!;
}