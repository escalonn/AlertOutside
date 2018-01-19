import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { NouisliderModule, NouisliderComponent } from 'ng2-nouislider';




@Component({
  selector: 'app-weatherpreferences',
  templateUrl: './weatherpreferences.component.html',
  styleUrls: ['./weatherpreferences.component.css']
})
export class WeatherpreferencesComponent implements OnInit {
  someRange: number[] = [0,1];
  constructor(private router: Router) { }

  onSave(){
    // Send ouur data!
  }

  onBack(){
    this.router.navigate(['preferences']);
  }

  onChange(value:any){

  }

  ngOnInit() {
  }

}
