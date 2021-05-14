import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ErrorComponent } from './components/error/error.component';
import { HomeComponent } from './components/home/home.component';
import { AddressComponent } from './components/registration/address/address.component';
import { LoginInfoComponent } from './components/registration/login-info/login-info.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { AddressGuard } from './guards/address.guard';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: '/registration/login-info', pathMatch: 'full' },
  {
    path: 'registration',
    component: RegistrationComponent,
    children: [
      { path: 'login-info', component: LoginInfoComponent },
      {
        path: 'address',
        component: AddressComponent,
        canActivate: [AddressGuard],
      },
    ],
  },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'error', component: ErrorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
