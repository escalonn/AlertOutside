import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { Account } from '../_models/account';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  client: Account = new Account();

  constructor(private authentication: AuthenticationService, private router: Router) { }

  loginButton(){
    sessionStorage.setItem("AccountKey",JSON.stringify(this.client));
    this.authentication.login(this.client);
    console.log("login");
  }

  registerButton(){
    sessionStorage.setItem("AccountKey",JSON.stringify(this.client));
    this.authentication.register(this.client, (data) => {
      this.router.navigate(['registersuccess']);
    });
    console.log("register");
  }

  ngOnInit() {}

}
