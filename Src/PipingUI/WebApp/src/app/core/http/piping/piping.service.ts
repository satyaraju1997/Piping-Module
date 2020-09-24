import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Piping } from 'src/app/shared/models/piping/piping.model';

@Injectable({
  providedIn: 'root'
})
export class PipingService {

  constructor(private http: HttpClient) { }

  getPipingById(id: number): Observable<Piping[]> {
    return this.http.get<Piping[]>(`${environment.pipingService}/?UserID=${id}`);
  }

}
