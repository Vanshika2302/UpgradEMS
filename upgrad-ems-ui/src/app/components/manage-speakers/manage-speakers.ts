import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-manage-speakers',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './manage-speakers.html',
  styleUrls: ['./manage-speakers.css']
})

export class ManageSpeakers implements OnInit {

  speakers: any[] = [];

  speaker: any = {

    name: '',
    expertise: ''

  };

  ngOnInit() {

    this.loadSpeakers();

  }

  loadSpeakers() {

    const data = localStorage.getItem('speakers');

    this.speakers = data
      ? JSON.parse(data)
      : [];

  }

  createSpeaker() {

    this.speaker.speakerId = Date.now();

    this.speakers.push(this.speaker);

    localStorage.setItem(
      'speakers',
      JSON.stringify(this.speakers)
    );

    alert('Speaker Added');

    this.speaker = {

      name: '',
      expertise: ''

    };

  }

  deleteSpeaker(id: number) {

    this.speakers =
      this.speakers.filter(
        x => x.speakerId !== id
      );

    localStorage.setItem(
      'speakers',
      JSON.stringify(this.speakers)
    );

  }

}