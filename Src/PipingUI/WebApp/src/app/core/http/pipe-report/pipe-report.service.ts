import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PipeReport, AddPipeReport, InspectionStrategy, Observations } from 'src/app/shared/models/pipe-report/pipe-report.model';
import { environment } from 'src/environments/environment';
import { GlobalService } from 'src/app/shared/services/global.service';
@Injectable({
  providedIn: 'root'
})

export class PipeReportService {

  constructor(private http: HttpClient, private global: GlobalService) { }

  getPipeReportList(equipmentNo: string): Observable<PipeReport[]> {
    return this.http.get<PipeReport[]>(`${environment.pipeReportListService}?EquipmentNo=${equipmentNo}`);
  }

  addPipeReport(equipmentNo: string): Observable<AddPipeReport[]> {
    return this.http.get<AddPipeReport[]>(`${environment.addPipeReportService}?EquipmentNo=${equipmentNo}`);
  }

  updatePipereport(form: any) {
    return this.http.put(`${environment.updatePipeReportService}`, form);
  }

  getInspectionStrategy(equipmentNo: string): Observable<InspectionStrategy[]> {
    return this.http.get<InspectionStrategy[]>(`${environment.inspectionStrategyService}?EquipmentNo=${equipmentNo}`);
  }

  getObservations(): Observable<Observations[]> {
    return this.http.get<Observations[]>(`${environment.observations}`);
  }

  // addNewPipeReport(form: any) {
  //   return this.http.post(`${environment.addNewPipeReportService}`, form);
  // }

  getDataByReportNo(reportNo: string) {
    return this.http.get(`${environment.editPipeReportService}?ReportNo=${reportNo}`)
  }

  editPipeReport(form: any) {
    return this.global.putFormData(`${environment.addNewPipeReportService}`, form);
  }

  addNewPipeReport(form: any) {    
    return this.global.postFormData(`${environment.addNewPipeReportService}`, form)
  }

  getCompany(ID: number) {
    return this.http.get(`${environment.getCompanyService}/${ID}`)
  }
}