import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TrackHoursComponent } from './track-hours/track-hours.component';
import { UsersComponent } from './users/users.component';
import { HoursComponent } from './hours/hours.component';

export const routes: Routes = [
    { path: "", component: HomeComponent, title: "Home Page" },
    { path: "track_hours", component: TrackHoursComponent, title: "Track Hours" },
    { path: "all_users", component: UsersComponent, title: "All Users" },
    { path: "all_hours", component: HoursComponent, title: "All Hours" }
];
