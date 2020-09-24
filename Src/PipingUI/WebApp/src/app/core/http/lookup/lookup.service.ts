import { Injectable } from '@angular/core';
import { StructuralMinThk } from 'src/app/shared/models/lookup/lookup.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LookupService {

  constructor(private http: HttpClient) { }  

  getAllStructuralMinThkData(): Observable<StructuralMinThk[]> {
    return this.http.get<StructuralMinThk[]>(`${environment.getAllStructuralMinThkService}`);
  }

  getStructuralMinThkData(id: number): Observable<StructuralMinThk[]> {
    return this.http.get<StructuralMinThk[]>(`${environment.getStructuralMinThkService}/?ID=${id}`);
  }

  updateStructuralMinThkData(form: any) {
    return this.http.put(`${environment.updateStructuralMinThkService}`, form);
  }

  createStructuralMinThkData(form: any): Observable<StructuralMinThk[]> {
    return this.http.post<StructuralMinThk[]>(`${environment.createStructuralMinThkService}`, form);
  }
}
