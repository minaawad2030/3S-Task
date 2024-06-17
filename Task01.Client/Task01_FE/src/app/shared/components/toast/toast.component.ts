import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { NgbToast } from '@ng-bootstrap/ng-bootstrap';
import { ToastTypes } from '../../enums/toast-types.enum';
import { ToastService } from '../../services/toast.service';
import { Toast } from '../../models/toast';

@Component({
  selector: 'app-toast',
  standalone: true,
  imports: [CommonModule, NgbToast],
  templateUrl: './toast.component.html',
  styleUrl: './toast.component.scss',
})
export class ToastComponent {
  types = ToastTypes;
  toastService = inject(ToastService);

  remove(toast: Toast) {
    this.toastService.remove(toast);
  }
}
