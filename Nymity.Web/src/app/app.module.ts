import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Directive } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { Routing } from './app.routing';

import { AuthGuard } from './core/auth.guard';
import { AuthService } from './core/service/auth.service';
import { AlertService } from './core/service/alert.service';
import { ProductService } from './product/product.service';

import { ButtonModule, MessagesModule, MenubarModule, ConfirmDialogModule } from 'primeng/primeng';
import {TableModule} from 'primeng/table';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { ProductComponent } from './product/product.component';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';

@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        LoginComponent,
        HomeComponent,
        ProductComponent,
        ProductDetailComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
        Routing,
        ButtonModule,
        MessagesModule,
        MenubarModule,
        ConfirmDialogModule,
        TableModule
    ],
    providers: [AuthGuard, AuthService, AlertService, ProductService],
    bootstrap: [AppComponent]
})
export class AppModule { }
