import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkEntry } from '../work-entry';
import { WorkService } from '../work.service';

@Component({
  selector: 'app-hours',
  standalone: true,
  imports: [CommonModule],
  template: `
    <section>
      <form>
        <input type="text" placeholder="Filter by activity" #filter />
        <button type="button" (click)="filterResults(filter.value)">
          Search
        </button>
      </form>
    </section>
    <section>
      <table>
        <thead>
          <tr>
            <th>User ID</th>
            <th>Activity</th>
            <th>Date</th>
            <th>Hours</th>
          </tr>
        </thead>
        <tbody>
          <tr *ngFor="let workEntry of filteredWorkEntry">
            <td>{{ workEntry.user_id }}</td>
            <td>{{ workEntry.activity }}</td>
            <td>{{ workEntry.date }}</td>
            <td>{{ workEntry.time }}</td>
          </tr>
        </tbody>
      </table>
    </section>
  `,
  styleUrl: './hours.component.css',
})
export class HoursComponent {
  workEntryList: WorkEntry[] = [];
  workService: WorkService = inject(WorkService);
  filteredWorkEntry: WorkEntry[] = [];

  constructor() {
    this.workService.getHours().then((workEntryList: WorkEntry[]) => {
      this.workEntryList = workEntryList;
      this.filteredWorkEntry = workEntryList;
    });
  }

  filterResults(text: string) {
    if (!text) {
      this.filteredWorkEntry = this.workEntryList;
    } else {
      this.filteredWorkEntry = this.workEntryList.filter((workEntry) =>
        workEntry?.activity.toLowerCase().includes(text.toLowerCase())
      );
    }
  }
}
