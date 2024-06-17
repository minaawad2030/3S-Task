import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { User } from './models/user';
import { Response } from '../shared/models/response';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private httpClient = inject(HttpClient);
  private baseUrl = `${environment.apiUrl}/api/Users`;

  addUser(user: User) {
    return this.httpClient.post<Response>(this.baseUrl, user);
  }
}
