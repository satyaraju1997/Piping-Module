import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SideNavService {

  public appDrawer: any;

  constructor() {
  }

  public closeNav() {
    this.appDrawer.close();
  }

  public openNav() {
    this.appDrawer.open();
  }

}
