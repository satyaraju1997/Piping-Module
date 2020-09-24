import { Injectable } from '@angular/core';
import { POF_IC } from 'src/app/shared/models/pof-ic/pof-ic.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PofIcService {

  constructor(private http: HttpClient) { }

  getPOFICDetails(equipmentNo: string, presentYear: string): Observable<POF_IC[]> {
    return this.http.get<POF_IC[]>(`${environment.getPOF_ICDetailsService}/?EQUIPMENT_NO=${equipmentNo}&PRESENT_YEAR=${presentYear}`);
  }

  updatePOFICDetails(form: any, equipmentNo: string, presentYear: string, effeciencyWeld: string, youngsModulus: string) {
    return this.http.put(`${environment.updatePOF_ICDetailsService}?EQUIPMENT_NO=${equipmentNo}&PRESENT_YEAR=${presentYear}&EFFICIENCY_OF_WELD_E=${effeciencyWeld}&YOUNGS_MODULUS_Y=${youngsModulus}`, form);
  }
}
