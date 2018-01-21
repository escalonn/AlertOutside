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
                PushHours = dataSvcWeather.pushHours,
                PushMinutes = dataSvcWeather.pushMinutes,
                AlwaysTemp = dataSvcWeather.alwaysTemp,
                TempMin = dataSvcWeather.temp[0],
                TempMax = dataSvcWeather.temp[1],
                AlwaysRain = dataSvcWeather.alwaysRain,
                RainMin = dataSvcWeather.rain[0],
                RainMax = dataSvcWeather.rain[1],
                AlwaysSnow = dataSvcWeather.alwaysSnow,
                SnowMin = dataSvcWeather.snow[0],
                SnowMax = dataSvcWeather.snow[1],
                AlwaysCloud = dataSvcWeather.alwaysCloud,
                CloudMin = dataSvcWeather.cloud[0],
                CloudMax = dataSvcWeather.cloud[1],
                AlwaysWind = dataSvcWeather.alwaysWind,
                WindMin = dataSvcWeather.wind[0],
                WindMax = dataSvcWeather.wind[1],
                AlwaysHumidity = dataSvcWeather.alwaysHumidity,
                HumidityMin = dataSvcWeather.humidity[0],
                HumidityMax = dataSvcWeather.humidity[1]
            };
            return dataWeather;
        }

        public static Account ToDataSvcModel(Client dataClient)
        {
            var dataSvcClient = new Account
            {
                Email = dataClient.Email,
                Regions = dataClient.Region.Select(ToDataSvcModel).ToList(),
            };
            if (dataClient.Preference?.WeatherPreference != null)
            {
                dataSvcClient.WeatherPref = ToDataSvcModel(dataClient.Preference.WeatherPreference);
            }
            return dataSvcClient;
        }

        public static Region ToDataSvcModel(Data.Models.Region dataRegion)
        {
            var dataSvcRegion = new Region();
            if (dataRegion.Latitude != null)
            {
                dataSvcRegion.Latitude = (decimal)dataRegion.Latitude;
            }
            if (dataRegion.Longitude != null)
            {
                dataSvcRegion.Longitude = (decimal)dataRegion.Longitude;
            }
            if (dataRegion.Radius != null)
            {
                dataSvcRegion.Radius = (long)dataRegion.Radius;
            }
            return dataSvcRegion;
        }

        public static WeatherPreference ToDataSvcModel(Data.Models.WeatherPreference dataWeather)
        {
            var dataSvcWeather = new WeatherPreference()
            {
                pushHours = dataWeather.PushHours,
                pushMinutes = dataWeather.PushMinutes,
                alwaysTemp = dataWeather.AlwaysTemp,
                temp = new[] { dataWeather.TempMin, dataWeather.TempMax },
                alwaysRain = dataWeather.AlwaysRain,
                rain = new[] { dataWeather.RainMin, dataWeather.RainMax },
                alwaysSnow = dataWeather.AlwaysSnow,
                snow = new[] { dataWeather.SnowMin, dataWeather.SnowMax },
                alwaysCloud = dataWeather.AlwaysCloud,
                cloud = new[] { dataWeather.CloudMin, dataWeather.CloudMax },
                alwaysWind = dataWeather.AlwaysWind,
                wind = new[] { dataWeather.WindMin, dataWeather.WindMax },
                alwaysHumidity = dataWeather.AlwaysHumidity,
                humidity = new[] { dataWeather.HumidityMin, dataWeather.HumidityMax }
            };
            return dataSvcWeather;
        }
    }
}
