import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackbarComponent } from '../components/snackbar/snackbar.component';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(public snackBar: MatSnackBar) { }

  successMessage(message: string, action: string) {
    let className = 'success-snackbar';
    return this.fnSnackBar(message, action, className);
  }

  errorMessage(message: string, action: string) {
    let className = 'error-snackbar';
    return this.fnSnackBar(message, action, className);
  }

  warningMessage(message: string, action: string) {
    let className = 'warning';
    return this.fnSnackBar(message, action, className);
  }

  fnSnackBar(message, action, className) {
    return this.snackBar.open(message, action, {
      duration: 5000,
      verticalPosition: 'top',
      panelClass: [className]
    });
  }
  openMultiSnackbarMessage(title:any,message:any,className) {
    this.snackBar.openFromComponent(SnackbarComponent, {
        data: {
          html: message
          //html: '<h4 class="snack-barTitle">'+ title +'</h4>'+ message
        },
       panelClass: [className]
     });
    } 
}

