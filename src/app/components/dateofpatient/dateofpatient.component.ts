import { Patient } from './../../interfaces/patient';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from './../../services/patient.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dateofpatient',
  templateUrl: './dateofpatient.component.html',
  styleUrls: ['./dateofpatient.component.css']
})
export class DateofpatientComponent implements OnInit {
  constructor(private patient :PatientService,private activateRoute:ActivatedRoute) { }

  patientID:any;
  p:Patient={};
  arr:any;
  ngOnInit(): void {

    this.patientID=this.activateRoute.snapshot.queryParams["patientid"];
    this.patient.getPatientHistories(this.patientID).subscribe(res=>{
      this.p=res;
      this.arr=this.p;
    })
  }

}
