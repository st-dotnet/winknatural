import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './_helpers/CommonModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private api ='https://mailthis.to/alias'

  constructor(private http: HttpClient) {    
  }

  contactUser(data: User) {    
    return this.http.post<User>(`${environment.serverApiBase}/save`, data);
}
}




