import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { IUserForRegister } from 'src/app/model/IUser';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit {

  registrationForm: FormGroup;
  userSubmitted: boolean;
  user: IUserForRegister;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private alertify: AlertifyService ) {}

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
      this.authService.registerUser(this.userData()).subscribe(()=>{
        this.onReset();
        this.alertify.onSuccess('Congrats, you are successfully registered.');
      }, error => {
        console.log(error);
        this.alertify.onError(error.error);
      });
    }
  }

  onReset() {
    this.registrationForm.reset();
    this.userSubmitted = false;
  }

  userData(): IUserForRegister {
    return this.user = {
      userName: this.userName.value,
      email: this.email.value,
      password: this.password.value,
      mobile: this.mobile.value
    };
  }
}
