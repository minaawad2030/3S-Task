import { Directive, ElementRef, HostListener, Input } from '@angular/core';
import { NgControl } from '@angular/forms';

@Directive({
  selector: '[appDate]',
  standalone: true,
})
export class DateDirective {
  maxAge: number = 20;
  @Input() set appDate(maxAge: number) {
    this.maxAge = maxAge;
  }

  constructor(private el: ElementRef, private control: NgControl) {}

  @HostListener('input', ['$event']) onInput(event: Event) {
    const inputElement = this.el.nativeElement as HTMLInputElement;
    const value = Date.parse(inputElement.value);
    if (value) {
      const currentDate = new Date();
      const diffDays = (currentDate.getTime() - value) / (1000 * 60 * 60 * 24);
      const diffInYears = diffDays / 365;
      if (diffInYears <= this.maxAge) {
        this.control.control!.setErrors({ age: true });
      } else {
        this.control.control!.setErrors(null);
      }
    }
  }
}
