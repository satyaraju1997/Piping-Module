import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpErrorResponse,
  HttpResponse,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, filter, tap } from 'rxjs/operators';
import {ActivatedRoute, Router} from '@angular/router';
@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private router: Router) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const token = localStorage.getItem("access_token");
   
    if (token) {
      const cloned = request.clone({
        headers: request.headers.set("Authorization", "Bearer " + token)
      });

      return next.handle(cloned);
    }
    else {      
      return next.handle(request).pipe(
        
        tap(event => {
          if (event instanceof HttpResponse) {           
            this.router.navigate(['/auth/login']);
          }
        }, error => {
          console.log(error);
          if(error instanceof HttpErrorResponse)
          {
            
            if(error.status === 401)
            {              
              this.router.navigate(['/auth/login']);
            }
          }
        })
      );
    }
  }
}
