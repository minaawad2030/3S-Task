import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'users',
    pathMatch: 'full',
  },
  {
    path: 'users',
    loadComponent: () =>
      import('./Users/add-update-user/add-update-user.component').then(
        (x) => x.AddUpdateUserComponent
      ),
  },
];
