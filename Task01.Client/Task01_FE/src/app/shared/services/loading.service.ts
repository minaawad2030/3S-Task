import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LoadingService {
  busyRequestCount = 0;
  busy() {
    this.busyRequestCount++;
  }

  idle() {
    this.busyRequestCount--;
  }
}
