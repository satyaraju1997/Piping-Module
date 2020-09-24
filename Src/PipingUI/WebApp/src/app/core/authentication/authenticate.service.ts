import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { distinctUntilChanged, map } from 'rxjs/operators';
import { of as observableOf } from 'rxjs';
import { environment } from '../../../environments/environment';
import { User } from 'src/app/shared/models/user/user.model';
import { HttpClient } from '@angular/common/http';

const credentialsKey = 'currentUser';

@Injectable({
  providedIn: 'root'
})
export class AuthenticateService {

  isUserLoggedIn = false;
  private currentUserSubject = new BehaviorSubject<User>(new User());
  public currentUser = this.currentUserSubject.asObservable().pipe(distinctUntilChanged());
  private isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  constructor(private http: HttpClient) { }

  isUserAuthenticated(): Observable<Boolean> {

    if (sessionStorage.getItem(credentialsKey)) {
      const savedCredentials = sessionStorage.getItem(credentialsKey);
      this.setUser(JSON.parse(savedCredentials) as User);
      return observableOf(true);
    } else {
      return observableOf(false);
    }

  }

  login(credentials: JSON): Observable<User> {
    return this.http.post(`${environment.loginService}`, credentials, { withCredentials: false })
      .pipe(
        map((response: any) => {
          const storage = sessionStorage;
          const beforeencryption = response;
          storage.setItem(credentialsKey, JSON.stringify(response));
          this.setUser(beforeencryption as User);
          return beforeencryption;
        }));
  }

  setUser(user: User) {
    this.currentUserSubject.next(user);
    this.isAuthenticatedSubject.next(true);
    this.isUserLoggedIn = true;
  }

  isLoggedIn(): boolean {
    return this.isUserLoggedIn;
  }

  get getUserLoggedIn() {
    return this.isAuthenticated;
  }

  get getCurrentUser() {
    return this.currentUser;
  }

  isLogin() {
    if (localStorage.getItem(credentialsKey) || sessionStorage.getItem(credentialsKey)) {
      return true;
    }
    return false;
  }

  currentUserInfo(): Observable<User> {
    const savedCredentials = JSON.parse(sessionStorage.getItem(credentialsKey));
    return observableOf(savedCredentials);
  }
}
