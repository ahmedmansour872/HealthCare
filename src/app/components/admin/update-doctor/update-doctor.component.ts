import { AdminsService } from './../../../services/admin/admins.service';
import { DoctorService } from './../../../services/doctors/doctor.service';
import { Doctor } from './../../../interfaces/doctor';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-doctor',
  templateUrl: './update-doctor.component.html',
  styleUrls: ['./update-doctor.component.css']
})
export class UpdateDoctorComponent implements OnInit {

  username:any="";
  doctorID:any;

  returnedDoctor:Doctor={};
  constructor(private doctor:DoctorService,private activatedRoute:ActivatedRoute,private router:Router,private admin:AdminsService) { }


  ranking:any=""
  ranked:any=""


  ngOnInit(): void {
    this.doctorID=this.activatedRoute.snapshot.queryParams["doctorid"];

    console.log(this.doctorID);
    this.username=localStorage.getItem("username");
    this.admin.getDoctorByid(this.doctorID).subscribe(res=>{
      this.returnedDoctor=res
      console.log(res)

    });
  }

  update(){
    this.returnedDoctor.militaryNumber=Number(this.returnedDoctor.militaryNumber)
    this.returnedDoctor.nationalId=Number(this.returnedDoctor.nationalId)
    this.returnedDoctor.rank=this.ranked+" "+this.ranking
    this.admin.editDoctor(this.doctorID,this.returnedDoctor).subscribe(res=>{
      this.hide=false
      setTimeout(() => {
        this.hide=true
        this.router.navigate(["/admin"]);
      }, 1000);
    })
  }

  hide:boolean=true
  ahmed(e:any){
    this.returnedDoctor.rank=e.target.value;
    this.ranked=e.target.value
  }

}
