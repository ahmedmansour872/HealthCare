import { AdminsService } from './../../../services/admin/admins.service';
import { Component, OnInit } from '@angular/core';
import { Doctor } from 'src/app/interfaces/doctor';
import { ActivatedRoute, Router } from '@angular/router';
import { DoctorService } from 'src/app/services/doctors/doctor.service';

@Component({
  selector: 'app-add-doctor',
  templateUrl: './add-doctor.component.html',
  styleUrls: ['./add-doctor.component.css']
})
export class AddDoctorComponent implements OnInit {

error:any;



  returnedDoctor:Doctor={};
  constructor(private doctor:DoctorService,private activatedRoute:ActivatedRoute,private router:Router,private admin:AdminsService) { }



  ngOnInit(): void {

  }

  addDoctor(){

    this.admin.addDoctor(this.returnedDoctor).subscribe(res=>{

      this.router.navigate(['/admin'])

      console.log(res);
    },err=>this.error=err);
  }

}
