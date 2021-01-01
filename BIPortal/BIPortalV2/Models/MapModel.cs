using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Map.Models
{
    public class MaptPoints
    {
        public string latitude { set; get; }
        public string longitude { set; get; }
        public string title { set; get; }
        public string description { set; get; }

        public static List<MaptPoints> MapsLocation(int LocationTypeID)
        {
            using (var db = new DataModels.AICloudDB())
            {
                try
                {
                    var points = from location in db.AppLocations
                                   where location.LocationTypeID == LocationTypeID && location.Latitude != null
                                   select new MaptPoints
                                   {
                                       latitude = location.Latitude.ToString(),
                                       longitude = location.Longitude.ToString(),
                                       title = location.LocationName.ToString(),
                                       description = (location.CityName == null || location.CityName =="" ) ? "" : location.CityName.ToString()
                                   };
                    return points.ToList();
                }
                catch { return null; }
            }
        }

    }


    public class AirportLocation
    {
        public string latitude { set; get; }
        public string longitude { set; get; }
        public string title { set; get; }
        public string description { set; get; }

        public static List<AirportLocation> Airports(string country)
        {
            using (var db = new DataModels.AICloudDB())
            {
                try
                {
                    var points = from location in db.Airports
                                 where location.Country.ToLower() == country && location.Latitude != null
                                 select new AirportLocation
                                 {
                                     latitude = location.Latitude.ToString(),
                                     longitude = location.Longitude.ToString(),
                                     title = location.City.ToString(),
                                     description = location.Name.ToString()
                                 };
                    return points.ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
               
               
            }
        }

    }


    public class RailwayLocation
    {
        public string name { set; get; }
        public string startaddress { set; get; }
        public string endaddress { set; get; }
        public int id { set; get; }

        public static List<RailwayLocation> Railways()
        {
            using (var db = new DataModels.AICloudDB())
            {
                try
                {
                    var points = from location in db.RailWays
                                 select new RailwayLocation
                                 {
                                     id = location.Id,
                                     name = location.Name,
                                     startaddress = location.StartAddress,
                                     endaddress = location.EndAddress
                                 };
                    return points.ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }


            }
        }

    }


}