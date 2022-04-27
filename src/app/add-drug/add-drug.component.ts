import { Drug } from './../interfaces/drug';
import { DrugService } from './../services/drugs/drug.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-drug',
  templateUrl: './add-drug.component.html',
  styleUrls: ['./add-drug.component.css']
})
export class AddDrugComponent implements OnInit {

  temp:any;
  d:Drug={};
  constructor(private drug:DrugService) { }

  ngOnInit(): void {

    this.drug.getDrugs().subscribe(res=>{

      console.log(res);
      this.d=res;
      this.temp=this.d;
    })
  }

  filter(a:any){

    this.drug.getDrugsByCategory(a).subscribe(res=>{
      this.temp=res;
      console.log(res);
    })

  }

  all(){
    this.drug.getDrugs().subscribe(res=>{

      console.log(res);
      this.d=res;
      this.temp=this.d;
    })
  }

}
