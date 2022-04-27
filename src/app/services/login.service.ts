import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  id:number=1;
  constructor(private http:HttpClient,private router:Router) { }
  // constructor(private http:HttpClient) { }

  login(username:any,password:any,roleId:number){

    const headers = { 'Authorization': 'Bearer my-token', 'My-Custom-Header': 'foobar'}

    // const httpOptions = {
    //   headers: new HttpHeaders({
    //     'Authorization': 'my-auth-token',
    //     "email":username,
    //     "password":password,
    //     "roleId":roleId
    //   })
    // };

    // this.http.get<any>(environment.ApiUrl).subscribe({
    //     next: data => {
    //       switch (Number(roleId)) {
    //         case 1:
    //           this.router.navigate(['reception'])
    //           break;
    //         case 2:
    //           this.router.navigate(['doctor'])
    //           break;
    //         case 3:
    //           this.router.navigate(['pha'])
    //           break;

    //         default:
    //           break;
    //       }
    //     },
    //     error: error => {
    //         console.error('There was an error!', error);
    //     }
    // })

    return this.http.get(`${environment.ApiUrl}Home/login/${username}/${password}/${roleId}`);
  }
}
