import { Component } from '@angular/core';
import {Router, Event, NavigationStart, NavigationEnd, NavigationError } from '@angular/router';
import { LoginService } from './Services/login.service';
import { User } from './Models/User';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
 
})
export class AppComponent {
  IsLoginPage:boolean;
  currentUser: User;
  currentUserSubscription: Subscription;
    constructor( private router: Router, private loginService: LoginService) {


      this.currentUserSubscription = this.loginService.currentUser.subscribe(user => {
        this.currentUser = user;
        this.IsLoginPage=(this.currentUser!=null)?true:false;
      });

      this.router.events.subscribe((evt) => {
        if (!(evt instanceof NavigationEnd)) {
          return;
        }
        window.scrollTo(0, 0)
      });


    //   router.events.subscribe( (event: Event) => {

    //     if (event instanceof NavigationStart) {
    //     }
        

    //     if (event instanceof NavigationEnd) {
    //      this.IsLoginPage=(event. url.toLowerCase().includes('/login'))?true:false;
    //     }

    //     if (event instanceof NavigationError) {
          
    //         console.log(event.error);
    //     }
    // });
     }

     
  title = 'Lifeline';

  ngOnDestroy() {
    this.currentUserSubscription.unsubscribe();
}
  
}
