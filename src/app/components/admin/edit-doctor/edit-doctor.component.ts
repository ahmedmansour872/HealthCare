import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Doctor } from 'src/app/interfaces/doctor';
import { AdminsService } from 'src/app/services/admin/admins.service';
import { DoctorService } from 'src/app/services/doctors/doctor.service';

@Component({
  selector: 'app-edit-doctor',
  templateUrl: './edit-doctor.component.html',
  styleUrls: ['./edit-doctor.component.css']
})
export class EditDoctorComponent implements OnInit {

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

      this.ranking=this.returnedDoctor.rank;

      console.log(res)

    });
  }

  update(){
    this.returnedDoctor.militaryNumber=Number(this.returnedDoctor.militaryNumber)
    this.returnedDoctor.nationalId=Number(this.returnedDoctor.nationalId)
    this.returnedDoctor.rank=this.ranking;
    this.admin.editDoctor(this.doctorID,this.returnedDoctor).subscribe(res=>{
      this.hide=false
      setTimeout(() => {
        this.hide=true
        this.router.navigate(["/admin"]);
      }, 1000);
    })
  }

  hide:boolean=true
  changeVal(e:any){
    this.ranking=e;
    this.returnedDoctor.rank=e;

  }

}
