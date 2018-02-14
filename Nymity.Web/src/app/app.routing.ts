import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './core/auth.guard';
import { HomeComponent } from './home/home.component';
import { ProductComponent } from './product/product.component';
import { LoginComponent } from './login/login.component';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';

const appRoutes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    //{ path: 'product', component: ProductComponent, canActivate: [AuthGuard] },
    { path: 'product', component: ProductComponent, children: [
        { path: ':id/edit', component: ProductDetailComponent }
    ]},
    { path: 'login', component: LoginComponent },
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);