import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-preferences',
  templateUrl: './preferences.component.html',
  styleUrls: ['./preferences.component.css']
})
export class PreferencesComponent implements OnInit {

  constructor(private router: Router) { }

  goWeather(){
    this.router.navigate(['weatherpreferences']);
  }

  goRegions(){
    this.router.navigate(['regions']);
  }

  ngOnInit() {
  }

}
