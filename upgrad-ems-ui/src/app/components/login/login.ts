import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './login.html',
  styleUrls: ['./login.css']
})
export class Login {

  username = '';
  password = '';
  error = '';

  constructor(
   private router: Router,
   private auth: AuthService
  ) {}
  onLogin() {

  if (!this.username || !this.password) {
    this.error = 'Enter credentials';
    return;
  }

  const loginData = {
    email: this.username,
    password: this.password
  };

  this.auth.login(loginData).subscribe({
  next: (res: any) => {

  console.log('SUCCESS RESPONSE:', res);

  localStorage.setItem('token', res.token);

  localStorage.setItem('role', res.role);

  if(res.role === 'Admin'){

    this.router.navigate(['/admin-dashboard']);

  }

  else{

    this.router.navigate(['/participant-dashboard']);

  }

  },

  error: (err) => {

    console.log('ERROR RESPONSE:', err);

    this.error = 'Invalid credentials';
  }
  });
}
}