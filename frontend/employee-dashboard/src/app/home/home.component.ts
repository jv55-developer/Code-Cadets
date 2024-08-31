import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  template: `
    <p>Home</p>
  `,
  styleUrl: './home.component.css',
})
export class HomeComponent {

}
