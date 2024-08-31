import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule],
  template: `<main>
    <header>
      <ul>
        <li><a [routerLink]="['/']">Home</a></li>
        <li><a [routerLink]="['/track_hours']">Track Hours</a></li>
        <li><a [routerLink]="['/all_users']">All Users</a></li>
      </ul>
    </header>
    <section>
      <router-outlet></router-outlet>
    </section>
  </main>`,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Employee Dashboard';
}
