import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RiskChart, RiskMatrix, RiskSheet, RiskParameter } from 'src/app/shared/models/risk-analysis/risk-analysis.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RiskAnalysisService {

  constructor(private http: HttpClient) { }

  getCurrentRiskMatrix(): Observable<RiskMatrix> {
    return this.http.get<RiskMatrix>(`${environment.currentRiskMatrix}`);
  }

  getCurrentRiskChart(priority:number): Observable<RiskChart>
  {
    return this.http.get<RiskChart>(`${environment.currentRiskChart}/?priority=${priority}`);
  }

    getCurrentRiskSheet(priority:number): Observable<RiskSheet[]>
  {
    return this.http.get<RiskSheet[]>(`${environment.currentRiskSheet}/?priority=${priority}`);
  }

  getAnalysisRiskMatrix(): Observable<RiskMatrix> {
    return this.http.get<RiskMatrix>(`${environment.analysisRiskMatrix}`);
  }

  getAnalysisRiskChart(priority:number): Observable<RiskChart>
  {
    return this.http.get<RiskChart>(`${environment.analysisRiskChart}/?priority=${priority}`);
  }

  getAnalysisRiskSheet(priority:number): Observable<RiskSheet[]>
  {
    return this.http.get<RiskSheet[]>(`${environment.analysisRiskSheet}/?priority=${priority}`);
  }

  analyzeRisk(form: any) {
    return this.http.post(`${environment.analyzeRisk}`, form);
  }
}
