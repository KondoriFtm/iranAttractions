using iranAttractions.Models;
using iranAttractions.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace iranAttractions.Services
{
    public class AttractionService
    {
        public List<HotelDistancesViewModel> CalculateHotelDistances(Sightseeing sightseeing, List<Hotel> hotels)
        {
            List<HotelDistancesViewModel> hotelDistances = new List<HotelDistancesViewModel>();
            foreach (var hotel in hotels)
            {
                double distance = DistanceCalculator.CalculateDistance(sightseeing.lat, sightseeing.lon, hotel.lat, hotel.lon);
                distance = Math.Round(distance, 5);
                hotelDistances.Add(new HotelDistancesViewModel { distance = distance, Hotel = hotel });
            }
            return hotelDistances.OrderBy(h => h.distance).ToList();
        }

        public List<ResturantDistancesViewModel> CalculateRestaurantDistances(Sightseeing sightseeing, List<Resturant> restaurants)
        {
            List<ResturantDistancesViewModel> restaurantDistances = new List<ResturantDistancesViewModel>();
            foreach (var restaurant in restaurants)
            {
                double distance = DistanceCalculator.CalculateDistance(sightseeing.lat, sightseeing.lon, restaurant.lat, restaurant.lon);
                distance = Math.Round(distance, 5);
                restaurantDistances.Add(new ResturantDistancesViewModel { distance = distance, resturant = restaurant });
            }
            return restaurantDistances.OrderBy(r => r.distance).ToList();
        }
    }
}
