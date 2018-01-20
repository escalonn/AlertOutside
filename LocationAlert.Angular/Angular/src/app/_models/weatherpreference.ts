export class WeatherPreference {
  pushHours: number = 1;
  pushMinutes: number = 0;
  alwaysTemp: boolean = false;
  temp: number[] = [0, 100];
  alwaysRain: boolean = false;
  rain: number[] = [0, 10];
  alwaysSnow: boolean = false;
  snow: number[] = [0, 10];
  alwaysCloud: boolean = false;
  cloud: number[] = [0, 10];
  alwaysWind: boolean = false;
  wind: number[] = [0, 10];
  alwaysHumidity: boolean = false;
  humidity: number[] = [0, 10];
}
