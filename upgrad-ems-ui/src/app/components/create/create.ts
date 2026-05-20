import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { EventService } from '../../services/event';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './create.html',
  styleUrls: ['./create.css']
})
export class Create {

  newEvent = {
    eventName: '',
    eventCategory: '',
    eventDate: '',
    description: '',
    status: 'Active'
  };

  constructor(
    private eventService: EventService,
    private router: Router
  ) {}

  createEvent() {
    this.eventService.createEvent(this.newEvent).subscribe({
      next: () => {
        alert('Event Created ✅');
        this.router.navigate(['/events']); // go back
      },
      error: () => {
        alert('Error creating event ❌');
      }
    });
  }
}