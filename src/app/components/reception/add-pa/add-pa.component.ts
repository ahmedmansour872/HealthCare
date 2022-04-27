import { ActivatedRoute, Router } from '@angular/router';
import { PatientService } from './../../../services/patient.service';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Patient } from 'src/app/interfaces/patient';
import { last } from 'rxjs';

@Component({
  selector: 'app-add-pa',
  templateUrl: './add-pa.component.html',
  styleUrls: ['./add-pa.component.css']
})
export class AddPaComponent implements OnInit {
  p:Patient={};
  username:any="";
  returnedPatient:Patient={};
  reurnedNumber:any;
  error:any;
  constructor(private patient:PatientService ,private activedRoute:ActivatedRoute,private router:Router) {

  }


  ngOnInit(): void {
    this.username=localStorage.getItem("username");
  }

  submit(fname:any,mname:any,mname2:any,lname:any,militaryNumber:any,nationalID:any,age:any,nationality:any,religion:any,rank:any,rank1:any,gender:any){
    this.p.fname=fname.value
    this.p.mname=mname.value
    this.p.mname2=mname2.value
    this.p.lname=lname.value
    this.p.militaryNumber=Number(militaryNumber.value);
    this.p.nationalId=Number(nationalID.value)
    this.p.age=Number(age.value)
    this.p.nationality=nationality.value
    this.p.religion=religion.value

    if(rank.value=='ضابط' || rank.value=='ضابط صف' )
      this.p.rank=rank.value+" "+rank1.value
    else
      this.p.rank=rank.value

    this.p.gender=gender.value
    this.p.reserved=false;
    this.p.receptionestId= Number(localStorage.getItem("respID"));

    this.patient.PostPatient(this.p).subscribe((res:Patient)=>{
      localStorage.setItem("patientID",JSON.stringify(res.id));
      this.router.navigateByUrl("/clinics")
    },(err)=>{
      if(err.status==400){
        this.error="exist"
      }

    });
  }

  ranking:any=""
  ahmed(e:any){
    this.ranking=e.target.value
  }

}
