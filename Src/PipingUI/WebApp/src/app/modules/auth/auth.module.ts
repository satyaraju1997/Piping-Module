import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ThemeModule } from '../../core/theme.module';
import { AuthComponent } from './auth.component';
import { ForgotPasswordComponent } from './login/forgot-password/forgot-password.component';

@NgModule({
  declarations: [
    AuthRoutingModule.components,
    AuthComponent,
    ForgotPasswordComponent,
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    ThemeModule,
    ReactiveFormsModule
  ],
  providers: []
})
export class AuthModule { }
