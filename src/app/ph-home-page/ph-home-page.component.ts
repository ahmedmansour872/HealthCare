import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-ph-home-page',
  templateUrl: './ph-home-page.component.html',
  styleUrls: ['./ph-home-page.component.css']
})
export class PhHomePageComponent implements OnInit {
  username:any;
  constructor() { }

  ngOnInit(): void {
    this.username=localStorage.getItem("phName");

  }

}
