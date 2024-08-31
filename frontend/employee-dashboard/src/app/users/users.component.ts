import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserEntry } from '../user-entry';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [CommonModule],
  template: `
    <section>
      <form>
        <input type="text" placeholder="Filter by name" #filter />
        <button type="button" (click)="filterResults(filter.value)">
          Search
        </button>
      </form>
    </section>
    <section>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Surname</th>
            <th>Email</th>
            <th>Cell</th>
            <th>Role</th>
            <th>Birthday</th>
          </tr>
        </thead>
        <tbody>
          <tr *ngFor="let userEntry of filteredUserEntry">
            <td>{{ userEntry.name }}</td>
            <td>{{ userEntry.surname }}</td>
            <td>{{ userEntry.email }}</td>
            <td>{{ userEntry.cell }}</td>
            <td>{{ userEntry.role }}</td>
            <td>{{ userEntry.birthday }}</td>
          </tr>
        </tbody>
      </table>
    </section>
  `,
  styleUrls: ['./users.component.css'],
})
export class UsersComponent {
  userEntryList: UserEntry[] = [];
  userService: UsersService = inject(UsersService);
  filteredUserEntry: UserEntry[] = [];

  constructor() {
    this.userService.getAllUsers().then((userEntryList: UserEntry[]) => {
      this.userEntryList = userEntryList;
      this.filteredUserEntry = userEntryList;
    });
  }

  filterResults(text: string) {
    if (!text) {
      this.filteredUserEntry = this.userEntryList;
    } else {
      this.filteredUserEntry = this.userEntryList.filter((userEntry) =>
        userEntry?.name.toLowerCase().includes(text.toLowerCase())
      );
    }
  }
}
