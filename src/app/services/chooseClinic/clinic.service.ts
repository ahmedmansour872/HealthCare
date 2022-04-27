import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from './../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClinicService {
 p:any={};
  constructor(private http:HttpClient) { }

  PostClinic(p:number ){

   return this.http.post(environment.ApiUrl+`Patients/BookingClinics/${p}/${Number(localStorage.getItem("patientID"))}`,p);
  }
}
