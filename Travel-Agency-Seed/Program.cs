﻿using Microsoft.EntityFrameworkCore;
using Travel_Agency_DataBase;
using Travel_Agency_Seed.Seeders;
using Travel_Agency_Seed.Seeders.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Travel_Agency_Seed.Seeders.Users;


var serviceCollection = new ServiceCollection();
serviceCollection.AddLogging(builder => { builder.AddConsole(); });


var connectionString = "server=dpg-cr1bu05ds78s739r32hg-a;port=5432;database=travel_agency_hq44;user=travel_agency;password=KfBkjCQZyosMghKOC4AfNaIvLAaz2mNu";

var optionsBuilder = new DbContextOptionsBuilder<TravelAgencyContext>();
optionsBuilder.UseNpgsql(connectionString);

var serviceProvider = serviceCollection.BuildServiceProvider();
var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

await using (var context = new TravelAgencyContext(optionsBuilder.Options))
{
    try
    {
        logger.LogInformation("Migrate the database...");
        context.Database.Migrate();

        logger.LogInformation("Seeding the database...");
        await SeedDatabase(context);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while seeding the database");
    }
}


static async Task SeedDatabase(TravelAgencyContext context)
{
    // Create Seeders
    var image = new ImageSeeder();
    var agency = new AgencySeeder();

    var tourist = new TouristSeeder();
    var userAgency = new UsersAgencySeeder();

    var city = new CitySeeder();
    var touristPlace = new TouristPlaceSeeder();
    var touristActivity = new TouristActivitySeeder();
    var hotel = new HotelSeeder();
    var excursion = new ExcursionSeeder();
    var flight = new FlightSeeder();
    var facility = new FacilitySeeder();

    // Execute
    await image.Execute(context);
    await agency.Execute(context);

    await tourist.Execute(context);
    await userAgency.Execute(context);

    await city.Execute(context);
    await touristPlace.Execute(context);
    await touristActivity.Execute(context);
    await hotel.Execute(context);
    await flight.Execute(context);
    await excursion.Execute(context);
    await facility.Execute(context);
}