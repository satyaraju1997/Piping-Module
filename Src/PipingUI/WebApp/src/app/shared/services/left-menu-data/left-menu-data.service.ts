import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LeftMenuDataService {

  menuData:any;

  constructor() { }

  getMenuData() {
    return this.menuData;
  }

  setMenuData(data: any[]) {
    this.menuData = data;
  }
}
