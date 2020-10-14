import { HttpClient } from '@angular/common/http';
import { Injectable, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/api.response';
import { SignInModel } from '../Models/sign-in.model';
import { SignUpModel } from '../Models/sign-up.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient,
    private router: Router) { }
  baseUrl = "api/Acount"
  statusLogin = new EventEmitter<boolean>();

  SignUp(model: SignUpModel): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(this.baseUrl + '/register', model);
  }

  SignIn(model: SignInModel): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(this.baseUrl + '/login', model);
  }

  Logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    this.statusLogin.emit(false)
    this.router.navigate(['/']);
  }
  isLoggedIn(){
    var token = localStorage.getItem('token');
    return token != null;
  }
  isAdmin(){
    var role = localStorage.getItem('role');
    return role === 'Admin';
  }
}
