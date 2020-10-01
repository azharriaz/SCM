import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { User } from "src/app/Models/User";
import { HttpService } from "src/app/Services/http-service.service";
import { LoginService } from "src/app/Services/login.service";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { debounceTime } from "rxjs/operators";
import { Student } from "src/app/Models/Student";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent implements OnInit {
  Username: string;
  Password: string;
  returnUrl: string;
  registerForm: FormGroup;
  User: User = new User();
  submitted = false;
  btnText = "Sign in";
  Students: Array<Student> = [];

  constructor(
    private httpClint: HttpClient,
    private http: HttpService,
    public router: Router,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private loginService: LoginService
  ) {
    this.loginService.logout();
  }

  ngOnInit() {
    // for (let i = 0; i < 100; i++) {
    //   this.Students.push({
    //     Id: i++,
    //     Name: "Student" + i,
    //     RollNo: "R" + i,
    //     Phone: "+93232",
    //   } as Student);
    // }

    console.log(this.Students);
    this.returnUrl = this.route.snapshot.queryParams["returnUrl"] || "/medical";

    this.registerForm = this.formBuilder.group({
      Username: ["", Validators.required],
      Password: ["", [Validators.required, Validators.minLength(3)]],
    });
  }

  get f() {
    return this.registerForm.controls;
  }

  Login() {
    if (this.registerForm.invalid) {
      this.submitted = true;
      return;
    }

    this.http.loading(true);
    this.btnText = "Please Wait";

    this.httpClint
      .post<any>(
        `${environment.StudentCoursesBaseURL}/hs/Auth/login?username=${this.f.Username.value}&password=${this.f.Password.value}`,
        null
      )
      .subscribe(
        (res) => {
          if (res != null) {
            this.User.UserId = 1;
            this.User.Username = this.f.Username.value;
            this.User.FirstName = "Dr. Rizwan";
            this.User.LastName = "Gohar";
            this.loginService.login(this.f.Username.value, res);
            this.http.loading(false);

            this.router.navigate([this.returnUrl]);
          } else {
            this.http.alertError("Username or password wrong.");
            this.btnText = "Sign in";
          }
        },
        (err) => {
          this.http.loading(false);
          console.log(err);
          this.btnText = "Sign in";
        }
      );
  }
}
