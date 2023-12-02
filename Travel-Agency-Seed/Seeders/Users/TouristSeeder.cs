using Travel_Agency_DataBase;
using Travel_Agency_Domain.Users;

namespace Travel_Agency_Seed.Seeders.Users;

public class TouristSeeder:SeederBase<Tourist>
{
    public TouristSeeder() : base("Users/tourist")
    {
        
    }

    protected override async Task ConfigureSeed(TravelAgencyContext dbContext) => await SingleData(dbContext);
}