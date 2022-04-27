import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class ResAuthGuardS implements CanActivate{

  constructor(private auth:AuthService,private router:Router) { }
  canActivate(route :ActivatedRouteSnapshot,state:RouterStateSnapshot):Observable<boolean> |Promise<boolean>|boolean{
    return this.auth.isAuthenticated().then(
      (authenticated:boolean|any)=>{
          if(authenticated || localStorage.getItem("con")=="true")
          {
            return true;
          }
          else {
            console.log(state.url);
            this.router.navigate(["notfound"]);
            return false;
        }
      }
  )
  }
}

