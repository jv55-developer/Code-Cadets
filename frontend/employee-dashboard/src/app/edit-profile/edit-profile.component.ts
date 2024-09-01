import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {
  profileForm: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient) { 
    this.profileForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    // Fetch existing profile data
    this.http.get<any>('http://localhost:3000/api/profile').subscribe(data => {
      this.profileForm.patchValue(data);
    });
  }

  onSubmit(): void {
    if (this.profileForm.valid) {
      this.http.put('http://localhost:3000/api/profile', this.profileForm.value).subscribe(response => {
        console.log('Profile updated', response);
      });
    }
  }
}
