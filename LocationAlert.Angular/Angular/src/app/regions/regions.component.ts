import { Component, OnInit } from '@angular/core';
import { GoogleMapsAPIWrapper } from '@agm/core';
import { HttpClient } from '@angular/common/http';
import { Region } from '../_models/region';
import { Account } from '../_models/account';
import { AuthenticationService } from '../authentication.service';



@Component({
  selector: 'app-regions',
  templateUrl: './regions.component.html',
  styleUrls: ['./regions.component.css']
})
export class RegionsComponent implements OnInit {

  maxReg = 3;

  client: Account = JSON.parse(sessionStorage.getItem("AccountKey"));

  lat: number = 51.678418;
  lng: number = 7.809007;

  constructor(private http: HttpClient, private authentication: AuthenticationService) {

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
    // Send our data!
    sessionStorage.setItem("AccountKey",JSON.stringify(this.client));
    this.authentication.update(this.client);
  }

  ngOnInit() {
  }

}
