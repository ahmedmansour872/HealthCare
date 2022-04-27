import { Pharmacist } from './../../../interfaces/pharmacist';
import { Component, OnInit } from '@angular/core';
import { AdminsService } from 'src/app/services/admin/admins.service';

@Component({
  selector: 'app-exist-pharmacist',
  templateUrl: './exist-pharmacist.component.html',
  styleUrls: ['./exist-pharmacist.component.css']
})
export class ExistPharmacistComponent implements OnInit {

  ph:Pharmacist={};
  hist:any;
  error:any;
  error2:any;
  fullnamevalid:boolean=false;
  arr:any;
  constructor(private admin:AdminsService) {
  }

  ngOnInit() {

    if(localStorage.getItem("mnumber")!=null){
      this.admin.getPharmacistByMilitaryNumber(localStorage.getItem("mnumber")).subscribe(res=>{
        console.log(res);

        this.ph=res


      },err=>{
        this.error=err;
      });
    }
    else if(localStorage.getItem("nationalID")!=null){
      this.admin.getPharmacistByNationalID(localStorage.getItem("nationalID")).subscribe(res=>{

        this.ph=res
      },err=>{
        this.error=err;
      });
    }

    else if((localStorage.getItem("nationalID")==null && localStorage.getItem("mnumber")==null) &&(localStorage.getItem("fname")!=null && localStorage.getItem("mname")!=null && localStorage.getItem("mname2")!=null && localStorage.getItem("lname")!=null) ){
      this.admin.gePharmacisttByName(localStorage.getItem("fname"),localStorage.getItem("mname"),localStorage.getItem("mname2"),localStorage.getItem("lname")).subscribe(res=>{

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
