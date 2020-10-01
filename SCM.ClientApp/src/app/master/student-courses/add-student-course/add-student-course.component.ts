import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { StudentCourseHttpService } from '../services/student-course-srv';
import { AlertService } from '../../student/services/alert-srv';
import { ActivatedRoute, Router } from '@angular/router';
import { Student } from 'src/app/Models/Student';
import { StudentCourse } from 'src/app/Models/StudentCourse';
import { StudentCourseVM } from 'src/app/Models/student-course-vm';
import { StudentDetailsHttpService } from '../../student/services/student-srv';
import { Course } from 'src/app/Models/Course';

@Component({
  selector: 'app-add-student-course',
  templateUrl: './add-student-course.component.html',
  styleUrls: ['./add-student-course.component.scss']
})
export class AddStudentCourseComponent implements OnInit {
  studentCourseVM: StudentCourseVM = { students: [], courses: [] };
  studentCourseForm: FormGroup;
  constructor(private http: StudentCourseHttpService, private _fb: FormBuilder,
    private _avRoute: ActivatedRoute, private alertSrv: AlertService,
    private studentSrv: StudentDetailsHttpService, private router: Router) {
    this.studentCourseForm = this._fb.group({
      studentCourseId: 0,
      studentId: ['', [Validators.required]],
      courseId: ['', [Validators.required]],
      obtainedCreditHours: ['', [Validators.required]]
    });
    let paramData = this._avRoute.snapshot.params['id'];
    if (paramData && paramData != "0") {
      this.StudentId.setValue(this._avRoute.snapshot.params['id']);
      this.GetStudentCourseById(this.StudentId.value);
    }
  }
  ngOnInit(): void {
    this.loadCourses();
    this.loadStudents();
  }
  loadStudents() {
    this.studentSrv.getStudents().subscribe((data: Student[]) => {
      this.studentCourseVM.students = data;
    });
  }
  loadCourses() {
    this.http.getCourses().subscribe((data: Course[]) => {
      this.studentCourseVM.courses = data;
    });
  }
  GetStudentCourseById(studentId: number) {
    this.http.getStudenCourseById(studentId).subscribe((data: StudentCourse) => {
      this.studentCourseForm.patchValue(data);
    })
  }
  onSubmit(form: NgForm) {
    if (form.invalid) return;
    let data = this.mapFormValues(this.studentCourseForm.value);
    if (this.StudentCourseId.value == 0) {
      this.http.postStudentCourse(data).subscribe((data: StudentCourse) => {
        this.alertSrv.alertSuccess("Record Saved Successfully!");
        this.redirectToListing();
      }, (error: any) => {
        this.alertSrv.alertError("Error ! " + error.error);
      });
    } else {
      this.http.updateStudentCourse(data, data.studentCourseId).subscribe((data: StudentCourse) => {
        this.alertSrv.alertSuccess("Record Updated Successfully!");
        this.redirectToListing();
      }, (error: any) => {
        this.alertSrv.alertError("Error ! " + error.error);
      });
    }
  }
  redirectToListing() {
    setTimeout(() => {
      this.router.navigate(['/master/student-course']);
    }, 2000);
  }
  checkIfValid() {
    if (!this.ObtainedCreditHours.value) return;
    if (this.studentCourseVM.courses.length == 0 || !this.CourseId.value) return;
    if (this.studentCourseVM.courses.filter(m => m.courseId == this.CourseId.value)[0]?.creditHours
      < parseFloat(this.ObtainedCreditHours.value)
    ) {
      this.ObtainedCreditHours.setValue(0);
      this.alertSrv.alertError("Obtained Credit Hours can not be greater than total credit hours of course.");
    }
    if (this.ObtainedCreditHours.value < 0) this.ObtainedCreditHours.setValue(0);
  }
  mapFormValues(formData: StudentCourse) {
    return { ...formData, studentId: parseInt(formData.studentId.toString()), courseId: parseInt(formData.courseId.toString()) };
  }
  get StudentCourseId() { return this.studentCourseForm.get('studentCourseId'); }
  get CourseId() { return this.studentCourseForm.get('courseId'); }
  get ObtainedCreditHours() { return this.studentCourseForm.get('obtainedCreditHours'); }
  get StudentId() { return this.studentCourseForm.get('studentId'); }
}
