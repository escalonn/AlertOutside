export class WeatherPreference {
  pushHours: number = 1;
  pushMinutes: number = 0;
  alwaysTemp: boolean = false;
  temp: number[] = [-10, 110];
  alwaysRain: boolean = false;
  rain: number[] = [0, 36];
  alwaysSnow: boolean = false;
  snow: number[] = [0, 36];
  alwaysCloud: boolean = false;
  cloud: number[] = [0, 100];
  alwaysWind: boolean = false;
  wind: number[] = [0, 25];
  alwaysHumidity: boolean = false;
  humidity: number[] = [0, 10];
}
