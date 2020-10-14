import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { NgxSpinnerService } from 'ngx-spinner';
import { SignInModel } from '../Models/sign-in.model';
import { AuthService } from '../Services/auth.service';
import jwt_decode from "jwt-decode";

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  constructor(private spinner: NgxSpinnerService,
    private notifier: NotifierService,
    private authService: AuthService,
    private router: Router) { }
  model = new SignInModel();
  ngOnInit() {
  }
  login() {
    this.spinner.show();
    this.notifier.hideAll();

    if(!this.model.isValid()){
      this.notifier.notify('error', 'Please, enter all fields');
      this.spinner.hide();
    }
    else if (!this.model.isEmail()){
      this.notifier.notify('error', 'Please, enter email')
      this.spinner.hide();
    }
    else{
      this.authService.SignIn(this.model).subscribe(
        data =>{
          if (data.status === 200) {
            this.authService.statusLogin.emit(true);
            window.localStorage.setItem('token',data.token);
            var decoded = jwt_decode(data.token);
            console.log(decoded);
            if(decoded.roles === "Admin"){
              this.router.navigate(['/admin-panel']);
            }
            else if (decoded.roles === "User")
            {
              this.router.navigate(['/client-panel']);
            }
            localStorage.setItem("role", decoded.roles);
            this.spinner.hide();
            // console.log(data);
          } else {
            for(var i = 0; i < data.errors.length; i++){
              this.notifier.notify('error', data.errors[i]);
            }
            setTimeout(() => {
              this.spinner.hide()
            }, 1000);
          }
        }
      )
    }

  }

}
