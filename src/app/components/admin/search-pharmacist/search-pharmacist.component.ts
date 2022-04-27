import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search-pharmacist',
  templateUrl: './search-pharmacist.component.html',
  styleUrls: ['./search-pharmacist.component.css']
})
export class SearchPharmacistComponent implements OnInit {
  username:any="";
  fname:any;
  mname:any;
  mname2:any;
  lname:any;
  mnumber:any;
  nationalID:any;
  constructor() { }

  ngOnInit(): void {
  }

  search(f:any){

    localStorage.removeItem("mnumber");
    localStorage.removeItem("nationalID");
    localStorage.removeItem("fname");
    localStorage.removeItem("mname");
    localStorage.removeItem("mname2");
    localStorage.removeItem("lname");

    if(this.mnumber!=null){
      localStorage.setItem("mnumber",this.mnumber)
    }
    else if(this.nationalID!=null){
      localStorage.setItem("nationalID",this.nationalID)
    }

   else if((this.nationalID==null && this.mnumber==null) &&(this.fname!=null && this.mname!=null && this.mname2!=null && this.lname!=null) ){
    localStorage.setItem("fname",this.fname)
    localStorage.setItem("mname",this.mname)
    localStorage.setItem("mname2",this.mname2)
    localStorage.setItem("lname",this.lname)
    }


}

}
