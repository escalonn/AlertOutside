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
       var circle = {lat: $event.coords.lat, lng: $event.coords.lng, radius:50000, color: '#fc0000', fillOpacity: 0.7}
       this.regions.push(circle);
     }
      
  };

  addRegions(latitude, longitude){
    var circle = [
      {lat: latitude, lng: longitude, radius: 50000 }
    ]
  }

  deleteRegion(){
    console.log("delete");
    this.regions.splice(this.regions.length-1);
  }


  ngOnInit() {
   
  
  }

}
