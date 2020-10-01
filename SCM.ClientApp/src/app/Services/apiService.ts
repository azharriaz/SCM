import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})

export class ApiService {

  constructor(private http: HttpClient) { }
  
  getAll<T>(url: string, apiBaseUrl?: string): Observable<HttpResponse<T>> {
    return this.http.get<T>(apiBaseUrl ? `${apiBaseUrl}${url}` : `${environment.apiBaseUrl}${url}`, {
        headers: new HttpHeaders().set('Content-Type', 'application/json'),
        observe: 'response' });
  }

  /**
   * GET request.
   *
   * @param {string} url The specific endpoint url.
   * @param {string} [apiBaseUrl] An optional base url as soon as it's different to the default.
   * @returns {Observable<T>}
   * @memberof ApiService
   */
  public get<T>(url: string, apiBaseUrl?: string): Observable<T> {
      return this.http.get<T>(apiBaseUrl ? `${apiBaseUrl}${url}` : `${environment.apiBaseUrl}${url}`);
  }

  /**
   * POST request.
   *
   * @param {string} url The specific endpoint url.
   * @param {T} body The object that should be saved.
   * @param {string} [apiBaseUrl] An optional base url as soon as it's different to the default.
   * @returns {Observable<T>}
   * @memberof ApiService
   */
  public post<T>(url: string, body: T, apiBaseUrl?: string): Observable<T> {
      return this.http.post<T>(`${apiBaseUrl ?apiBaseUrl:environment.apiBaseUrl}${url}`, body);
  }

  /**
   * PUT request.
   *
   * @param {string} url The specific endpoint url.
   * @param {T} body The object that should be updated.
   * @param {string} [apiBaseUrl] An optional base url as soon as it's different to the default.
   * @returns {Observable<T>}
   * @memberof ApiService
   */
  public put<T>(url: string,id:number, body: T, apiBaseUrl?: string): Observable<T> {
      return this.http.put<T>( `${apiBaseUrl ?apiBaseUrl:environment.apiBaseUrl}${url}/${id}`,body);
  }

  /**
   * DELETE request.
   *
   * @param {string} url The specific endpoint url.
   * @param {string} [apiBaseUrl] An optional base url as soon as it's different to the default.
   * @returns {Observable<Object>}
   * @memberof ApiService
   */
  public delete<T>(url: string, apiBaseUrl?: string): Observable<T> {
      return this.http.delete<T>(`${apiBaseUrl ?apiBaseUrl:environment.apiBaseUrl}${url}`);
  }

}
