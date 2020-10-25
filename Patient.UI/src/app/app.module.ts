import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ListPatientComponent } from 'src/ListPatients/listPatient.component';
import { AddPatientComponent } from 'src/AddPatient/addPatient.component';

@NgModule({
  declarations: [
    AppComponent, AddPatientComponent, ListPatientComponent
  ],
  imports: [
    BrowserModule, ReactiveFormsModule, HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
