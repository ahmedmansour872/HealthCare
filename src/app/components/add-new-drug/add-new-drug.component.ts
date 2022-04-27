import { Router } from '@angular/router';
import { Drug } from './../../interfaces/drug';
import { Component, OnInit } from '@angular/core';
import { DrugService } from 'src/app/services/drugs/drug.service';

@Component({
  selector: 'app-add-new-drug',
  templateUrl: './add-new-drug.component.html',
  styleUrls: ['./add-new-drug.component.css']
})
export class AddNewDrugComponent implements OnInit {

  drug:Drug={};
  error:any="";

  constructor(private d:DrugService ,private router:Router) { }

  ngOnInit(): void {

    console.log(this.drug.category)
  }

  addNewDrug(){

    console.log ("r", this.drug)

    this.drug.pharmacistId=Number(localStorage.getItem("phID"));


    this.d.addDrug(this.drug).subscribe(res=>{

      console.log(res);

      this.router.navigate(['Drug']);


    },err=>{
        this.error=err;
      }

    )
  }




}
