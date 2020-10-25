import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Patient, SimpleObject } from './models/patient.model';
@Injectable({
    providedIn: 'root',
})
export class PatientService {
    baseUrl: string = "http://localhost:5000/"

    constructor(private http: HttpClient) { }

    public GetPatients() {
        return this.http.get<Patient[]>(this.baseUrl + "api/Patients?$Select=name,surName,gender,dob");

    }

    public GetPatientsWithFilter(patient: Patient) {
        var filter: string = '';
        if (patient.Name) {
            filter = `&$filter=name eq '${patient.Name}'`;

        }
        return this.http.get<Patient[]>(`${this.baseUrl}api/Patients?$Select=name,surName,gender,dob${filter}`);

    }

    public GetState() {
        return this.http.get<SimpleObject[]>(this.baseUrl + "api/Values/States?$Select=id,name");
    }

    public GetCities(id: any) {
        return this.http.get<SimpleObject[]>(`${this.baseUrl}api/Values/Cities?$Select=id,name&$Filter=StateId eq ${id}`);
    }

    public SavePatient(data: Patient) {
        return this.http.post(this.baseUrl + "api/Patients", data);
    }


}