import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from '../login/login.component';
import { SignupComponent } from '../signup/signup.component';
import { ViewHoursComponent } from '../view-hours/view-hours.component';
import { EditProfileComponent } from '../edit-profile/edit-profile.component'; // Import the EditProfileComponen


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'sign-up', component: SignupComponent },
  { path: 'view-hours', component: ViewHoursComponent },
  { path: 'edit-profile', component: EditProfileComponent }, // Add the route for edit-profile
  { path: '', redirectTo: '/login', pathMatch: 'full' },

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
