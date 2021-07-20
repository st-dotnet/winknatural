import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { SessionService } from './session.service';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class AccountService {
  private readonly authenticationEndpoint = 'authentication/';

  constructor(
    private http: HttpClient,
    private sessionService: SessionService
  ) { }

  register(model: any) {
    return this.http.post<any>(`${environment.apiUrl}${this.authenticationEndpoint}createCustomer`, model)
      .pipe(map(res => {
        if (res.token) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          this.sessionService.setSessionObject('user', res.user);
          this.sessionService.userSession(res.user);
        }
        return res;
      }));
  }

  login() {
    const data = { ...arguments };
    return this.http.post<any>(`${environment.apiUrl}${this.authenticationEndpoint}signInCustomer`, { ...arguments })
      .pipe(map(res => {
        if (res.token) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          this.sessionService.setSessionObject('user', res.user);
          this.sessionService.userSession(res.user);
        }
        return res;
      }));
  }

}
