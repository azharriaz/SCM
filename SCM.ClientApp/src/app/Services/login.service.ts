import { Injectable } from '@angular/core';
import { User } from '../Models/User';
import { BehaviorSubject, Observable } from 'rxjs';
import { GlobalService } from './global.service';




@Injectable({providedIn: 'root'})
export class LoginService{
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  User:User=new User();

  constructor(private globalService: GlobalService) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(sessionStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
}

public get currentUserValue(): User {
  return this.currentUserSubject.value;
}

login(username: string, token: string) {
  
   this.User.UserId=1;
    this.User.Username=username ;
    this.User.FirstName='Dr. Rizwan';
    this.User.LastName='Gohar' ;
    sessionStorage.setItem('currentUser', JSON.stringify(this.User));
    sessionStorage.setItem('token', token);
    this.currentUserSubject.next(this.User);

}


logout() {
  sessionStorage.removeItem('currentUser');
  sessionStorage.removeItem('token');
  this.currentUserSubject.next(null);
}

}
