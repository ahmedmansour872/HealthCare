import { Component, OnInit } from '@angular/core';
import { Resptionest } from 'src/app/interfaces/resptionest';
import { AdminsService } from 'src/app/services/admin/admins.service';

@Component({
  selector: 'app-exist-recep',
  templateUrl: './exist-recep.component.html',
  styleUrls: ['./exist-recep.component.css']
})
export class ExistRecepComponent implements OnInit {


  ph:Resptionest={};
  hist:any;
  error:any;
  error2:any;
  fullnamevalid:boolean=false;
  arr:any;
  constructor(private admin:AdminsService) {
  }

  ngOnInit() {

    if(localStorage.getItem("mnumber")!=null){
      this.admin.getReceptionestByMilitaryNumber(localStorage.getItem("mnumber")).subscribe(res=>{
        console.log(res);

        this.ph=res


      },err=>{
        this.error=err;
      });
    }
    else if(localStorage.getItem("nationalID")!=null){
      this.admin.getReceptionestByNationalID(localStorage.getItem("nationalID")).subscribe(res=>{

        this.ph=res
      },err=>{
        this.error=err;
      });
    }

    else if((localStorage.getItem("nationalID")==null && localStorage.getItem("mnumber")==null) &&(localStorage.getItem("fname")!=null && localStorage.getItem("mname")!=null && localStorage.getItem("mname2")!=null && localStorage.getItem("lname")!=null) ){
      this.admin.getReceptionesttByName(localStorage.getItem("fname"),localStorage.getItem("mname"),localStorage.getItem("mname2"),localStorage.getItem("lname")).subscribe(res=>{

        this.ph=res

        this.arr=res;
        this.error2=res;
        if(this.error2.length==0){
          this.fullnamevalid=true;
          console.log("err", this.error2);
        }

        if(this.arr.length >=1) {
          this.ph=this.arr[0];
        }
      },err=>{
        console.log(err);
        this.error=err;
      });

    }
  }
}
