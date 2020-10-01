import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { HeaderComponent } from '../header/header.component';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { MainWrapperComponent } from '../main-wrapper/main-wrapper.component';
import {  RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';




@NgModule({
  declarations: [
    HeaderComponent,
    SidebarComponent,
    MainWrapperComponent,
    LayoutComponent],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule,
    HeaderComponent,
    SidebarComponent,
    MainWrapperComponent,
    
  ],
  providers: [
  //  { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
})
export class LayoutModule { }
