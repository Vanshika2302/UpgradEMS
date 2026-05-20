import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EventService } from '../../services/event';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.html',
  styleUrls: ['./home.css']
})
export class Home implements OnInit {

  events: any[] = [];

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

  joinEvent(event: any) {
    alert('Joined ' + event.eventName);
  }

}