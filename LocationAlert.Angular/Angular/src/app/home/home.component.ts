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
    
  }

  registerButton(){
    var regexp = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
    if (regexp.test(this.client.email))
    {
    sessionStorage.setItem("AccountKey",JSON.stringify(this.client));
    this.authentication.register(this.client,
      //success
      (data) => 
        {this.router.navigate(['registersuccess']);},
      //failure
      (data) => 
        {this.router.navigate(['registerfail']);});
    }
    else
    {
      console.log("email invalid");
       this.router.navigate(['registerfail']);
    }
  }

  ngOnInit() {}

}
