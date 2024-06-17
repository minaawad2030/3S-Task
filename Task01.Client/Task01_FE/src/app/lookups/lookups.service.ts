import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Governorate } from './models/governorate';
import { City } from './models/city';

@Injectable({
  providedIn: 'root',
})
export class LookupsService {
  private httpClient = inject(HttpClient);

  private baseUrl = `${environment.apiUrl}/api/Lookups`;

  constructor() {}

  getAllGovernorate() {
    return this.httpClient.get<Governorate[]>(`${this.baseUrl}/Governorates`);
  }

  getCitiesByGovernorateId(id: number) {
    return this.httpClient.get<City[]>(
      `${this.baseUrl}/Governorates/${id}/Cities`
    );
  }
}
