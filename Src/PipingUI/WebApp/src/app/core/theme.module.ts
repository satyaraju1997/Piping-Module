
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { MaterialModule } from './material.module';

import { HeaderComponent } from './layout/header/header.component';
import { LayoutComponent } from './layout/layout/layout.component';
import { SideNavComponent } from './layout/side-nav/side-nav.component';
import { SideNav2Component } from './layout/side-nav/side-nav2/side-nav2.component';
import { SideNav3Component } from './layout/side-nav/side-nav3/side-nav3.component';


const BASE_MODULES = [CommonModule, FormsModule, ReactiveFormsModule];
const COMPONENTS = [HeaderComponent, LayoutComponent, SideNavComponent, SideNav2Component, SideNav3Component];

@NgModule({
    imports: [
        MaterialModule,
        BASE_MODULES,
        RouterModule
    ],
    exports: [ 
        MaterialModule,
        BASE_MODULES,
        COMPONENTS
    ],
    declarations: [COMPONENTS],
})
export class ThemeModule {
}
