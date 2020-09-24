import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BasicData, DesignData, ItemMenu, ExternalCorrosion } from 'src/app/shared/models/pipemaster/pipemaster.model';
import { POF_IC } from 'src/app/shared/models/pof-ic/pof-ic.model';
import { environment } from 'src/environments/environment';
import { GlobalService } from 'src/app/shared/services/global.service';
import {  map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class PipeMasterService {

  constructor(private http: HttpClient, private global: GlobalService) { }

  getBasicData(id: number) :Observable<BasicData[]> {
    return this.http.get<BasicData[]>(`${environment.basicDataService}/?ID=${id}`);
  }

  updateBasicData(form: any) {
    return this.http.put(`${environment.updateBasicDataService}`, form)
  }

  getDesignData(id: number): Observable<DesignData[]> {
    return this.http.get<DesignData[]>(`${environment.designDataService}/?ID=${id}`)
  }

  updateDesignData(form: any) {
    return this.http.post(`${environment.updateDesignDataService}`, form)
  }

  getNextItem(id: number): Observable<ItemMenu> {
    return this.http.get<ItemMenu>(`${environment.getNextItem}/?UnitID=${id}`)
  }

  getCurrentItem(id: number): Observable<ItemMenu> {
    return this.http.get<ItemMenu>(`${environment.getCurrentItem}/?UnitID=${id}`)
  }

  getPreviousItem(id: number): Observable<ItemMenu> {
    return this.http.get<ItemMenu>(`${environment.getPreviousItem}/?UnitID=${id}`)
  }

  getInternalCorrosionData(id: number): Observable<POF_IC[]> {
    return this.http.get<POF_IC[]>(`${environment.internalCorrosionDataService}/${id}`)
  }

  updateInternalCorrosionData(form: any) {
    return this.http.put(`${environment.updateInternalCorrosionDataService}`, form)
  }

  getExternalCorrosionData(id: number): Observable<ExternalCorrosion[]> {
    return this.http.get<ExternalCorrosion[]>(`${environment.externalCorrosionDataService}/${id}`)
  }

  updateExternalCorrosionData(form: any) {
    return this.http.put(`${environment.updateExternalCorrosionDataService}`, form);
  }
  getMaterialCodesList() {
    return this.http.get(`${environment.materialCodesDropdownListService}`);
  }

  getInsulationTypes() {
    return this.http.get(`${environment.insulationTypesListService}`);
  }

  getMaterialStdList() {
    return this.http.get(`${environment.materialStdListService}`);
  }

  getMaterialGradeList() {
    return this.http.get(`${environment.materialGradeListService}`);
  }

  importPipeMaster(json:any)
  {
    return this.http.post(`${environment.importPipeMasterService}`,json);
  }
  // uploadPipeMaster(formData: FormData)
  // {
  //   return this.global.postFormData(`${environment.uploadPipeMasterService}`,formData);
  // }
  uploadPipeMaster(formData: FormData): Observable<any> {
    return this.http.post<any>(`${environment.uploadPipeMasterService}`, formData)
      .pipe(
        map(response => <any>response)
      );
  }
}
