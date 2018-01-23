using LocationAlert.Data.Models;
using System.Linq;

namespace LocationAlert.Data.Service.Models
{
    public static class DataHelper
    {
        public static Client ToDataModel(Account dataSvcClient)
        {
            var dataClient = new Client
            {
                Email = dataSvcClient.Email,
                Region = dataSvcClient.Regions.Select(ToDataModel).ToList(),
                Preference = new Preference()
                {
                    WeatherPreference = ToDataModel(dataSvcClient.WeatherPref)
                }
            };
            return dataClient;
        }

        public static Data.Models.Region ToDataModel(Region dataSvcRegion)
        {
            var dataRegion = new Data.Models.Region
            {
                Latitude = dataSvcRegion.Latitude,
                Longitude = dataSvcRegion.Longitude,
                Radius = dataSvcRegion.Radius
            };
            return dataRegion;
        }

        public static Data.Models.WeatherPreference ToDataModel(WeatherPreference dataSvcWeather)
        {
            var dataWeather = new Data.Models.WeatherPreference
            {
                PushHours = dataSvcWeather.PushHours,
                PushMinutes = dataSvcWeather.PushMinutes,
                AlwaysTemp = dataSvcWeather.AlwaysTemp,
                TempMin = dataSvcWeather.Temp[0],
                TempMax = dataSvcWeather.Temp[1],
                AlwaysRain = dataSvcWeather.AlwaysRain,
                RainMin = dataSvcWeather.Rain[0],
                RainMax = dataSvcWeather.Rain[1],
                AlwaysSnow = dataSvcWeather.AlwaysSnow,
                SnowMin = dataSvcWeather.Snow[0],
                SnowMax = dataSvcWeather.Snow[1],
                AlwaysCloud = dataSvcWeather.AlwaysCloud,
                CloudMin = dataSvcWeather.Cloud[0],
                CloudMax = dataSvcWeather.Cloud[1],
                AlwaysWind = dataSvcWeather.AlwaysWind,
                WindMin = dataSvcWeather.Wind[0],
                WindMax = dataSvcWeather.Wind[1],
                AlwaysHumidity = dataSvcWeather.AlwaysHumidity,
                HumidityMin = dataSvcWeather.Humidity[0],
                HumidityMax = dataSvcWeather.Humidity[1]
            };
            return dataWeather;
        }

        public static Account ToDataSvcModel(Client dataClient)
        {
            var dataSvcClient = new Account
            {
                Email = dataClient.Email,
                Regions = dataClient.Region.Select(ToDataSvcModel).ToList(),
                WeatherPref = ToDataSvcModel(dataClient.Preference.WeatherPreference)
            };
            return dataSvcClient;
        }

        public static Region ToDataSvcModel(Data.Models.Region dataRegion)
        {
            var dataSvcRegion = new Region
            {
                Latitude = dataRegion.Latitude,
                Longitude = dataRegion.Longitude,
                Radius = dataRegion.Radius
            };
            return dataSvcRegion;
        }

        public static WeatherPreference ToDataSvcModel(Data.Models.WeatherPreference dataWeather)
        {
            var dataSvcWeather = new WeatherPreference()
            {
                PushHours = dataWeather.PushHours,
                PushMinutes = dataWeather.PushMinutes,
                AlwaysTemp = dataWeather.AlwaysTemp,
                Temp = new[] { dataWeather.TempMin, dataWeather.TempMax },
                AlwaysRain = dataWeather.AlwaysRain,
                Rain = new[] { dataWeather.RainMin, dataWeather.RainMax },
                AlwaysSnow = dataWeather.AlwaysSnow,
                Snow = new[] { dataWeather.SnowMin, dataWeather.SnowMax },
                AlwaysCloud = dataWeather.AlwaysCloud,
                Cloud = new[] { dataWeather.CloudMin, dataWeather.CloudMax },
                AlwaysWind = dataWeather.AlwaysWind,
                Wind = new[] { dataWeather.WindMin, dataWeather.WindMax },
                AlwaysHumidity = dataWeather.AlwaysHumidity,
                Humidity = new[] { dataWeather.HumidityMin, dataWeather.HumidityMax }
            };
            return dataSvcWeather;
        }
    }
}
