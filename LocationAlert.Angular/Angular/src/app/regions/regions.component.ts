import { Component, OnInit } from '@angular/core';
import { GoogleMapsAPIWrapper } from '@agm/core';
import { Account } from '../_models/index';
import { HttpClient } from '@angular/common/http';
import { Region } from '../_models/region';



@Component({
  selector: 'app-regions',
  templateUrl: './regions.component.html',
  styleUrls: ['./regions.component.css']
})
export class RegionsComponent implements OnInit {

  maxReg = 3;

  //client: Account = JSON.parse(sessionStorage.getItem("AccountKey"));
  client: Account = new Account();


  lat: number = 51.678418;
  lng: number = 7.809007;

  constructor(private http: HttpClient) {

   }

   mapDblClick($event: any) {
     if (this.client.regions.length < this.maxReg)
     {
      var circle : Region = {id: this.client.regions.length, latitude: $event.coords.lat, longitude: $event.coords.lng, radius:50000, color: '#fc0000', fillOpacity: 0.7}
      this.client.regions.push(circle);
     }
    };

    radiusChange($event: any, id: number) {
      this.client.regions[id].radius = $event;
      console.log(this.client.regions[id].radius);
    }

    centerChange($event: any, id: number) {
      this.client.regions[id].latitude = $event.lat;
      this.client.regions[id].longitude = $event.lng;
    }


  deleteRegion(){
    console.log("delete");
    this.client.regions.splice(this.client.regions.length-1);
  }

  saveRegion(){
    sessionStorage.setItem("AccountKey",JSON.stringify(this.client));
    this.http.post("",JSON.stringify(this.client));
    console.log(this.client.regions);
  }

  ngOnInit() {
  }

}
