import { TicketService } from './../../services/ticket.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {

  next:any;
  name:any;
  clinicName:any;
  date:any;
  age:any;
  result:any=[];
  username:any="";


  constructor(private ticket:TicketService) { }

  ngOnInit(): void {
    this.username=localStorage.getItem("username");


    this.ticket.getTicket().subscribe((res)=>{
      this.result=res;
      this.next=this.result[0];
      this.name=this.result[1];
      this.clinicName=this.result[2];
      this.age=this.result[3];
      this.date=this.result[4];


    })
  }

  print(){
    // const WindowPrt = window.open('', '', 'left=0,top=0,width=500,height=600,toolbar=0,scrollbars=0,status=0');

    print();
  }


}
