import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(private http: HttpClient) { }

    login(userData: any): Observable<any> {
        return this.http.get(`http://localhost:3000/admins?email=${userData.email}&password=${userData.password}`);
    }
}
