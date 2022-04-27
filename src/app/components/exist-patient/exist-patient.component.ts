import { Patient } from 'src/app/interfaces/patient';
import { Component, OnInit, AfterViewInit, OnDestroy, OnChanges, SimpleChanges } from '@angular/core';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-exist-patient',
  templateUrl: './exist-patient.component.html',
  styleUrls: ['./exist-patient.component.css']
})
export class ExistPatientComponent implements OnInit {

  p:Patient={};
  hist:any;
  error:any;
  error2:any;
  fullnamevalid:boolean=false;
  arr:any;
  constructor(private patient:PatientService) {
  }

  ngOnInit() {

    if(localStorage.getItem("mnumber")!=null){
      this.patient.getPatientByMilitaryNumber(localStorage.getItem("mnumber")).subscribe(res=>{
        this.p=res


      },err=>{
        this.error=err;
      });
    }
    else if(localStorage.getItem("nationalID")!=null){
      this.patient.getPatientByNationalID(localStorage.getItem("nationalID")).subscribe(res=>{

        this.p=res
      },err=>{
        this.error=err;
      });
    }

    else if((localStorage.getItem("nationalID")==null && localStorage.getItem("mnumber")==null) &&(localStorage.getItem("fname")!=null && localStorage.getItem("mname")!=null && localStorage.getItem("mname2")!=null && localStorage.getItem("lname")!=null) ){
      this.patient.getPatientByName(localStorage.getItem("fname"),localStorage.getItem("mname"),localStorage.getItem("mname2"),localStorage.getItem("lname")).subscribe(res=>{

        console.log("res",res);
        this.p=res
        this.arr=res;
        this.error2=res;
        if(this.error2.length==0){
          this.fullnamevalid=true;
          console.log("err", this.error2);
        }

        if(this.arr.length >=1){
          this.p=this.arr[0];
        }
      },err=>{
        console.log(err);
        this.error=err;
      });

    }
  }

  bookClinic(){

    localStorage.setItem("patientID", JSON.stringify(this.p.id));
    this.patient.PostPatient(this.p).subscribe(res=>this.p=res);
  }
  history(){
    this.patient.getPatientHistories(this.p.id).subscribe(res=>{
      this.hist=res;
    })
  }
}
