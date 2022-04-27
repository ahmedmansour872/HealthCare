import { ViewEncapsulation } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-exit',
  templateUrl: './exit.component.html',
  styleUrls: ['./exit.component.css']
})
export class ExitComponent implements OnInit {

  constructor(private auth:AuthService,private router:Router ) { }


  ngOnInit(): void {
  }

  exitSys(){
    this.auth.logout();
    localStorage.setItem("con",this.auth.loggedIn);
    localStorage.setItem("con2",this.auth.loggedIn);
    localStorage.setItem("con3",this.auth.loggedIn);
    this.router.navigate([""]);

  }

}
