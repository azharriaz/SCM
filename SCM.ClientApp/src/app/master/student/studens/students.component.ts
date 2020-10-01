import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Student } from 'src/app/Models/Student';
import { StudentDetailsHttpService } from '../services/student-srv';
import { AlertService } from '../services/alert-srv';
@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss']
})
export class StudentsComponent implements OnInit {
  @ViewChild('Name') MedicineName: ElementRef;
  constructor(private http: StudentDetailsHttpService,private alertSrv:AlertService) { }
 
  obj: Student = new Student();
  Students: Array<Student> = [];
  StudentsCopy: Array<Student> = [];
  submitted = false;
  AddUpdate: boolean = false;
  page: any = 1;
  pageSize: number = 10;
  ngOnInit() {
    this.http.getStudents()
      .subscribe(res => {
        this.Students = res.filter(m=>m.isDeleted==false);
        this.StudentsCopy = this.Students;
      }, err => {
        console.log(err);
      });
  }
 

  search(term: string) {
    if (!term) {
      this.Students = this.StudentsCopy;
    } else {
      this.Students = this.StudentsCopy.filter(x =>
        x.name.trim().toLowerCase().includes(term.trim().toLowerCase()) || (x.rollNo != null && x.rollNo.trim().toLowerCase().includes(term.trim().toLowerCase()))
      );
    }
  }
  delClicked(student:Student){
    this.http.updateStudent({...student,isDeleted:true},student.studentId).subscribe((data:Student)=>{
      this.alertSrv.alertSuccess("Record Deleted Successfully!");
      this.ngOnInit();
    },(error:any)=>{
      this.alertSrv.alertError("There is something wrong. Please try again later!");
    });
  }
}
