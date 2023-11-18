using Travel_Agency_Domain.Others;
using Travel_Agency_Domain.Services;

namespace Travel_Agency_Logic.Request;

public class TouristPlaceRequest
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Address Address { get; set; } = null!;
    
    public int ImageId { get; set; }

    public TouristPlace TouristPlace(TouristPlace? touristPlace = null) 
    {
        touristPlace ??= new TouristPlace(this.Name, this.Description, this.Address, ImageId);
        touristPlace.Name = this.Name;
        touristPlace.Description = this.Description;
        touristPlace.Address = this.Address;
        touristPlace.ImageId = this.ImageId;
      
        return touristPlace;
    }
}