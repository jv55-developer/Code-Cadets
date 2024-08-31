// authentication.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from './user.model';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
private currentUserSubject = new BehaviorSubject<User | null>(null);
public currentUser: Observable<User | null>;

constructor(private http: HttpClient) {
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public login(user: User): Observable<any> {
    return this.http.post('/api/auth/login', user);
  }

  public register(user: User): Observable<any> {
    return this.http.post('/api/auth/register', user);
  }

  public logout() {
    // Implement logout logic (e.g., clear local storage)
    this.currentUserSubject.next(null);
  }
}
