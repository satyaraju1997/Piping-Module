import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import {MatDialogModule } from '@angular/material/dialog';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { SnackbarComponent } from './shared/components/snackbar/snackbar.component';
//import { JwtModule } from '@auth0/angular-jwt';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './shared/interceptors/auth.interceptor'
import { DatePipe, CurrencyPipe } from '@angular/common';
import { LoaderHelperService } from './shared/services/loader-helper.service';
@NgModule({
  declarations: [
    AppComponent,
    SnackbarComponent,
    
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule,
    MatDialogModule,
    HttpClientModule,
    // JwtModule.forRoot({
    //   config: {
    //     tokenGetter: function  tokenGetter() { return  localStorage.getItem('access_token');}
    //     // ,
    //     // allowedDomains: ['localhost:4200'],
    //     // disallowedRoutes: ['http://localhost:4200/auth/login']
    //   }
    // }) 
  ], 
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }, DatePipe, CurrencyPipe, LoaderHelperService],
  bootstrap: [AppComponent]
})
export class AppModule { }
