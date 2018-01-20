import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { Account } from '../_models/account';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  client: Account = new Account();

  constructor(private authentication: AuthenticationService) { }

  loginButton(){
    console.log(this.client.email);
    sessionStorage.setItem("AccountKey",JSON.stringify(this.client));
    this.authentication.login(this.client);
  }

  ngOnInit() {
  }

}
