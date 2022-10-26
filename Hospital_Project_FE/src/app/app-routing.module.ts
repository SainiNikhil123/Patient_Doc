import { AppComponent } from './app.component';
import { NewPatientComponent } from './new-patient/new-patient.component';
import { MyRecordsComponent } from './my-records/my-records.component';
import { PatientComponent } from './patient/patient.component';
import { AppointmentsComponent } from './appointments/appointments.component';

import { RegisterComponent } from './register/register.component';
import { UserComponent } from './user/user.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { MyAppointmentComponent } from './my-appointment/my-appointment.component';
import { NewAppointmentComponent } from './new-appointment/new-appointment.component';
import { AuthGardService } from './Auth/auth-gard.service';

const routes: Routes = [
  //{path:'',component:AppComponent},
  {path:'user',component:UserComponent,canActivate:[AuthGardService]},
  {path:'register',component:RegisterComponent},
  {path:'login',component:LoginComponent},
  {path:'appointment',component:AppointmentsComponent,canActivate:[AuthGardService]},
  {path:'myappointment',component:MyAppointmentComponent,canActivate:[AuthGardService]},
  {path:'newappointment',component:NewAppointmentComponent,canActivate:[AuthGardService]},
  {path:'patient',component:PatientComponent,canActivate:[AuthGardService]},
  {path:'myrecords',component:MyRecordsComponent,canActivate:[AuthGardService]},
  {path:'newpatient',component:NewPatientComponent,canActivate:[AuthGardService]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
