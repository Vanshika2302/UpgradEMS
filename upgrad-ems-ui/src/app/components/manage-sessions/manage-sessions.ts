import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-manage-sessions',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './manage-sessions.html',
  styleUrls: ['./manage-sessions.css']
})

export class ManageSessions implements OnInit {

  sessions: any[] = [];

  session: any = {

    title: '',
    description: '',
    startTime: ''

  };

  ngOnInit() {

    this.loadSessions();

  }

  loadSessions() {

    const data = localStorage.getItem('sessions');

    this.sessions = data
      ? JSON.parse(data)
      : [];

  }

  createSession() {

    this.session.sessionId = Date.now();

    this.sessions.push(this.session);

    localStorage.setItem(
      'sessions',
      JSON.stringify(this.sessions)
    );

    alert('Session Added');

    this.session = {

      title: '',
      description: '',
      startTime: ''

    };

  }

  deleteSession(id: number) {

    this.sessions =
      this.sessions.filter(
        x => x.sessionId !== id
      );

    localStorage.setItem(
      'sessions',
      JSON.stringify(this.sessions)
    );

  }

}