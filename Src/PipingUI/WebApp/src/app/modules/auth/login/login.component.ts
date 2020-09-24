import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticateService } from 'src/app/core/authentication/authenticate.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  submitted = false;
  loginForm: FormGroup;
  isFormSubmitting = false;
  returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private authenticateService: AuthenticateService,
    private router: Router,
    private route: ActivatedRoute,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: [''],
      password: [''],
      rememberMe: [false]
    });
  }

  onSubmit(): void {
    this.isFormSubmitting = true;
    if (this.loginForm.invalid) {
      return;
    } else {
      this.authenticateService.login(this.loginForm.value)
        .subscribe(user => {
          if(user) {
            localStorage.setItem("access_token",user.token);
            this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || `/pipe-master/dashboard`;
              this.router.navigate([this.returnUrl]);
          }
        },
      err => {
        if(err.status == 400)
        console.log("Incorrect Username or Password");// this.toastr.error("Incorrect Username or Password","Authentication failed");
        else
        console.log(err);
      });
    }

  }

  forgotpassword() {
    const editData = this.dialog.open(ForgotPasswordComponent, {
      width: '400px'
    });
    // editData.afterClosed().subscribe(result => {
    //   const form_data = JSON.stringify(result);
    
    // })
  }

}
