import { Injectable } from '@angular/core';

import {
  HttpClient,
  HttpHeaders
} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class EventService {

  private apiUrl = 'https://localhost:7105/api/Event';

  constructor(
    private http: HttpClient
  ) {}

  getHeaders() {

    let token = '';

    if (typeof window !== 'undefined') {

      token = localStorage.getItem('token') || '';

    }

    return {

      headers: new HttpHeaders({

        Authorization: `Bearer ${token}`

      })

    };

  }

  // GET ALL EVENTS
  getEvents() {

    return this.http.get(

      this.apiUrl,

      this.getHeaders()

    );

  }

  // CREATE EVENT
  createEvent(data: any) {

    return this.http.post(

      this.apiUrl,

      data,

      this.getHeaders()

    );

  }

  // DELETE EVENT
  deleteEvent(id: number) {

    return this.http.delete(

      `${this.apiUrl}/${id}`,

      this.getHeaders()

    );

  }

  // UPDATE EVENT
  updateEvent(id: number, data: any) {

    return this.http.put(

      `${this.apiUrl}/${id}`,

      data,

      this.getHeaders()

    );

  }

}