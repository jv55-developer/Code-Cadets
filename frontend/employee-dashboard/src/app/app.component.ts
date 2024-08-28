import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  // templateUrl: './app.component.html',
  template: `<main>
    <header>
      <ul>
        <li>Home</li>
        <li>Track Hours</li>
        <li>All Users</li>
      </ul>
    </header>
  </main>`,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'employee-dashboard';
}
