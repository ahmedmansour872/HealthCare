import { Router } from '@angular/router';
import { PatientDetails } from './../../interfaces/patient-details';
import { PatientService } from './../../services/patient.service';
import { Component, OnInit } from '@angular/core';
import { Patient } from 'src/app/interfaces/patient';
import { PharmacistService } from 'src/app/services/pharmacist.service';
import { identifierName } from '@angular/compiler';

@Component({
  selector: 'app-pharmacy',
  templateUrl: './pharmacy.component.html',
  styleUrls: ['./pharmacy.component.css']
})
export class PharmacyComponent implements OnInit {


  username:any="";
  fname:any;
  mname:any;
  mname2:any;
  lname:any;
  mnumber:any;
  nationalID:any;
  searchedPatient:Patient={};
  temp:any=[];
  fullname:any;
  ranked:any="";
  err:any;
  x:boolean=false;
  phDetails:PatientDetails={};
  constructor(private p:PatientService,private ph:PharmacistService ,private router:Router) { }

  ngOnInit(): void {


    this.username=localStorage.getItem("phName");

  }



  search(f:any){

    localStorage.removeItem("mnumber");
    localStorage.removeItem("nationalID");
    // localStorage.removeItem("fname");
    // localStorage.removeItem("mname");
    // localStorage.removeItem("mname2");
    // localStorage.removeItem("lname");

    if(this.mnumber){
      localStorage.setItem("mnumber",this.mnumber)
      this.ph.getPatientDetailsByMilitaryNumber(this.mnumber).subscribe(res=>{

        console.log(res);
        this.phDetails=res;
        this.temp=this.phDetails;
        this.ranked=this.temp.rank;
      }
        ,error=>{
          if(error.status==400){
            this.err="done"
          }
          else{
            this.err="not found"
          }

        })
    }
    else if(this.nationalID){
      localStorage.setItem("nationalID",this.nationalID)
      this.ph.getPatientDetailsByNationalID(this.nationalID).subscribe(res=>{
        this.phDetails=res;

        this.temp=this.phDetails;
        this.ranked=this.temp.rank;




      },error=>{
        if(error.status==400){
          this.err="done"
        }
        else{
          this.err="not found"
        }
      })
    }

    else if((!this.nationalID && !this.mnumber) &&(this.fname&&this.mname&&this.mname2&& this.lname) ){
    // localStorage.setItem("fname",this.fname)
    // localStorage.setItem("mname",this.mname)
    // localStorage.setItem("mname2",this.mname2)
    // localStorage.setItem("lname",this.lname)

      this.ph.getPatientDetailsByName(this.fname,this.mname,this.mname2,this.lname).subscribe(res=>{

        this.phDetails=res;

            this.temp=res;
            if(this.temp.length===0){

              this.x=true;
            }




      this.ranked=this.temp.rank;

      this.searchedPatient=this.temp[0]



    },
    error=>{
      if(error.status==400){
        this.err="done"
      }
      else{
        this.err="not found"
      }
    }
  )

    }






}


doneDrug(){

  console.log(this.phDetails.patientID)
  this.ph.done(this.phDetails.patientID).subscribe(res=>{

    this.router.navigate(["/Drug"]);
  })
}


}
