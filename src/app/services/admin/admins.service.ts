import { Pharmacist } from './../../interfaces/pharmacist';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Doctor } from 'src/app/interfaces/doctor';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdminsService {

  constructor(private http:HttpClient) { }

  getTotalNumberOfPatient(){
    return this.http.get(environment.ApiUrl+`Admins/GetPatientsForadminByDayCounts`);
  }

  getNumberOfPatientInClinic(){
    return this.http.get(environment.ApiUrl+`Admins/GetPatientsForadminByCount`);
  }

  getDoctorByMilitaryNumber(mililtaryNumber:any){
      return this.http.get(`${environment.ApiUrl}Admins/SearchForDoctorByMilitarNumber/${mililtaryNumber}`)

  }
  getDoctorByName(fname:any,mname:any,mname2:any,lname:any){
    return this.http.get(`${environment.ApiUrl}Admins/SearchForDoctorByName/${fname}/${mname}/${mname2}/${lname}`)
  }
  getDoctorByNationalID(nationalID:any){
    return this.http.get(`${environment.ApiUrl}Admins/SearchForDoctorByNationalID/${nationalID}`)
  }


  getDoctorByid(doctorID:any){
    return this.http.get(`${environment.ApiUrl}Admins/GetDoctor/${doctorID}`)

  }

  editDoctor(doctorID:any,doctor:Doctor){
    return this.http.put(`${environment.ApiUrl}Doctors/${doctorID}`,doctor);
  }

  addDoctor(doctor:Doctor){
    return this.http.post(`${environment.ApiUrl}Admins/AddDoctor`,doctor);

  }

  addPharmacist(doctor:Doctor){
    return this.http.post(`${environment.ApiUrl}Admins/AddPharmacist`,doctor);

  }


getPharmacistByMilitaryNumber(mililtaryNumber:any){
    return this.http.get(`${environment.ApiUrl}Admins/SearchForPharmacistByMilitarNumber/${mililtaryNumber}`)

}
gePharmacisttByName(fname:any,mname:any,mname2:any,lname:any){
  return this.http.get(`${environment.ApiUrl}Admins/SearchForPharmacistByName/${fname}/${mname}/${mname2}/${lname}`)
}
getPharmacistByNationalID(nationalID:any){
  return this.http.get(`${environment.ApiUrl}Admins/SearchForPharmacistByNationalID/${nationalID}`)
}


getPharmacistByid(phID:any){
  return this.http.get(`${environment.ApiUrl}Admins/GetPharmacistById/${phID}`)

}

 editPharmacist(doctorID:any,doctor:Pharmacist){
  return this.http.put(`${environment.ApiUrl}Admins/PutPharmacist/${doctorID}`,doctor);
}
////////////////

addReceptionest(doctor:Pharmacist){
  return this.http.post(`${environment.ApiUrl}Admins/AddReceptionest`,doctor);

}


getReceptionestByMilitaryNumber(mililtaryNumber:any){
  return this.http.get(`${environment.ApiUrl}Admins/SearchForReceptionestByMilitarNumber/${mililtaryNumber}`)

}
getReceptionesttByName(fname:any,mname:any,mname2:any,lname:any){
return this.http.get(`${environment.ApiUrl}Admins/SearchForReceptionestByName/${fname}/${mname}/${mname2}/${lname}`)
}
getReceptionestByNationalID(nationalID:any){
return this.http.get(`${environment.ApiUrl}Admins/SearchForReceptionestByNationalID/${nationalID}`)
}


getReceptionestByid(phID:any){
return this.http.get(`${environment.ApiUrl}Admins/GetReceptionest/${phID}`)

}

editReceptionest(doctorID:any,doctor:Pharmacist){
return this.http.put(`${environment.ApiUrl}Admins/PutReceptionest/${doctorID}`,doctor);
}





}
