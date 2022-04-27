import { AdminsService } from './../../../services/admin/admins.service';
import { Component, OnInit } from '@angular/core';
import { Doctor } from 'src/app/interfaces/doctor';
import { Patient } from 'src/app/interfaces/patient';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-exist-doctor',
  templateUrl: './exist-doctor.component.html',
  styleUrls: ['./exist-doctor.component.css']
})
export class ExistDoctorComponent implements OnInit {

  doctor:Doctor={};
  hist:any;
  error:any;
  error2:any;
  fullnamevalid:boolean=false;
  arr:any;
  constructor(private admin:AdminsService) {
  }

  ngOnInit() {

    if(localStorage.getItem("mnumber")!=null){
      this.admin.getDoctorByMilitaryNumber(localStorage.getItem("mnumber")).subscribe(res=>{
        console.log(res);

        this.doctor=res


      },err=>{
        this.error=err;
      });
    }
    else if(localStorage.getItem("nationalID")!=null){
      this.admin.getDoctorByNationalID(localStorage.getItem("nationalID")).subscribe(res=>{

        this.doctor=res
      },err=>{
        this.error=err;
      });
    }

    else if((localStorage.getItem("nationalID")==null && localStorage.getItem("mnumber")==null) &&(localStorage.getItem("fname")!=null && localStorage.getItem("mname")!=null && localStorage.getItem("mname2")!=null && localStorage.getItem("lname")!=null) ){
      this.admin.getDoctorByName(localStorage.getItem("fname"),localStorage.getItem("mname"),localStorage.getItem("mname2"),localStorage.getItem("lname")).subscribe(res=>{

        this.doctor=res

        this.arr=res;
        this.error2=res;
        if(this.error2.length==0){
          this.fullnamevalid=true;
          console.log("err", this.error2);
        }

        if(this.arr.length >=1) {
          this.doctor=this.arr[0];
        }
      },err=>{
        console.log(err);
        this.error=err;
      });

    }
  }

}
