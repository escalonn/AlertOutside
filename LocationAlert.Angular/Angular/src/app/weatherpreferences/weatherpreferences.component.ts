import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { NouisliderModule, NouisliderComponent } from 'ng2-nouislider';
import { WeatherPreference } from '../_models/index';

@Component({
  selector: 'app-weatherpreferences',
  templateUrl: './weatherpreferences.component.html',
  styleUrls: ['./weatherpreferences.component.css']
})
export class WeatherpreferencesComponent implements OnInit {
  weatherPref: WeatherPreference = new WeatherPreference();

  constructor(private router: Router) { }

  onSave() {
    // Send ouur data!
  }

  onBack() {
    this.router.navigate(['preferences']);
  }

  onChange(value: any) {
    console.log(value);
    console.log(this.weatherPref);
    console.log(this.weatherPref.temp);
  }

  ngOnInit() {
  }

}
