import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { NouisliderComponent } from 'ng2-nouislider';
import { Account } from '../_models/account';

@Component({
  selector: 'app-weatherpreferences',
  templateUrl: './weatherpreferences.component.html',
  styleUrls: ['./weatherpreferences.component.css']
})
export class WeatherpreferencesComponent implements OnInit {

  //client: Account = JSON.parse(sessionStorage.getItem("AccountKey"));
  client: Account = new Account();

  constructor(private router: Router) { }

  onSave() {
    // Send our data!
    console.log(this.client.weatherPref);
  }

  onBack() {
    this.router.navigate(['preferences']);
  }

  onChange() {
  }

  ngOnInit() {
  }

}
