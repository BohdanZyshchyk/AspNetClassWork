import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AdminAreaComponent } from './admin-area/admin-area.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { ClientAreaComponent } from './client-area/client-area.component';
import { AppRoutingModule } from './app-routing.module';
import { NgxSpinnerModule, NgxSpinnerService } from "ngx-spinner";
import { NotifierModule, NotifierOptions } from 'angular-notifier';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { DemoNgZorroAntdModule } from './ng-zorro.module';

const configNotifier:NotifierOptions = {
  position:{
    horizontal: {
      position: 'right'
    },
    vertical:{
      position:'top'
    }
  }
};

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AdminAreaComponent,
    SignInComponent,
    SignUpComponent,
    ClientAreaComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    NotifierModule.withConfig(configNotifier),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    NgxSpinnerModule,
    // DemoNgZorroAntdModule    
  ],
  providers: [
    NgxSpinnerService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
