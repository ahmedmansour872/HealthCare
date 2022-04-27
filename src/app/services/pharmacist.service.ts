import { Patient } from './../interfaces/patient';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PharmacistService {

  constructor(private http:HttpClient) { }


  getPatientDetailsByName(fname:any,mname:any,mname2:any,lname:any){
    return this.http.get(`${environment.ApiUrl}Pharmacists/${fname}/${mname}/${mname2}/${lname}`)
  }

  getPatientDetailsByMilitaryNumber(mililtaryNumber:any){
    return this.http.get(`${environment.ApiUrl}Pharmacists/SearchForPatientByMilitarNumber/${mililtaryNumber}`)
  }

  getPatientDetailsByNationalID(nationalID:any){
    return this.http.get(`${environment.ApiUrl}Pharmacists/SearchPatientByNationalID/${nationalID}`)
  }


  done(patientID:any){


    return this.http.post(`${environment.ApiUrl}Pharmacists/DonePatientPrescription/${patientID}`,patientID)


  }


}
