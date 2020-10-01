import { Component, OnInit } from '@angular/core';
import { NgForm, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Student } from 'src/app/Models/Student';
import { StudentDetailsHttpService } from '../services/student-srv';
import PNotify from 'pnotify/dist/es/PNotify';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../services/alert-srv';
PNotify.defaults.styling = 'bootstrap3';
PNotify.defaults.icons = 'bootstrap3';
@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.scss']
})
export class AddStudentComponent implements OnInit {
  studentForm: FormGroup;
  constructor(private http: StudentDetailsHttpService,private _fb: FormBuilder,
    private _avRoute: ActivatedRoute,private alertSrv:AlertService, private router: Router) {
    this.studentForm = this._fb.group({
      studentId: 0,
      name: ['', [Validators.required]],
      rollNo: ['', [Validators.required]],
      email: ['', [Validators.required,Validators.email]],
      phone: ['', [Validators.required]],
      address: ['', [Validators.required]]
    });
    let paramId=this._avRoute.snapshot.params['id'];
    if (paramId && paramId!="0") {
      this.StudentId.setValue(this._avRoute.snapshot.params['id']);
      this.GetStudentById(this.StudentId.value);
    }
   }
  ngOnInit(): void {
  }
  GetStudentById(studentId:number){
    this.http.getStudentById(studentId).subscribe((data:Student)=>{
      this.studentForm.patchValue(data);
    })
  }
  onSubmit(form: NgForm) {
    if(form.invalid) return;
    if(this.StudentId.value==0){
    this.http.postStudent(this.studentForm.value).subscribe((data:Student)=>{
      this.alertSrv.alertSuccess("Record Saved Successfully!");
      this.redirectToListing();
    },(error:any)=>{
      this.alertSrv.alertError("There is something wrong. Please try again later!");
    });
    }else{
      this.http.updateStudent(this.studentForm.value,this.StudentId.value).subscribe((data:Student)=>{
        this.alertSrv.alertSuccess("Record Updated Successfully!");
        this.redirectToListing();
      },(error:any)=>{
        this.alertSrv.alertError("There is something wrong. Please try again later!");
      });
    }
  }
  redirectToListing() {
    setTimeout(() => {
      this.router.navigate(['/master/students']);
    }, 2000);
  }
  get Name() { return this.studentForm.get('name'); }
  get RollNo() { return this.studentForm.get('rollNo'); }
  get Email() { return this.studentForm.get('email'); }
  get Phone() { return this.studentForm.get('phone'); }
  get Address() { return this.studentForm.get('address'); }
  get StudentId() { return this.studentForm.get('studentId'); }

}
