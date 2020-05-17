import { LoaderInterceptor } from './_shared/interceptors/loader.interceptor';
import { LoaderService } from './_shared/services/loader.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ContactComponent } from './contact/contact.component';

@NgModule({
   declarations: [
      AppComponent,
      LoginComponent,
      RegisterComponent,
      DashboardComponent,
      ContactComponent
   ],
   imports: [
      BrowserModule,
      NgbModule,
      FormsModule,
      RouterModule
   ],
   providers: [
     LoaderService,
     {
       provide: HTTP_INTERCEPTORS,
       useClass: LoaderInterceptor,
       multi: true
     }
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
