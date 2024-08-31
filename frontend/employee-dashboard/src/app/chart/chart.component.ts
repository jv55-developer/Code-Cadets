import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Chart, registerables } from 'chart.js';
import { WorkEntry } from '../work-entry';
import { WorkService } from '../work.service';

Chart.register(...registerables);
@Component({
  selector: 'app-chart',
  standalone: true,
  imports: [CommonModule],
  template: `<canvas id="MyChart"></canvas>`,
  styleUrl: './chart.component.css',
})
export class ChartComponent implements OnInit {
  chart: any;

  constructor(private workService: WorkService) {}

  async ngOnInit(): Promise<void> {
    let workEntries: WorkEntry[] = await this.workService.getHours();

    workEntries = workEntries.sort((a, b) => new Date(a.date).getTime() - new Date(b.date).getTime());

    // Process data to be used in the chart
    const labels = workEntries.map((entry) => entry.date);
    const data = workEntries.map((entry) => entry.time);

    // Configure the chart
    this.chart = new Chart('MyChart', {
      type: 'bar',
      data: {
        labels: labels,
        datasets: [
          {
            label: 'Work Hours',
            data: data,
            backgroundColor: 'rgba(0, 86, 179, 0.2)',
            borderColor: 'rgba(0, 86, 179, 1)',
            borderWidth: 1,
          },
        ],
      },
      options: {
        maintainAspectRatio: false,
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });
  }
}
