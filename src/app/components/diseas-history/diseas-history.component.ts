import { Patient } from './../../interfaces/patient';
import { PatientService } from 'src/app/services/patient.service';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { concat } from 'rxjs';

@Component({
  selector: 'app-diseas-history',
  templateUrl: './diseas-history.component.html',
  styleUrls: ['./diseas-history.component.css']
})
export class DiseasHistoryComponent implements OnInit {

  patientID:any;
   patient:Patient={};
   fullname:any;
   history:any;
   history2:any[][]=[];
  constructor(private activatedRoute:ActivatedRoute,private p:PatientService) { }
  ngOnInit(): void {
  //  this.patientID= this.activatedRoute.paramMap.subscribe(res=>this.patientID=res.get("patientid"))

  this.patientID=this.activatedRoute.snapshot.queryParams["patientid"];
    this.p.getPatientByid(this.patientID).subscribe(res=>{

      console.log(res);
      this.patient=res;
      this.fullname=this.patient.fname + ' ' + this.patient.mname+ ' ' +this.patient.mname2+' '+this.patient.lname;

    });


    this.p.getPatientHistories(this.patientID).subscribe(res=>{
      this.history=res;
      this.history2=this.history;
    })





  }

}
