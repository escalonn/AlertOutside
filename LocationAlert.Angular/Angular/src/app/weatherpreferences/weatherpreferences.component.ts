import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
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
    // Send our data!
    console.log(this.weatherPref);
  }

  onBack() {
    this.router.navigate(['preferences']);
  }

  onChange() {
  }

  ngOnInit() {
  }

}
