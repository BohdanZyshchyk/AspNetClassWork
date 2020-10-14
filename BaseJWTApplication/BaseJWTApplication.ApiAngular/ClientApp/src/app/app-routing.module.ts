import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { AdminAreaComponent } from './admin-area/admin-area.component';
import { ClientAreaComponent } from './client-area/client-area.component';
import { AdminGuard } from './guards/admin.guard';
import { LoggedInGuard } from './guards/loggedIn.guard copy';
import { NotLoginGuard } from './guards/notLogin.guard';
import { HomeComponent } from './home/home.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';

const routes: Routes = [
 {path:"", pathMatch:"full", component:HomeComponent},
 {path:"sign-in", pathMatch:"full",  canActivate:[NotLoginGuard],component:SignInComponent},
 {path:"sign-up", pathMatch:"full",  canActivate:[NotLoginGuard],component:SignUpComponent},
 {path:"admin-panel", pathMatch:"full", canActivate:[AdminGuard], component:AdminAreaComponent},
 {path:"client-panel", pathMatch:"full",  canActivate:[LoggedInGuard], component:ClientAreaComponent},
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }