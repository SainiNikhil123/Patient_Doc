import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { NewAppointmentComponent } from './new-appointment/new-appointment.component';
import { MyAppointmentComponent } from './my-appointment/my-appointment.component';
import { AppointmentsComponent } from './appointments/appointments.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CalendarModule, DatePickerModule, TimePickerModule, DateRangePickerModule, DateTimePickerModule,MaskedDateTimeService } from '@syncfusion/ej2-angular-calendars';
import { PatientComponent } from './patient/patient.component';


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
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    CalendarModule, DatePickerModule, TimePickerModule, DateRangePickerModule, DateTimePickerModule,
  ],
  providers: [MaskedDateTimeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
