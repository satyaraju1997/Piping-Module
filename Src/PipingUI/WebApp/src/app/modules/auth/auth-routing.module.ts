import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './login/login.component';
import { ForgotPasswordComponent } from './login/forgot-password/forgot-password.component';

const routes: Routes = [
    {
        path: '',
        component: AuthComponent,
        children: [
            {
                path: 'login',
                component: LoginComponent,
            },
            {
                path: 'forgot-password',
                component: ForgotPasswordComponent,
            }
        ],
    },
];


@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})

export class AuthRoutingModule {
    static components = [
        LoginComponent,
        ForgotPasswordComponent        
    ];

}
