import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Shared/login/login.component';



const routes: Routes = [ 
  
 
  {
    path: 'master',
    loadChildren: () => import('./master/master.module').then(m => m.MasterModule)
  },

  {
    path: '',
    redirectTo: '/master/students',
    pathMatch: 'full',
    
  },
 
  {
    path: '**', redirectTo: '/master/students',
    
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: "reload"})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
