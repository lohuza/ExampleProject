import { ContactComponent } from './contact/contact.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { Routes } from '@angular/router';
import { AuthGuard } from './_shared/guards/auth.guard';

export const AppRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: '/dashboard', component: DashboardComponent },
      { path: '/contact/:id', component: ContactComponent },
    ]
  }
];
