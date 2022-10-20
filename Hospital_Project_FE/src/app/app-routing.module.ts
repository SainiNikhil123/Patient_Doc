import { PatientComponent } from './patient/patient.component';
import { AppointmentsComponent } from './appointments/appointments.component';

import { RegisterComponent } from './register/register.component';
import { UserComponent } from './user/user.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { MyAppointmentComponent } from './my-appointment/my-appointment.component';
import { NewAppointmentComponent } from './new-appointment/new-appointment.component';

const routes: Routes = [
  {path:'user',component:UserComponent},
  {path:'register',component:RegisterComponent},
  {path:'login',component:LoginComponent},
  {path:'appointment',component:AppointmentsComponent},
  {path:'myappointment',component:MyAppointmentComponent},
  {path:'newappointment',component:NewAppointmentComponent},
  {path:'patient',component:PatientComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
