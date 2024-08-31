import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SignupService } from './signup.service'; // Replace with your service

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  signupForm: FormGroup;

  constructor(private fb: FormBuilder, private signupService: SignupService) {}

  ngOnInit() {
    this.signupForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.signupForm.valid) {
      const signupData = this.signupForm.value;
      this.signupService.signup(signupData)
        .subscribe(
          (response) => {
            // Handle successful signup
            console.log('Signup successful:', response);
            // Redirect to login or another appropriate page
          },
          (error) => {
            // Handle signup errors
            console.error('Signup failed:', error);
          }
        );
    }
  }
}