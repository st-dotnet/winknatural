import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { BlogComponent } from './blog/blog.component';
import { AppLayoutComponent } from './components/layout/app-layout/app-layout.component';
import { ShopComponent } from './shop/shop.component';

const homeModule = () => import('./components/home/home.module').then(x => x.HomeModule);
const authModule = () => import('./components/auth/auth.module').then(x => x.AuthModule);


const routes: Routes = [
  {
    path: '',
    component: AppLayoutComponent,
    children: [
      { path: '', loadChildren: homeModule },
      { path: 'auth', loadChildren: authModule },

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
