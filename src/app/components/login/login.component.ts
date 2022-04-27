import { LoginService } from './../../services/login.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Resptionest } from 'src/app/interfaces/resptionest';
import { Doctor } from 'src/app/interfaces/doctor';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  roleId:any=0;
  result:any={};
  error:any="";
  resp:Resptionest={};
  doctor:Doctor={};
  username:any="";
  clinicName:any="";


  constructor(private activatedRoute:ActivatedRoute,private router:Router,private loginService:LoginService  ,private auth:AuthService) {
    this.roleId=activatedRoute.snapshot.params['id']
  }

  ngOnInit(): void {

  }



  submition(username:string,password:string){


    this.loginService.login(username,password,this.roleId).subscribe((res)=>
      {
        this.resp=res;
        this.doctor=res;

        console.log(res)

      if(res!=null) {
      switch (Number(this.roleId)) {
      case 1:
        this.router.navigate(['receptionHomePage'])
        this.username=this.resp.username;
        localStorage.setItem("username",this.username );
        localStorage.setItem("respID",JSON.stringify(this.resp.id));
        this.auth.login();
        localStorage.setItem("con",this.auth.loggedIn);
        localStorage.setItem("con2","false");
        localStorage.setItem("con3","false");


        break;

        case 2:
          this.router.navigate(['doctor'])
          this.username=this.resp.username;
          this.clinicName=this.doctor.specialization
          localStorage.setItem("doctorname",this.username );
          localStorage.setItem("clinicName",this.clinicName );
          localStorage.setItem("docID",JSON.stringify(this.resp.id));
          this.auth.login();
          localStorage.setItem("con2",this.auth.loggedIn);
          localStorage.setItem("con","false");
          localStorage.setItem("con3","false");



        break;

      case 3:
          this.router.navigate(['PhHomePage'])
          this.username=this.resp.username;
          localStorage.setItem("phName",this.username );
          localStorage.setItem("phID",JSON.stringify(this.resp.id));
          this.auth.login();
          localStorage.setItem("con3",this.auth.loggedIn);
          localStorage.setItem("con","false");
          localStorage.setItem("con2","false");

        break;

      default:
        break;
    }
    }

    },
    (err)=>{this.error=err});

  }


}
