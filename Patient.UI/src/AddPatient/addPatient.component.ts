import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Patient, SimpleObject } from 'src/shared/models/patient.model';
import { FormGroup, FormControl, FormBuilder, Validators, AbstractControl, ValidatorFn } from '@angular/forms';
import { JsonPipe } from '@angular/common';
import { min } from 'rxjs/operators';
import { PatientService } from 'src/shared/patient.service';
import { Observable } from 'rxjs';


@Component({
    selector: 'add-patient',
    templateUrl: './addPatient.component.html',
    styleUrls: ['./addPatient.component.css']
})
export class AddPatientComponent implements OnInit {

    model: Patient = new Patient();
    @Output() onFetchEvent = new EventEmitter<Patient>();
    @Output() onSaveEvent = new EventEmitter<Patient>();

    patientForm: FormGroup;
    States: Observable<SimpleObject[]>;
    Cities: Observable<SimpleObject[]>;

    constructor(private fb: FormBuilder, private service: PatientService) {

    }

    ngOnInit() {

        this.States = this.service.GetState();


        this.patientForm = this.fb.group({
            Name: ['', Validators.pattern('^[a-zA-Z ]*$')],
            SurName: ['', Validators.pattern('^[a-zA-Z ]*$')],
            Gender: [''],
            DOB: ['', dateValidation],
            stateid: [''],
            Cityid: ['']
        });

    }
    onFetch() {
        this.onFetchEvent.emit(this.patientForm.value);
    }

    onSave() {
        if (this.patientForm.valid) {

            this.onSaveEvent.emit(this.patientForm.value);
        }


    }
    get diagnostic() { return JSON.stringify(this.patientForm.value); }

    onOptionsSelected(value: any) {

        this.Cities = this.service.GetCities(value);
    }


}

function dateValidation(control: AbstractControl): { [key: string]: boolean } | null {
    let currentDob = new Date(control.value);
    let todayDate = new Date();
    var year = todayDate.getFullYear();
    var month = todayDate.getMonth();

    var c = new Date(year - 100, month);

    if (currentDob < c || currentDob > todayDate) {
        return { 'DateValidation': true };
    }
    return null;
}

// const MyAwesomeRangeValidator: ValidatorFn = (fg: FormGroup) => {

// };