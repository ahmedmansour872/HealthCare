import { Resptionest } from 'src/app/interfaces/resptionest';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminsService } from 'src/app/services/admin/admins.service';

@Component({
  selector: 'app-add-recp',
  templateUrl: './add-recp.component.html',
  styleUrls: ['./add-recp.component.css']
})
export class AddRecpComponent implements OnInit {
  error:any;



  returnedDoctor:Resptionest={};
  constructor(private activatedRoute:ActivatedRoute,private router:Router,private admin:AdminsService) { }



  ngOnInit(): void {

  }

  addDoctor(){

    this.admin.addReceptionest(this.returnedDoctor).subscribe(res=>{

      this.router.navigate(['/admin'])

      console.log(res);
    },err=>this.error=err);
  }

}
