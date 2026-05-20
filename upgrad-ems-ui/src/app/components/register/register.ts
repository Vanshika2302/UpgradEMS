import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './register.html',
  styleUrls: ['./register.css']
})
export class Register {

  user = {
    name: '',
    email: '',
    password: '',
    role: 'Participant'
  };

  constructor(
    private auth: AuthService,
    private router: Router
  ) {}

  register() {

  this.auth.register(this.user).subscribe({

    next: (res) => {

      alert('Registration Successful');

      if(this.user.role === 'Admin'){

        this.router.navigate(['/admin-dashboard']);

      }

      else{

        this.router.navigate(['/participant-dashboard']);

      }

    },

    error: (err) => {

      console.log(err);

      alert('Registration Failed');

    }

  });

  }
}