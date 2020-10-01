import { Injectable } from '@angular/core';

import { Observable, of,  Subject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { GlobalService } from './global.service';
import PNotify from 'pnotify/dist/es/PNotify';
PNotify.defaults.styling = 'bootstrap3';
PNotify.defaults.icons = 'bootstrap3';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private subject = new Subject<any>();
  public headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  public httpOptions = {
    headers: this.headers
    //.append('Authorization', 'Bearer ' + this. getToken())
  };


  constructor(private http: HttpClient, private globalService: GlobalService, private router: Router) {
    this.subject.asObservable().subscribe(message => {
      console.log(message);
      this.httpOptions.headers.append('Authorization', 'Bearer ' + this.getToken());
      console.log(this.httpOptions);
    });
  }

  private handleError<T>(result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
      this.globalService.sendMessage('loading', false);
      // Let the app keep running by returning an empty result.
      if (error.status == 401) {
        this.router.navigate(['login']);
      }
      else if (error.status == 0) {
        this.alertError("Oops... something went wrong with your service.");
      }
      return of(result as T);
    };
  }
  public getToken(): string {
    return sessionStorage.getItem("token");
  }
  Get(url: string): Observable<any> {
    this.globalService.sendMessage('loading', true);
    return this.http.get<any>( url)
      .pipe(
        tap((temp: any) => {this.globalService.sendMessage('loading', false) }),
        catchError(this.handleError([]))
      );
  }
  PostDefault(url: string, object: any){
    this.globalService.sendMessage('loading', true);
    return this.http.post(url,object)
    .pipe(
      map(res =>res  ),
      tap((obj: any) => this.globalService.sendMessage('loading', false))
    );
  }
  Post(url: string, object: any): Observable<any> {
    this.globalService.sendMessage('loading', true);
    return this.http.post<any>(url, object, this.httpOptions).pipe(
      tap((obj: any) => this.globalService.sendMessage('loading', false)),
      catchError(this.handleError<any>())
    );
  }
  alertSuccess = function (message: string) {
    PNotify.success({
      text: message,
      delay: 5000,
      buttons: {
        closer: true,

      }
    });
  }
  alertError = function (message: string) {
    PNotify.error({
      text: message,
      delay: 5000,
      buttons: {
        closer: true,

      }
    });
  }
  loading(value: boolean) {
    this.globalService.sendMessage('loading', value);
  }
}
