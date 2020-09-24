import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class LoaderHelperService {
  isDisplayed: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  private calls: boolean[] = [];

  constructor() { }

  /**
   * Shows the spinner when loading
   */
  showLoader(): void {
    this.calls.push(true);
    this.isDisplayed.next(this.calls.length > 0);
  }

  /**
   * Hides the spinner after loading
   */
  hideLoader(): void {
    this.calls.pop();
    this.isDisplayed.next(this.calls.length > 0);
  }
}
