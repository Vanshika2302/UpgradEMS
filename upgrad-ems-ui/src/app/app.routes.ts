import { Routes } from '@angular/router';

import { Home } from './components/home/home';
import { Login } from './components/login/login';
import { Register } from './components/register/register';
import { Events } from './components/events/events';

import { AdminDashboard } from './components/admin-dashboard/admin-dashboard';
import { ParticipantDashboard } from './components/participant-dashboard/participant-dashboard';

import { ManageEvents } from './components/manage-events/manage-events';
import { ManageSessions } from './components/manage-sessions/manage-sessions';
import { ManageSpeakers } from './components/manage-speakers/manage-speakers';

export const routes: Routes = [

  {
    path: '',
    component: Home
  },

  {
    path: 'login',
    component: Login
  },

  {
    path: 'register',
    component: Register
  },

  {
    path: 'events',
    component: Events
  },

  // PARTICIPANT
  {
    path: 'participant-dashboard',
    component: ParticipantDashboard
  },

  // ADMIN
  {
    path: 'admin-dashboard',
    component: AdminDashboard
  },

  {
    path: 'manage-events',
    component: ManageEvents
  },

  {
    path: 'manage-sessions',
    component: ManageSessions
  },

  {
    path: 'manage-speakers',
    component: ManageSpeakers
  }

];