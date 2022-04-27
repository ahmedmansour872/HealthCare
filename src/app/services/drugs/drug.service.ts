import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Drug } from 'src/app/interfaces/drug';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DrugService {

  constructor(private http:HttpClient) { }

  getDrugs(){
    return this.http.get(`${environment.ApiUrl}Drugs/GetDrugs`);

  }

  addDrug(d:Drug){
    return this.http.post(`${environment.ApiUrl}Drugs`,d);

  }

  getDrugsByCategory(cat:any){
    return this.http.get(`${environment.ApiUrl}Drugs/GetDrugByCategory/${cat}`);
  }

  getDrugByid(id:any){
    return this.http.get(`${environment.ApiUrl}Drugs/${id}`);


  }

  updateDrug(id:any,d:Drug){
    return this.http.put(`${environment.ApiUrl}Drugs/${id}`,d);

  }


}
