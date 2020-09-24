import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { CorrosionStudy } from 'src/app/shared/models/corrosion-study/corrosion-study.model';
import { GlobalService } from 'src/app/shared/services/global.service';

@Injectable({
  providedIn: 'root'
})
export class CorrosionStudyService {

  constructor(private http: HttpClient, private global: GlobalService) { }

  getCorrosionStudyList(object: any) {
    return this.http.post(`${environment.corrosionStudyListService}`, object);
  }

  getPipeCluster(object: any) {
    return this.http.post(`${environment.corrosionPipeCluster}`, object);
  }

  addCorrosionStudy(form: any) {
    return this.global.postFormData(`${environment.addNewCorrosionStudyService}`, form);
  }

  updateCorrosionStudy(form: any) {
    return this.http.put(`${environment.updateCorrosionStudyService}`, form);
  }

  getCorrosionData(loopNo: string) {
    return this.http.get(`${environment.corrosionByLoopNoService}?LoopNo=${loopNo}`);
  }
}
