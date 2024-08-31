import { Injectable } from '@angular/core';
import { WorkEntry } from './work-entry';

@Injectable({
  providedIn: 'root',
})
export class WorkService {
  url = 'http://localhost:3000/work';

  constructor() {}

  async addHours(newWorkEntry: any): Promise<WorkEntry[]> {
    return fetch(this.url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(newWorkEntry),
    })
      .then((response) => response.json())
      .then((data) => {
        console.log('Success:', data);
        return data;
      })
      .catch((error) => {
        console.error('Error:', error);
      });
  }

  async getHours(): Promise<WorkEntry[]> {
    const work_data = await fetch(this.url);

    return (await work_data.json()) ?? [];
  }
}
