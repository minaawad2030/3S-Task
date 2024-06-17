import { Component, OnInit, inject } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { User } from '../models/user';
import { UsersService } from '../users.service';
import { LookupsService } from '../../lookups/lookups.service';
import { Governorate } from '../../lookups/models/governorate';
import { CommonModule } from '@angular/common';
import { DateDirective } from '../../shared/directives/date.directive';
import { Address } from '../models/address';
import { City } from '../../lookups/models/city';
import { ToastService } from '../../shared/services/toast.service';
import { ToastTypes } from '../../shared/enums/toast-types.enum';

@Component({
  selector: 'app-add-update-user',
  standalone: true,
  imports: [FormsModule, CommonModule, DateDirective],
  templateUrl: './add-update-user.component.html',
  styleUrl: './add-update-user.component.scss',
})
export class AddUpdateUserComponent implements OnInit {
  //------------- Vars -------------//
  user: User = new User();
  governorates: Governorate[] = [];
  cities: City[] = [];

  //------------- Injects -------------//
  userService = inject(UsersService);
  lookupsService = inject(LookupsService);
  toastService = inject(ToastService);

  //------------- OnInit -------------//
  ngOnInit(): void {}

  //------------- Methods -------------//
  submit(form: NgForm) {
    console.log(this.user);
    this.userService.addUser(this.user).subscribe({
      next: (res) => {
        this.toastService.show({
          template: res.message,
          ToastType: ToastTypes.Success,
        });
        form.resetForm();
        this.user.addresses = [];
      },
      error: (err) => {
        this.toastService.show({
          template: err.error.message,
          ToastType: ToastTypes.Error,
        });
      },
    });
  }

  addAddress() {
    if (this.governorates.length == 0) this.loadGovernorates();
    this.user.addresses.push(new Address());
  }

  loadGovernorates() {
    this.lookupsService.getAllGovernorate().subscribe({
      next: (res) => {
        this.governorates = res;
        console.log(res);
      },
    });
  }

  deleteAddress(index: number) {
    this.user.addresses.splice(index, 1);
  }

  loadCities(event: any) {
    let governorateId = event.target.value;
    this.lookupsService.getCitiesByGovernorateId(governorateId).subscribe({
      next: (res) => {
        console.log(res);
        this.cities = res;
      },
    });
  }
}
