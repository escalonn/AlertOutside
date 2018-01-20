import { Component, OnInit } from '@angular/core';
import { Account } from '../_models/index';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  client = new Account();
  email : string;

  constructor(private authentication: AuthenticationService) { }

  loginButton(){
    console.log(this.client.email);
    this.authentication.login(this.client);
  }

  ngOnInit() {
  }

}
