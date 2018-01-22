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

  ngOnInit() { }

}
