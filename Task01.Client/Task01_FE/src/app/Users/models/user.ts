import { Address } from './address';

export class User {
  id!: number;
  firstName!: string;
  middleName!: string;
  lastName!: string;
  birthDate!: Date;
  mobileNumber!: string;
  email!: string;
  addresses: Address[] = [];
}
