import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Account } from './_models/account';

@Injectable()
export class AuthenticationService {


  constructor(private http: HttpClient) {
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
  login(client: Account){
    // Http call
    this.http.get<Account>('http://localhost:61340/api/values').subscribe(data => {
        client = <Account>data;
    })

    sessionStorage.setItem("AccountKey",JSON.stringify(client))
  }

  logout(): void {
    sessionStorage.removeItem("AccountKey");
  }

  register(client: Account): void{
    this.http.post('http://localhost:61340/api/account/register', client).subscribe(data => {
    console.log(data);
  });
  }

  update(client: Account): void {
      this.http.post('http://localhost:61340/api/account/update', client).subscribe(data => {
      console.log(data);
  });
  }
}
