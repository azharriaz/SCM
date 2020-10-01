import { Injectable } from '@angular/core';
import { ApiService } from '../../../Services/apiService';
import { Observable } from 'rxjs';
import { Student } from 'src/app/Models/Student';

@Injectable({
  providedIn: 'root'
})
export class StudentDetailsHttpService {
  ResourceInfo:string="studentsrv";
  constructor(private apiService: ApiService) { }

  public getStudents(): Observable<Student[]> {
    return this.apiService.get<Student[]>(this.ResourceInfo).pipe();
  }
  public getStudentById(id:number): Observable<Student> {
    return this.apiService.get<Student>(this.ResourceInfo+"/"+id).pipe();
  }
  public postStudent(model:Student): Observable<Student> {
    return this.apiService.post<Student>(this.ResourceInfo,model).pipe();
  }
  public updateStudent(model:Student,Id:number): Observable<Student> {
    return this.apiService.put<Student>(this.ResourceInfo,Id,model).pipe();
  }
}
