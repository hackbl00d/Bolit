import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./pages/home/home.component').then(m => m.HomeComponent),
  },
  {
    path: 'dictionary',
    loadComponent: () => import('./pages/dictionary/dictionary.component').then(m => m.DictionaryComponent),
  },
  {
    path: 'contacts',
    loadComponent: () => import('./pages/contacts/contacts.component').then(m => m.ContactsComponent),
  },
  {
    path: 'report',
    loadComponent: () => import('./pages/report/report.component').then(m => m.ReportComponent),
  },
  {
    path: '**',
    redirectTo: '',
  },
];
