import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from './../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private http:HttpClient) { }

clinicId:number=0
patientID:number=0
  getTicket(){
    this.clinicId=Number(localStorage.getItem("clinicID"))
    this.patientID=Number(localStorage.getItem("patientID"))
    return this.http.get(`${environment.ApiUrl}Patients/ticket/${this.clinicId}/${this.patientID}`);
  }
}
