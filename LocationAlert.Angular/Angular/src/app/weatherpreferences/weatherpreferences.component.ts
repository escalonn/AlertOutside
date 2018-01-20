import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { NouisliderComponent } from 'ng2-nouislider';
import { Account } from '../_models/account';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-weatherpreferences',
  templateUrl: './weatherpreferences.component.html',
  styleUrls: ['./weatherpreferences.component.css']
})
export class WeatherpreferencesComponent implements OnInit {

  client: Account = JSON.parse(sessionStorage.getItem("AccountKey"));

  constructor(private router: Router, private authentication: AuthenticationService) { }

  onSave() {
    // Send our data!
    sessionStorage.setItem("AccountKey",JSON.stringify(this.client));
    this.authentication.update(this.client);
  }

  onBack() {
    this.router.navigate(['preferences']);
  }

  ngOnInit() {
  }

}
