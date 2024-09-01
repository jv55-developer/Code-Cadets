import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChartComponent } from "../chart/chart.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, ChartComponent],
  template: `
    <!-- <app-chart></app-chart> -->
  <p>Chart Goes here</p>
  `,
  styleUrl: './home.component.css',
})
export class HomeComponent {

}
