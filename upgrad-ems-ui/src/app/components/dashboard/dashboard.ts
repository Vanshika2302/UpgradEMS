import { Component, OnInit } from '@angular/core';
import { EventService } from '../../services/event';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './dashboard.html',
  styleUrls: ['./dashboard.css']
})
export class Dashboard implements OnInit {

  events: any[] = [];

  newEvent = {
  eventName: '',
  eventCategory: '',
  eventDate: '',
  description: '',
  status: 'Active'
  };

  constructor(
  private eventService: EventService,
  private auth: AuthService,
  private router: Router
  ) {}


  ngOnInit() {
    this.loadEvents();
  }

  loadEvents() {
    this.eventService.getEvents().subscribe({
      next: (res: any) => {
        this.events = res;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  createEvent() {
    this.eventService.createEvent(this.newEvent).subscribe({
      next: () => {
        alert('Event Created');
        this.loadEvents();
      },
      error: () => {
        alert('Error creating event');
      }
    });
  }
  deleteEvent(id: number ){
  this.eventService.deleteEvent(id).subscribe({
    next: () => {
      this.loadEvents();
    },
    error: (err) => {
      console.log(err);
    }
  });
  }
  logout() {
  this.auth.logout();
  this.router.navigate(['/']);
  }
}