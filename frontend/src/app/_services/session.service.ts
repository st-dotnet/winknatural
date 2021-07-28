import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  private userSubject: BehaviorSubject<any>;
  public user: Observable<any>;

  constructor(
    private router: Router,
    private spinner: NgxSpinnerService,) {
    this.userSubject = new BehaviorSubject<any>(JSON.parse(localStorage.getItem('user')));
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): any {
    return this.userSubject.value;
  }

  userSession(value: any) {
    this.userSubject.next(value);
  }

  getSessionObject(key: any) {
    return JSON.parse(localStorage.getItem(key));
  }

  getSessionItem(key: any) {
    return localStorage.getItem(key);
  }

  setSessionObject(key: any, value: any) {
    localStorage.setItem(key, JSON.stringify(value));
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

  logout() {
    this.spinner.show();
    setTimeout(() => {
      // remove user from local storage and set current user to null
      this.userSubject.next(null);
      this.clearSession();
      this.router.navigate(['/sign-in']);
      this.spinner.hide();
    }, 1000);
  }

  scrollToTop(){
    // window.scrollTo(0, 0);
    window.scroll({
      top: 0,
      left: 0,
      behavior: 'smooth'
     });
  }

}
