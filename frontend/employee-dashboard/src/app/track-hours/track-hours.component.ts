import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { WorkService } from '../work.service';

@Component({
  selector: 'app-track-hours',
  standalone: true,
  imports: [ReactiveFormsModule],
  template: `
    <article>
      <section>
        <h2>Log Hours</h2>
        <form [formGroup]="trackForm" (ngSubmit)="onSubmit()">
          <label for="activity">Activity</label>
          <input id="activity" type="text" formControlName="activity" />

          <label for="date">Date</label>
          <input id="date" type="date" formControlName="date" />

          <label for="time">Time (in hours)</label>
          <input id="time" type="number" formControlName="time" />

          <button type="submit">Submit</button>
        </form>
      </section>
    </article>
  `,
  styleUrl: './track-hours.component.css',
})

export class TrackHoursComponent {
  trackForm = new FormGroup({
    activity: new FormControl(''),
    date: new FormControl(''),
    time: new FormControl(''),
  });

  constructor(private workService: WorkService) {}

  async onSubmit() {
    const newWorkEntry = {
      id: await this.generateId(),
      user_id: "1",
      activity: this.trackForm.value.activity,
      date: this.trackForm.value.date,
      time: this.trackForm.value.time,
      date_entered: new Date().toISOString()
    }

    this.workService.addHours(newWorkEntry).then(data => {
      this.trackForm.reset();
    });
  }

  async generateId(): Promise<string> {
    const workEntries = await this.workService.getHours();
    const currentMaxId = Math.max(...workEntries.map(entry => parseInt(entry.id.toString(), 10)), 0);
    return (currentMaxId + 1).toString();
  }
}
