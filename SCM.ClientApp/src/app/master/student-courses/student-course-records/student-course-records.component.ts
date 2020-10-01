import { Component, OnInit } from '@angular/core';
import { AlertService } from '../../student/services/alert-srv';
import { StudentCourse } from 'src/app/Models/StudentCourse';
import { StudentCourseHttpService } from '../services/student-course-srv';

@Component({
  selector: 'app-student-course-records',
  templateUrl: './student-course-records.component.html',
  styleUrls: ['./student-course-records.component.scss']
})
export class StudentCourseRecordsComponent implements OnInit {

  constructor(private http: StudentCourseHttpService,private alertSrv:AlertService) { }
  StudentCourses: Array<StudentCourse> = [];
  StudentsCoursesCopy: Array<StudentCourse> = [];
  submitted = false;
  AddUpdate: boolean = false;
  page: any = 1;
  pageSize: number = 10;
  ngOnInit() {
    this.http.getStudentCourses()
      .subscribe(res => {
        this.StudentCourses = res.filter(m=>m.isDeleted==false);
        this.StudentsCoursesCopy = this.StudentCourses;
      }, err => {
        console.log(err);
      });
  }
 

  search(term: string) {
    if (!term) {
      this.StudentCourses = this.StudentsCoursesCopy;
    } else {
      this.StudentCourses = this.StudentsCoursesCopy.filter(x =>
        x.studentName.trim().toLowerCase().includes(term.trim().toLowerCase()) || (x.rollNo != null && x.rollNo.trim().toLowerCase().includes(term.trim().toLowerCase()))
      );
    }
  }
  delClicked(studentCourse:StudentCourse){
    this.http.updateStudentCourse({...studentCourse,isDeleted:true},studentCourse.studentCourseId).subscribe((data:StudentCourse)=>{
      this.alertSrv.alertSuccess("Record Deleted Successfully!");
      this.ngOnInit();
    },(error:any)=>{
      this.alertSrv.alertError("There is something wrong. Please try again later!");
    });
  }

}
