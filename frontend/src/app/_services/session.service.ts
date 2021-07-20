import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  private userSubject: BehaviorSubject<any>;
  public user: Observable<any>;

  constructor() {
    this.userSubject = new BehaviorSubject<any>(JSON.parse(localStorage.getItem('user')));
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): any {
    return this.userSubject.value;
  }

  public set userSession(value: any) {
    this.userSubject.next(value);
  }

  getSessionObject(key: any) {
    return JSON.parse(localStorage.getItem(key));
  }

  getSessionItem(key: any) {
    return localStorage.getItem(key);
  }

  setSessionObject(key: any, value: any) {
    JSON.stringify(localStorage.setItem(key, value));
  }

  setSessionItem(key: any, value: any) {
    localStorage.setItem(key, value);
  }

  removeSessionItem(key: any) {
    localStorage.removeItem(key);
  }

  clearSession() {
    localStorage.clear();
  }

}
