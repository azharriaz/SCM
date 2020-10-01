import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { LayoutComponent } from "../Shared/layout/layout.component";
import { AddStudentComponent } from './student/add-student/add-student.component';
import { StudentsComponent } from './student/studens/students.component';
import { StudentCourseRecordsComponent } from './student-courses/student-course-records/student-course-records.component';
import { AddStudentCourseComponent } from './student-courses/add-student-course/add-student-course.component';





const routes: Routes = [
  {
    path: "",
    component: LayoutComponent,
    children: [
      { path: "", component: StudentsComponent },

      {
        path: "students",
        component: StudentsComponent,
      },
      {
        path: "addStudent/:id",
        component: AddStudentComponent,
      },
      {
        path: "student-course",
        component: StudentCourseRecordsComponent,
      },
      {
        path: "add-student-course/:id",
        component: AddStudentCourseComponent,
      },
     
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MasterRoutingModule {}
