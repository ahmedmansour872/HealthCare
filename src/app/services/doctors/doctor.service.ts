import { Patient } from 'src/app/interfaces/patient';
import { Prescription } from './../../interfaces/prescription';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AnyCatcher } from 'rxjs/internal/AnyCatcher';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  constructor(private http:HttpClient) { }
  // postRecommendation(patientId:any,des:any,recomm:any,reserved:boolean ){

  //   return this.http.post(`${environment.ApiUrl}Doctors/AddDescribe_Recommend/${patientId}/${des}/${recomm}/${reserved}`,patientId);
  //  }

   addPresc(Patient_ID:any,clinic_id:any,Doc_Id:any,Decribe:any,Recommend:any,reserved:any, p:Array<Prescription>){
     return this.http.post(`${environment.ApiUrl}Doctors/AddDescribe_Recommend/${Patient_ID}/${clinic_id}/${Doc_Id}/${Decribe}/${Recommend}/${reserved}`,p);
   }

}
