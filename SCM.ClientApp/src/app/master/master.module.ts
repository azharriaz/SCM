import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MasterRoutingModule } from './master-routing.module';
import { LayoutModule } from '../Shared/layout/layout.module';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { StudentsComponent } from './student/studens/students.component';
import { AddStudentComponent } from './student/add-student/add-student.component';
import { StudentCourseRecordsComponent } from './student-courses/student-course-records/student-course-records.component';
import { AddStudentCourseComponent } from './student-courses/add-student-course/add-student-course.component';
import { StudentResultComponent } from './result/student-result/student-result.component';
@NgModule({
  declarations: [
    StudentsComponent,
    AddStudentComponent,
    StudentCourseRecordsComponent,
    AddStudentCourseComponent,
    StudentResultComponent,
  ],
  imports: [
    CommonModule,
    LayoutModule,
    MasterRoutingModule,
    NgbModule,

  ]
})
export class MasterModule { }
