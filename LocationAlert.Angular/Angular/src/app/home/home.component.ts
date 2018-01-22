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

  loginButton() {
    this.authentication.login(
      this.client,
      data => {
        this.client = <Account>data;
        this.router.navigate(['preferences']);
      },
      error => {
        this.router.navigate(['loginfail']);
      }
    );
  }

  registerButton() {
    var regexp = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
    if (regexp.test(this.client.email)) {
      this.authentication.register(
        this.client,
        (data) => {
          this.router.navigate(['registersuccess']);
        },
        (error) => {
          this.router.navigate(['registerfail']);
        }
      );
    }
    else {
      console.log("email invalid");
      this.router.navigate(['registerfail']);
    }
  }

  ngOnInit() { }

}
