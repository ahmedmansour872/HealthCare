import { Pharmacist } from './../../../interfaces/pharmacist';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminsService } from 'src/app/services/admin/admins.service';

@Component({
  selector: 'app-ph-details',
  templateUrl: './ph-details.component.html',
  styleUrls: ['./ph-details.component.css']
})
export class PhDetailsComponent implements OnInit {

  username:any="";
  doctorID:any;

  returnedDoctor:Pharmacist={};
  constructor(private activatedRoute:ActivatedRoute,private router:Router,private admin:AdminsService) { }


  ranking:any=""
  ranked:any=""


  ngOnInit(): void {
    this.doctorID=this.activatedRoute.snapshot.queryParams["phid"];

    this.username=localStorage.getItem("username");
    this.admin.getPharmacistByid(this.doctorID).subscribe(res=>{
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
