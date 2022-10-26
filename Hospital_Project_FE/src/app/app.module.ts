import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { JwtModule } from "@auth0/angular-jwt";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { NewAppointmentComponent } from './new-appointment/new-appointment.component';
import { MyAppointmentComponent } from './my-appointment/my-appointment.component';
import { AppointmentsComponent } from './appointments/appointments.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CalendarModule, DatePickerModule, TimePickerModule, DateRangePickerModule, DateTimePickerModule,MaskedDateTimeService } from '@syncfusion/ej2-angular-calendars';
import { PatientComponent } from './patient/patient.component';
import { MyRecordsComponent } from './my-records/my-records.component';
import { NewPatientComponent } from './new-patient/new-patient.component';
import { AuthIntercepterService } from './Auth/auth-intercepter.service';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegisterComponent,
    LoginComponent,
    NewAppointmentComponent,
    MyAppointmentComponent,
    AppointmentsComponent,
    PatientComponent,
    MyRecordsComponent,
    NewPatientComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,ReactiveFormsModule,
    BrowserAnimationsModule,
    CalendarModule, DatePickerModule, TimePickerModule, DateRangePickerModule, DateTimePickerModule,
    JwtModule.forRoot({
      config:{
        tokenGetter: tokenGetter    
      }   
    })
  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS,
      useClass:AuthIntercepterService,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
