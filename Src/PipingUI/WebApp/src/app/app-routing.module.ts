import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'auth', loadChildren: () => import('./modules/auth/auth.module').then(m => m.AuthModule) },
  { path: 'pipe-master', loadChildren: () => import('./modules/pipe-master/pipe-master.module').then(m => m.PipeMasterModule) },
  { path: '', pathMatch: 'full', redirectTo: '/auth/login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
