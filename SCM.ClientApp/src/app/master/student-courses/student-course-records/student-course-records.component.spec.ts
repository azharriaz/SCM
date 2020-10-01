import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentCourseRecordsComponent } from './student-course-records.component';

describe('StudentCourseRecordsComponent', () => {
  let component: StudentCourseRecordsComponent;
  let fixture: ComponentFixture<StudentCourseRecordsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentCourseRecordsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentCourseRecordsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
