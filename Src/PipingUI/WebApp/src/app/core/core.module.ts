
import { NgModule, Optional, SkipSelf, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { EnsureModuleLoadedOnceGuard } from './ensureModuleLoadedOnceGuard';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ThemeModule } from './theme.module';

import { environment } from '../../environments/environment';
import { AuthenticateService } from './authentication/authenticate.service';
import { ApiPrefixInterceptor } from './interceptors/api-prefix.interceptor';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ThemeModule
  ],
  exports: [
    RouterModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ThemeModule
  ],
  providers: [
    AuthenticateService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiPrefixInterceptor,
      multi: true,
    },
  ]
})
export class CoreModule extends EnsureModuleLoadedOnceGuard {    // Ensure that CoreModule is only loaded into AppModule
  // Looks for the module in the parent injector to see if it's already been loaded (only want it loaded once)
  constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
    super(parentModule);
  }
}
