import { Injectable } from '@angular/core';
import { ApiService } from 'src/app/Services/apiService';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ResultService {

  ResourceInfo:string="studentresultsrv";
  constructor(private apiService: ApiService) { }

  public getStudentCGPA(rollNo:string,courseNo:string): Observable<number> {
    return this.apiService.get<number>(this.formateURL(rollNo,courseNo)).pipe();
  }
 formateURL(rollNo:string,courseNo:string){
   return courseNo?`${this.ResourceInfo}?rollNo=${rollNo}&courseNo=${courseNo}`:`${this.ResourceInfo}?rollNo=${rollNo}`;
 }
}
