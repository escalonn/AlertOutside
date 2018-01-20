import { Region } from "./region";
import { WeatherPreference } from "./weatherpreference";

export class Account {
  email: string = "Enter Email Address";
  regions: Region[] = [];
  weatherPref: WeatherPreference = new WeatherPreference();
}
