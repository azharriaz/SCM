import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  
  constructor(private loginService: LoginService, private router: Router) { }

  ngOnInit() {
  }



  logout() {
    this.loginService.logout();
    this.router.navigate(['/login']);
  }

}
