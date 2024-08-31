import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-chart',
  standalone: true,
  imports: [CommonModule],
  template: `
    <p>
      chart works!
    </p>
  `,
  styleUrl: './chart.component.css'
})
export class ChartComponent {

}
