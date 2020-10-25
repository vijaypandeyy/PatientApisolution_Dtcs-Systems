import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Patient } from 'src/shared/models/patient.model';
import { PatientService } from 'src/shared/patient.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'PatientUI';
  // FilteredPatients: Observable<Patient[]> ;
  FilteredPatients: Patient[];
  constructor(private patientService: PatientService) { }

  FetchData(filter: Patient) {
    //this.FilteredPatients= this.patientService.GetPatientsWithFilter(filter).subscribe();
    this.patientService.GetPatientsWithFilter(filter).subscribe((res: any) => {
      this.FilteredPatients = res

    }, (err) => {
      alert(JSON.stringify(err));
    });
  }

  SaveData(data: Patient) {
    this.patientService.SavePatient(data).subscribe(
      (res) => res, (err) => alert(JSON.stringify(err)));
  }

}
