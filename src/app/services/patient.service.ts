import { environment } from './../../environments/environment';

import { Router } from '@angular/router';
import { Patient } from './../interfaces/patient';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class PatientService {

  constructor(private http:HttpClient) { }

  searchedPatient:Patient={};

  PostPatient(p:Patient ){

   return this.http.post(`${environment.ApiUrl}Patients/PostPatient`,p);
  }

  getAllPatientInClinic(clinicID:any){
    return this.http.get(`${environment.ApiUrl}Doctors/GetPatientsForDoctor/${clinicID}`);
  }

  getPatientByName(fname:any,mname:any,mname2:any,lname:any){
    return this.http.get(`${environment.ApiUrl}Patients/${fname}/${mname}/${mname2}/${lname}`)
  }

  getPatientByMilitaryNumber(mililtaryNumber:any){
    return this.http.get(`${environment.ApiUrl}Patients/${mililtaryNumber}`)
  }

  getPatientByNationalID(nationalID:any){
    return this.http.get(`${environment.ApiUrl}Patients/SearchPatientByNationalID/${nationalID}`)
  }

  getPatientHistories(patientID:any){
    return this.http.get(`${environment.ApiUrl}Patients/PatientHistories/${patientID}`)
  }

  getPatientByid(patientID:any){
    return this.http.get(`${environment.ApiUrl}Patients/GetPatientsById/${patientID}`)

  }

  editPatient(patientID:any,Patient:Patient){
    return this.http.put(`${environment.ApiUrl}Patients/${patientID}`,Patient);
  }
  getPatientHistoriesInClinic(patientID:number,clinic_id:number){
    return this.http.get(`${environment.ApiUrl}Patients/PatientHistory/${patientID}/${clinic_id}`)
  }


}
