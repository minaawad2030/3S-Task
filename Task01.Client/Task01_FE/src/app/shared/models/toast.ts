import { ToastTypes } from '../enums/toast-types.enum';

export interface Toast {
  template: string;
  delay?: number;
  ToastType: ToastTypes;
}
