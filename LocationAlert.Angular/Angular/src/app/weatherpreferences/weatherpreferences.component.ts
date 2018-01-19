import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-weatherpreferences',
  templateUrl: './weatherpreferences.component.html',
  styleUrls: ['./weatherpreferences.component.css']
})
export class WeatherpreferencesComponent implements OnInit {

  constructor(private router: Router) { }

  onSave(){
    // Send ouur data!
  }

  onBack(){
    this.router.navigate(['preferences']);
  }

  ngOnInit() {
  }

}
