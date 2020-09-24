import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import * as environmentInformation from '../../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class GlobalService {
  _serverURL: string;
  //baseUrl: string="http://192.168.2.121:8008/api/v1/";
  //baseUrl: string="https://localhost:44307/api/v1/";


  constructor(private _http: HttpClient) {
    this._serverURL = environmentInformation.environment.host;
  }
  // Configure HTTP Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': sessionStorage["token"]
    })
  }

  httpOptionsWithoutConentType = {
    headers: new HttpHeaders({
      'Authorization': sessionStorage["token"]
    })
  }

  httpOptionsForMultipart = {
    headers: new HttpHeaders({
      // 'Authorization': sessionStorage["token"],
      'Accept': "multipart/form-data"
    })
  }

  httpOptionsForDownload = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
      ,'Accept': 'application/json'
      // ,'Authorization': sessionStorage["token"]
    }),
    responseType: 'blob' as 'json'
  }

  getAll<T>(url: any): Observable<T> {
    return this._http.get<T>(this._serverURL + url, this.httpOptionsWithoutConentType);
  }

  getWithParam<T>(url: any, Id: any): Observable<T> {
    return this._http.get<T>(this._serverURL + url + "/" + Id, this.httpOptions);
  }


  getWithOutParam<T>(url: any): Observable<T> {
    return this._http.get<T>(this._serverURL + url, this.httpOptionsWithoutConentType);
  }
  post(url: any, obj: any): Observable<any> {
    return this._http.post<any>(this._serverURL + url, JSON.stringify(obj), this.httpOptions);
  }

  put(url: any, obj: any): Observable<any> {

    return this._http.put<any>(this._serverURL + url, JSON.stringify(obj), this.httpOptions);
  }

  delete(url: any): Observable<any> {
    return this._http.delete<any>(this._serverURL + url, this.httpOptionsWithoutConentType);
  }

  deleteWithParam(url: any, Id: any): Observable<any> {
    return this._http.delete<any>(this._serverURL + url + "/" + Id, this.httpOptionsWithoutConentType);
  }

  postFormData(url: any, formData: any): Observable<any> {
    debugger
    return this._http.post<any>( url, formData, this.httpOptionsForMultipart);
  }

  putFormData(url: any, formData: any): Observable<any> {
    return this._http.put<any>(this._serverURL + url, formData, this.httpOptionsForMultipart);
  }

  downloadFile(url): Observable<Blob> {
    
    return this._http.get<Blob>(this._serverURL + url, this.httpOptionsForDownload);
  }

  async asyncGetAll<T>(url: any) {
    return await this._http.get<T>(this._serverURL + url, this.httpOptionsWithoutConentType).toPromise();
  }
}
