using Futuristic.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Futuristic.Models
{
    public class User
    {
        public Guid ApplicationId { get; set; }
        public double CurrentLat { get; set; }
        public double CurrentLong { get; set; }
        public DateTime TimeStamp { get; set; }
        public TimeZoneInfo CurrentTimeZone { get; set; }
        public string Name { get; set; }
        public int LocationRefreshIntervalinMinutes { get; set; }
        public User()
        {
            CurrentLat = 0;
            CurrentLong = 0;
            TimeStamp = DateTime.Now;
        }
        public async Task<Xamarin.Essentials.Location> CurrentLocation()
        {
            var currentLocation = new Xamarin.Essentials.Location();
            try
            {
                var locationManager = new LocationMonanager();
                currentLocation = await locationManager.GetLocationCache();
                return currentLocation;
            }
            catch
            {
                throw;
            }

        }
        public Guid CurrentUserId()
        {
            //TODo Save and get the userId from or may be email account
            return new Guid("c10f5df4-5906-43f6-b3ed-53e0ba868712");
        }
       
        // other information available in from the store


        //#if DEBUG
        //                var currentLocation = new Location(43.842330, -79.074900);
        //#else
        //                 var currentLocation = await locationManager.GetLocationCache();
        //#endif
    }
}
