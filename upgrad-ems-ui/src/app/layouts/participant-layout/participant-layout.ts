import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet, RouterLink } from '@angular/router';

@Component({
  selector: 'app-participant-layout',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink
  ],
  templateUrl: './participant-layout.html',
  styleUrls: ['./participant-layout.css']
})
export class ParticipantLayout {}