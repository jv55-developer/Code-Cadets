import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiURL = 'http://localhost:3000/api'; // Backend API URL
  private loggedIn = new BehaviorSubject<boolean>(false);
  sign: any;

  constructor(private http: HttpClient, private router: Router) { }

  login(user: { email: string, password: string }) {
    return this.http.post<any>(`${this.apiURL}/login`, user)
      .subscribe(res => {
        localStorage.setItem('token', res.token);
        this.loggedIn.next(true);
        this.router.navigate(['/allocations']);
      });
  }

  signUp(user: { email: string, password: string }) {
    return this.http.post<any>(`${this.apiURL}/signup`, user)
      .subscribe(res => {
        this.router.navigate(['/login']);
      });
  }

  logout() {
    localStorage.removeItem('token');
    this.loggedIn.next(false);
    this.router.navigate(['/login']);
  }

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }
}
