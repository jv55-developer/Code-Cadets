import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-track-hours',
  standalone: true,
  imports: [ReactiveFormsModule],
  template: `
    <article>
      <section>
        <h2>Log Hours</h2>
        <form [formGroup]="trackForm">
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

  
}
