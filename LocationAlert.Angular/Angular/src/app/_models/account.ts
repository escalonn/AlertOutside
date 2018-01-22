import { Region } from "./region";
import { WeatherPreference } from "./weatherpreference";

export class Account {
  email: string = "";
  regions: Region[] = [];
  weatherPref: WeatherPreference = new WeatherPreference();
}
