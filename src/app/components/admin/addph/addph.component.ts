import { Pharmacist } from './../../../interfaces/pharmacist';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminsService } from 'src/app/services/admin/admins.service';

@Component({
  selector: 'app-addph',
  templateUrl: './addph.component.html',
  styleUrls: ['./addph.component.css']
})
export class AddphComponent implements OnInit {

  error:any;
  returnedDoctor:Pharmacist={};
  constructor(private activatedRoute:ActivatedRoute,private router:Router,private admin:AdminsService) { }



  ngOnInit(): void {

  }

  addDoctor(){

    this.admin.addPharmacist(this.returnedDoctor).subscribe(res=>{

      this.router.navigate(['/admin'])

      console.log(res);
    },err=>this.error=err);
  }

}
