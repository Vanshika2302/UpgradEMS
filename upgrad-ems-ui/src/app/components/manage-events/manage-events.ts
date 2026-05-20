import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { EventService } from '../../services/event';

@Component({
  selector: 'app-manage-events',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './manage-events.html',
  styleUrls: ['./manage-events.css']
})
export class ManageEvents implements OnInit {

  events: any[] = [];

  event = {

    eventName: '',
    description: '',
    eventCategory: '',
    eventDate: ''

  };

  constructor(
    private eventService: EventService
  ) {}

  ngOnInit(): void {

    this.loadEvents();

  }

  loadEvents(){

    this.eventService.getEvents().subscribe({

      next: (res: any) => {

        this.events = res;

      },

      error: (err) => {

        console.log(err);

      }

    });

  }

  createEvent(){

    this.eventService.createEvent(this.event).subscribe({

      next: () => {

        alert('Event Created');

        this.loadEvents();

        this.event = {

          eventName: '',
          description: '',
          eventCategory: '',
          eventDate: ''

        };

      },

      error: (err) => {

        console.log(err);

        alert('Creation Failed');

      }

    });

  }

  deleteEvent(id: number){

    this.eventService.deleteEvent(id).subscribe({

      next: () => {

        alert('Deleted');

        this.loadEvents();

      },

      error: () => {

        alert('Delete Failed');

      }

    });

  }

}