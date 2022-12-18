import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';
import { IUser } from 'src/app/model/IUser.Interface';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit {

  registrationForm: FormGroup;
  user: IUser;
  userSubmitted: boolean;
  constructor(private fb: FormBuilder, private userService: UserService) {}

  ngOnInit() {
    this.createRegistrationForm();
  }

createRegistrationForm(){
  this.registrationForm = this.fb.group({
    userName: [null, Validators.required],
    email: [null, [Validators.required, Validators.email]],
    password: [null, [Validators.required, Validators.minLength(8)]],
    confirmPassword: [null, Validators.required],
    mobile: [null, [Validators.required, Validators.minLength(10)]]
  }, {validators: this.passwordMatchingValidatior})
}

  get userName() {
    return this.registrationForm.get('userName') as FormControl;
  }

  get email() {
    return this.registrationForm.get('email') as FormControl;
  }

  get password() {
    return this.registrationForm.get('password') as FormControl;
  }

  get confirmPassword() {
    return this.registrationForm.get('confirmPassword') as FormControl;
  }

  get mobile() {
    return this.registrationForm.get('mobile') as FormControl;
  }

  passwordMatchingValidatior(fg: FormGroup): Validators {
    return fg.get('password')?.value === fg.get('confirmPassword')?.value
    ? {}
    : {notmatched: true};
  }

  onSubmit() {
    console.log(this.registrationForm);
    this.userSubmitted = true;
    if (this.registrationForm.valid){
      this.userService.addUser(this.userData());
      this.registrationForm.reset();
      this.userSubmitted = false;
    }
  }

  userData(): IUser {
    return this.user = {
      userName: this.userName.value,
      email: this.email.value,
      password: this.password.value,
      mobile: this.mobile.value
    };
  }
}
