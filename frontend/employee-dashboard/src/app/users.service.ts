import { Injectable } from '@angular/core';
import { UserEntry } from './user-entry';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  url = "http://localhost:3000/users";

  constructor() {}

  async getAllUsers(): Promise<UserEntry[]> {
    const user_data = await fetch(this.url);

    return await user_data.json() ?? [];
  }
}
