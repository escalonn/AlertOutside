import { Component, OnInit } from '@angular/core';
import { GoogleMapsAPIWrapper } from '@agm/core';



@Component({
  selector: 'app-regions',
  templateUrl: './regions.component.html',
  styleUrls: ['./regions.component.css']
})
export class RegionsComponent implements OnInit {

  maxReg = 3;

  regions = [];

  lat: number = 51.678418;
  lng: number = 7.809007;

  constructor() {

   }

   mapDblClick($event: any) {
     if (this.regions.length < this.maxReg)
     {
       var circle = {lat: $event.coords.lat, lng: $event.coords.lng, radius:50000, color: '#000000'}
       this.regions.push(circle);
     }
      
  };

  addRegions(latitude, longitude){
    var circle = [
      {lat: latitude, lng: longitude, radius: 50000 }
    ]
  }



  ngOnInit() {
   
  
  }

}
