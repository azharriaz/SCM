import { Injectable } from '@angular/core';
import { ApiService } from '../../../Services/apiService';
import { Observable } from 'rxjs';
import { StudentCourse } from 'src/app/Models/StudentCourse';
import { Course } from 'src/app/Models/Course';

@Injectable({
  providedIn: 'root'
})
export class StudentCourseHttpService {
  ResourceInfo:string="studentcoursessrv";
  CourseInfo:string="coursessrv";
  constructor(private apiService: ApiService) { }

  public getStudentCourses(): Observable<StudentCourse[]> {
    return this.apiService.get<StudentCourse[]>(this.ResourceInfo).pipe();
  }
  public getStudenCourseById(id:number): Observable<StudentCourse> {
    return this.apiService.get<StudentCourse>(this.ResourceInfo+"/"+id).pipe();
  }
  public postStudentCourse(model:StudentCourse): Observable<StudentCourse> {
    return this.apiService.post<StudentCourse>(this.ResourceInfo,model).pipe();
  }
  public updateStudentCourse(model:StudentCourse,Id:number): Observable<StudentCourse> {
    return this.apiService.put<StudentCourse>(this.ResourceInfo,Id,model).pipe();
  }
  public getCourses():Observable<Course[]>{
      return this.apiService.get<Course[]>(this.CourseInfo).pipe()
  }
}
