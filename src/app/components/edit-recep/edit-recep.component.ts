import { Resptionest } from 'src/app/interfaces/resptionest';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminsService } from 'src/app/services/admin/admins.service';

@Component({
  selector: 'app-edit-recep',
  templateUrl: './edit-recep.component.html',
  styleUrls: ['./edit-recep.component.css']
})
export class EditRecepComponent implements OnInit {

  username:any="";
  doctorID:any;

  returnedDoctor:Resptionest={};
  constructor(private activatedRoute:ActivatedRoute,private router:Router,private admin:AdminsService) { }




  ngOnInit(): void {
    this.doctorID=this.activatedRoute.snapshot.queryParams["recepid"];

    console.log(this.doctorID);
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
