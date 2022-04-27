import { Pharmacist } from './../../../interfaces/pharmacist';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminsService } from 'src/app/services/admin/admins.service';

@Component({
  selector: 'app-edit-ph',
  templateUrl: './edit-ph.component.html',
  styleUrls: ['./edit-ph.component.css']
})
export class EditPhComponent implements OnInit {


  username:any="";
  doctorID:any;

  returnedDoctor:Pharmacist={};
  constructor(private activatedRoute:ActivatedRoute,private router:Router,private admin:AdminsService) { }


  ranking:any=""
  ranked:any=""


  ngOnInit(): void {
    this.doctorID=this.activatedRoute.snapshot.queryParams["phid"];

    console.log(this.doctorID);
    this.username=localStorage.getItem("username");
    this.admin.getPharmacistByid(this.doctorID).subscribe(res=>{
      this.returnedDoctor=res

      this.ranking=this.returnedDoctor.rank;

      console.log(res)

    });
  }

  update(){
    this.returnedDoctor.militaryNumber=Number(this.returnedDoctor.militaryNumber)
    this.returnedDoctor.nationalId=Number(this.returnedDoctor.nationalId)
    this.returnedDoctor.rank=this.ranking;
    this.admin.editPharmacist(this.doctorID,this.returnedDoctor).subscribe(res=>{
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
