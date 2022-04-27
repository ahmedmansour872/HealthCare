import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  loggedIn:any=false;
  constructor() { }


  login(){
    this.loggedIn=true;

  }

  logout(){
    this.loggedIn=false;

  }
  isAuthenticated(){
    const promise = new Promise(
        (resolve,reject)=>{
            resolve(this.loggedIn);
        }
    );
    return promise;
}


}
