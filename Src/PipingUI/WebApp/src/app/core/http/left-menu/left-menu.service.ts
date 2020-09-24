import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { QuickLink } from 'src/app/shared/models/quick-link/quick-link.model';
import { LeftMenu } from 'src/app/shared/models/left-menu/left-menu.model';

@Injectable({
  providedIn: 'root'
})
export class LeftMenuService {

  constructor(private http: HttpClient) { }

  getLeftMenuById(id: number): Observable<LeftMenu[]> {
    return this.http.get<LeftMenu[]>(`${environment.leftMenuService}/?CompanyID=${id}`);
  }

  getQuickLinkById(id: number): Observable<QuickLink[]> {
    return this.http.get<QuickLink[]>(`${environment.quickLinkService}/?UserID=${id}`);
  }
}
