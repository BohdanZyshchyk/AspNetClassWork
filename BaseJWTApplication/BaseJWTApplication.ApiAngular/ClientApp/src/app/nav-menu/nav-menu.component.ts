import { Component, OnInit } from '@angular/core';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  isLogin: boolean = false;
  constructor(private authService: AuthService) { }

  ngOnInit() {
    var token = localStorage.getItem('token');
    if (token != null) {
      this.isLogin = true;
    }
    else {
      this.isLogin = false;
    }
    this.authService.statusLogin.subscribe(
      (data) => {
        this.isLogin = data;
      }
    )
  }

  Logout() {
    this.authService.Logout();
  }


  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
