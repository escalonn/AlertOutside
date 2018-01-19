import { Component, OnInit } from '@angular/core';
import { GoogleMapsAPIWrapper } from '@agm/core';



@Component({
  selector: 'app-regions',
  templateUrl: './regions.component.html',
  styleUrls: ['./regions.component.css']
})
export class RegionsComponent implements OnInit {

  regions = [
    {lat: 51.678418, lng:7.809007, radius:10000, color: '#000000'},
    {lat: 51.678418, lng:7.809007, radius:10000, color: '#000000'},
    {lat: 51.678418, lng:7.809007, radius:10000, color: '#000000'}
  ];

  lat: number = 51.678418;
  lng: number = 7.809007;

  constructor() {

   }

   mapDblClick($event: MouseEvent) {
      console.log("hello circle");
  };

  addRegions(latitude, longitude){
    var circle = [
      {lat: latitude, lng: longitude, radius: 50000 }
    ]
  }



  ngOnInit() {
   
  
  }

}
