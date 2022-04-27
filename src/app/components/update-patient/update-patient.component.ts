import { ActivatedRoute, Router } from '@angular/router';
import { PatientService } from 'src/app/services/patient.service';
import { Patient } from './../../interfaces/patient';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-update-patient',
  templateUrl: './update-patient.component.html',
  styleUrls: ['./update-patient.component.css']
})
export class UpdatePatientComponent implements OnInit {
  username:any="";
  patientID:any;

  returnedPatient:Patient={};
  constructor(private Patient:PatientService,private activatedRoute:ActivatedRoute,private router:Router) { }


  ranking:any=""
  ranked:any=""


  ngOnInit(): void {
    this.patientID=this.activatedRoute.snapshot.queryParams["patientid"];
    this.username=localStorage.getItem("username");
    this.Patient.getPatientByid(this.patientID).subscribe(res=>{
      this.returnedPatient=res
      console.log(res)
      this.ranking=this.returnedPatient.rank

      if(this.ranking.includes("ضابط صف")){
        this.ranked=this.ranking.split(' ')[0]+" "+this.ranking.split(' ')[1]

        if((this.ranking.split(' ')[2]+" "+this.ranking.split(' ')[3]).includes(" ")&&this.ranking.split(' ')[3]!=undefined)
          this.ranking=this.ranking.split(' ')[2]+" "+this.ranking.split(' ')[3]
        else
          this.ranking=this.ranking.split(' ')[2]

      }else if((this.ranking.split(' ')[1]+" "+this.ranking.split(' ')[2]).includes('ملازم اول')){
        this.ranked=this.ranking.split(' ')[0]
        this.ranking=this.ranking.split(' ')[1]+" "+this.ranking.split(' ')[2]
      }
      else{
        this.ranked=this.ranking.split(' ')[0]
        this.ranking=this.ranking.split(' ')[1]
      }
    });
  }

  update(){
    this.returnedPatient.age=Number(this.returnedPatient.age)
    this.returnedPatient.militaryNumber=Number(this.returnedPatient.militaryNumber)
    this.returnedPatient.nationalId=Number(this.returnedPatient.nationalId)
    this.returnedPatient.receptionestId=Number(localStorage.getItem("respID"));
    this.returnedPatient.rank=this.ranked+" "+this.ranking
    this.Patient.editPatient(this.patientID,this.returnedPatient).subscribe(res=>{
      this.hide=false
      setTimeout(() => {
        this.hide=true
        this.router.navigate(["/reception"]);
      }, 1000);
    })
  }

  hide:boolean=true
  ahmed(e:any){
    this.ranked=e.target.value
  }
}
