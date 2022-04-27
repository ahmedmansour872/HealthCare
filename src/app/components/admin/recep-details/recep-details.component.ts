import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Resptionest } from 'src/app/interfaces/resptionest';
import { AdminsService } from 'src/app/services/admin/admins.service';

@Component({
  selector: 'app-recep-details',
  templateUrl: './recep-details.component.html',
  styleUrls: ['./recep-details.component.css']
})
export class RecepDetailsComponent implements OnInit {

  username:any="";
  doctorID:any;

  returnedDoctor:Resptionest={};
  constructor(private activatedRoute:ActivatedRoute,private router:Router,private admin:AdminsService) { }


  ranking:any=""
  ranked:any=""


  ngOnInit(): void {
    this.doctorID=this.activatedRoute.snapshot.queryParams["recepid"];

    this.username=localStorage.getItem("username");
    this.admin.getReceptionestByid(this.doctorID).subscribe(res=>{
      this.returnedDoctor=res
      console.log(res)

    });
  }

  update(){
    this.returnedDoctor.militaryNumber=Number(this.returnedDoctor.militaryNumber)
    this.returnedDoctor.nationalId=Number(this.returnedDoctor.nationalId)
    this.admin.editReceptionest(this.doctorID,this.returnedDoctor).subscribe(res=>{
      this.hide=false
      setTimeout(() => {
        this.hide=true
        this.router.navigate(["/admin"]);
      }, 1000);
    })
  }

  hide:boolean=true
 
}
