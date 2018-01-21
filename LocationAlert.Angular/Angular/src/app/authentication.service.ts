import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Account } from './_models/account';
import { Router } from '@angular/router';

@Injectable()
export class AuthenticationService {


  constructor(private http: HttpClient, private router: Router) {
    var client = JSON.parse(sessionStorage.getItem('AccountKey'));
  }

  // login(username: string, password: string): Observable<boolean> {
  //   return this.http.post('/api/authenticate', JSON.stringify({ username: username, password: password }))
  //     .map((response: Response) => {
  //       // login successful if there's a jwt token in the response
  //       let token = response.json() && response.json().token;
  //       if (token) {
  //         // set token property
  //         this.token = token;

  //         // store username and jwt token in local storage to keep user logged in between page refreshes
  //         localStorage.setItem('currentUser', JSON.stringify({ username: username, token: token }));

  //         // return true to indicate successful login
  //         return true;
  //       } else {
  //         // return false to indicate failed login
  //         return false;
  //       }
  //     });
  // }
  login(client: Account, pass = (data: Object) => { }, fail = err => { }) {
    // Http call
    this.http.get<Account>('http://ec2-34-201-125-246.compute-1.amazonaws.com/LocationAlertLibrary/api/account/login').subscribe(
      data => {
        client = <Account>data;
        pass(data);
        this.router.navigate(['preferences']);
      },
      fail => {
        this.router.navigate(['loginfail']);
      })

    sessionStorage.setItem("AccountKey", JSON.stringify(client))
  }

  logout(pass = (data: Object) => { }, fail = err => { }): void {
    var client = JSON.parse(sessionStorage.getItem('AccountKey'));
    this.http.post('http://ec2-34-201-125-246.compute-1.amazonaws.com/LocationAlertLibrary/api/account/logout', client).subscribe(pass, fail);
  }

  register(client: Account, pass = (data: Object) => { }, fail = err => { }): void {
    this.http.post('http://ec2-34-201-125-246.compute-1.amazonaws.com/LocationAlertLibrary/api/account/register', client).subscribe(pass, fail);
  }

  update(client: Account, pass = (data: Object) => { }, fail = err => { }): void {
    this.http.post('http://ec2-34-201-125-246.compute-1.amazonaws.com/LocationAlertLibrary/api/account/update', client).subscribe(
      data => {
        console.log(data);
        pass(data);
      },
      fail);
  }
}
