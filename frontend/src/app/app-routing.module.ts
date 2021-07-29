import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppLayoutComponent } from './components/layout/app-layout/app-layout.component';
import { AuthGuard } from './_helpers';

const homeModule = () => import('./components/home/home.module').then(x => x.HomeModule);
const authModule = () => import('./components/auth/auth.module').then(x => x.AuthModule);


const routes: Routes = [
  {
    path: '',
    component: AppLayoutComponent,
    children: [
      // { path: '', loadChildren: homeModule, canActivate: [AuthGuard] },
      { path: '', loadChildren: homeModule},
      { path: '', loadChildren: authModule },
      // otherwise redirect on the basis of authentication
      { path: '**', redirectTo: '' }
    ]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],

})
export class AppRoutingModule { }
