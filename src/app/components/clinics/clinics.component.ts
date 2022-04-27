import { Router } from '@angular/router';
import { Component, ElementRef, OnInit } from '@angular/core';
import { ClinicService } from 'src/app/services/chooseClinic/clinic.service';

@Component({
  selector: 'app-clinics',
  templateUrl: './clinics.component.html',
  styleUrls: ['./clinics.component.css']
})
export class ClinicsComponent implements OnInit {

  arr:any=[];
  username:any="";

  error:any;

  chooseClinic:number=0



  constructor( private clinic:ClinicService,private router:Router) { }

  toggle(f:any){
    this.arr=document.querySelectorAll(".block .clinic.active");

      for (let index = 0; index < this.arr.length; index++) {
       this.arr[index].classList.remove("active");
      }

      f.classList.add("active");

      switch (f.children[1].textContent.trim()) {

        case 'القلب':
          this.chooseClinic=1
          break;
        case 'الرمد':
          this.chooseClinic=2
          break;
        case 'انف واذن وحنجرة':
          this.chooseClinic=3
          break;
        case 'جراحة عامة':
          this.chooseClinic=4
          break;
        case 'باطنة':
          this.chooseClinic=5
          break;
        case 'اسنان':
          this.chooseClinic=6
          break;
        case 'مخ-و-اعصاب':
          this.chooseClinic=7
          break;
        case 'مسالك':
          this.chooseClinic=8
          break;
        case 'عظام':
          this.chooseClinic=9
          break;
        case 'علاج-طبيعى':
          this.chooseClinic=10
          break;
        default:
          break;
      }

}


ngOnInit(): void {
  this.username=localStorage.getItem("username");

}
submitClinic(){
  this.clinic.PostClinic(this.chooseClinic).subscribe(res=>{
    localStorage.setItem("clinicID",JSON.stringify(this.chooseClinic));
    this.router.navigate(["/ticket"]);
  },err=>{

    console.log( err)
    this.error=err;
  }


 )


  }

}
