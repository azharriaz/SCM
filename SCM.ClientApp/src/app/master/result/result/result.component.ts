import { Component, OnInit } from '@angular/core';
import { NgForm, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Student } from 'src/app/Models/Student';
import { ActivatedRoute, Router } from '@angular/router';
import { ResultService } from '../result.service';
import { AlertService } from '../../student/services/alert-srv';
@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.scss']
})
export class ResultComponent implements OnInit {

  studentResultForm: FormGroup;
  constructor(private http: ResultService,private _fb: FormBuilder,
    private _avRoute: ActivatedRoute,private alertSrv:AlertService, private router: Router) {
    this.studentResultForm = this._fb.group({
      courseNo: [''],
      rollNo: ['', [Validators.required]]
    });
   }
  ngOnInit(): void {
  }
  GetStudentCGP(rollNo:string,courseNo){
    this.http.getStudentCGPA(rollNo,courseNo).subscribe((cgpa:number)=>{
      if(!cgpa)
       this.alertSrv.alertError("No record found, please check your details");
      

      this.alertSrv.alertSuccess(courseNo? `GPA of course is ${cgpa}`:`CGPA of student is ${cgpa}`);
    },
    (error:any)=>{
      this.alertSrv.alertError("Something went wrong, Try again later");
    }
    )
  }
  GetResult(form: NgForm) {
    if(form.invalid) return;
    this.GetStudentCGP(this.RollNo.value,this.CourseNo.value);
  }

  get RollNo() { return this.studentResultForm.get('rollNo'); }
  get CourseNo() { return this.studentResultForm.get('courseNo'); }

}
