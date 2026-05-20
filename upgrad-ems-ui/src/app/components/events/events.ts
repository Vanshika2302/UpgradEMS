import { Component, OnInit } from '@angular/core';
import { EventService } from '../../services/event';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-events',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './events.html',
  styleUrls: ['./events.css']
})
export class Events implements OnInit {

  events: any[] = [];

  selectedEvent: any = null;

  successMessage: string = '';
  errorMessage: string = '';

  loading: boolean = false;

  constructor(private eventService: EventService) {}

  ngOnInit(): void {
    this.loadEvents();
  }

  loadEvents() {

  this.eventService.getEvents().subscribe({

    next: (res: any) => {

      console.log(res);

      this.events = res;

    },

    error: (err) => {

      console.log(err);

    }

  });

}

  joinEvent(event: any): void {

    alert('Joined ' + event.eventName);
  }

  deleteEvent(id: number): void {

    if (!confirm('Delete this event?')) {
      return;
    }

    this.eventService.deleteEvent(id).subscribe({

      next: () => {

        this.successMessage = 'Event deleted successfully ✅';

        this.loadEvents();
      },

      error: () => {

        this.errorMessage = 'Delete failed ❌';
      }
    });
  }

  editEvent(event: any): void {

    this.selectedEvent = {

      ...event,

      eventDate: event.eventDate
        ? event.eventDate.split('T')[0]
        : ''
    };
  }

  updateEvent(): void {

    this.eventService
      .updateEvent(this.selectedEvent.eventId, this.selectedEvent)
      .subscribe({

        next: () => {

          this.successMessage = 'Event updated successfully ✅';

          this.selectedEvent = null;

          this.loadEvents();
        },

        error: () => {

          this.errorMessage = 'Update failed ❌';
        }
      });
  }

  closeModal(): void {

    this.selectedEvent = null;
  }
}