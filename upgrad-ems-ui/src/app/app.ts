import { Component } from '@angular/core';

import {
  Router,
  RouterOutlet,
  RouterLink,
  RouterLinkActive
} from '@angular/router';

import { CommonModule } from '@angular/common';

import { AuthService } from './services/auth';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
  CommonModule,
  RouterOutlet,
  RouterLink,
  RouterLinkActive
  ],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})

export class App {

  constructor(
    private auth: AuthService,
    private router: Router
  ) {}

  isLoggedIn(): boolean {

    if (typeof window !== 'undefined') {

      return !!localStorage.getItem('token');

    }

    return false;

  }

  getDashboardRoute(): string {

    const role = localStorage.getItem('role');

    if (role === 'Admin') {

      return '/admin-dashboard';

    }

    return '/participant-dashboard';

  }

  // LOGOUT
  logout() {

    if (typeof window !== 'undefined') {

      localStorage.removeItem('token');
      localStorage.removeItem('role');

    }

    this.router.navigate(['/login']);

  }

}