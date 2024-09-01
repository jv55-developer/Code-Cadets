import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-view-hours',
  templateUrl: './view-hours.component.html',
  styleUrls: ['./view-hours.component.css']
})
export class ViewHoursComponent implements OnInit {
  hours: any[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<any[]>('http://localhost:3000/api/hours').subscribe(data => {
      this.hours = data;
    });
  }
}
