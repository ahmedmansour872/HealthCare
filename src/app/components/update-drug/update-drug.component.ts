import { ActivatedRoute, Router } from '@angular/router';
import { DrugService } from 'src/app/services/drugs/drug.service';
import { Component, OnInit } from '@angular/core';
import { Drug } from 'src/app/interfaces/drug';
import { async } from '@angular/core/testing';

@Component({
  selector: 'app-update-drug',
  templateUrl: './update-drug.component.html',
  styleUrls: ['./update-drug.component.css']
})
export class UpdateDrugComponent implements OnInit {

  drugID:any;
  drug:Drug={};
  cat:any;
  x:any;

  constructor(private d:DrugService,private activatedRoute:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {

    this.drugID=this.activatedRoute.snapshot.queryParamMap.get("drugID");

    this.d.getDrugByid(this.drugID).subscribe(res=> {

      this.drug=res;

      this.cat=this.drug.category;







    })

  }


  save(){

    if(this.cat === 'دواء شرب'){
      this.x='1';

    }
    else if(this.cat == 'اقراص'){
    this.x='2';

    }

    else if(this.cat == 'حقن'){
     this.x='3';

    }

    else if(this.cat == 'مرهم'){
       this.x='4';

    }


console.log("x",this.x)
    this.drug.category=this.x;

    this.d.updateDrug(this.drugID,this.drug).subscribe(res=>{

      this.router.navigate(['/Drug']);

    })
  }

  changeVal(drugCategory:any){

    this.cat=drugCategory;
    this.drug.category=drugCategory;
    this.x=this.drug.category;


  }


}
