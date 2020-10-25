import { Component, OnInit, Input } from '@angular/core';
import { Patient } from 'src/shared/models/patient.model';
import { PatientService } from 'src/shared/patient.service';

@Component({
    selector: 'list-patient',
    templateUrl: './listPatient.component.html',
    styleUrls: ['./listPatient.component.css']
})
export class ListPatientComponent implements OnInit {
    @Input() patients: Patient[];

    constructor(private patientService: PatientService) {

    }

    ngOnInit() {
        this.patientService.GetPatients().subscribe((res: any) => {
            this.patients = res
        }, (err) => {
            alert(JSON.stringify(err));
        })
    }



}