import { AuthService } from 'src/app/services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reception-home-page',
  templateUrl: './reception-home-page.component.html',
  styleUrls: ['./reception-home-page.component.css']
})
export class ReceptionHomePageComponent implements OnInit {

  username:any;
  constructor(private auth:AuthService) { }

  ngOnInit(): void {
    this.username=localStorage.getItem("username");

  }

 

}
