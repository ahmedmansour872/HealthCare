import { Router } from '@angular/router';
import { PatientService } from 'src/app/services/patient.service';
import { Patient } from 'src/app/interfaces/patient';
import { Component, OnInit } from '@angular/core';
import { ThisReceiver } from '@angular/compiler';
import { DoctorService } from 'src/app/services/doctors/doctor.service';
import { Prescription } from 'src/app/interfaces/prescription';
import { DrugService } from 'src/app/services/drugs/drug.service';
import { Drug } from 'src/app/interfaces/drug';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class DoctorComponent implements OnInit {

  constructor(private Patient:PatientService,private doctor:DoctorService,private drug:DrugService,private router:Router) { }

  username:any=""
  clinicName:any=""
  fullName:any=""
  chooseClinic:any;
  patients:Patient[]=[];
  temp:any;
  desc:any="";
  recomm:any="";
  checked:boolean=false;
  returendPatient:Patient={};
  descrption:any="";
  recommandation:any="";
  duration?:any="";
  drugName:any=""
  drugAmount:any=""
  drugAmountPday:any=""
  p:Array<Prescription>=[];
  d:Array<Drug>=[];
  temp2:any;
  ranked:any=""
  patientID:any




  ngOnInit(): void {

    this.drug.getDrugs().subscribe(res=>{

      console.log('t',this.temp);

      this.temp2=res;

      this.d=this.temp2;

    });
    this.username=localStorage.getItem("doctorname")
    this.clinicName=localStorage.getItem("clinicName")
    switch (this.clinicName) {

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
      case 'مخ واعصاب':
        this.chooseClinic=7
        break;
      case 'مسالك':
        this.chooseClinic=8
        break;
      case 'عظام':
        this.chooseClinic=9
        break;
      case 'علاج طبيعى':
        this.chooseClinic=10
        break;
      default:
        break;
    }
  }

  getPatient(){
    this.Patient.getAllPatientInClinic(this.chooseClinic).subscribe(res=>{
      this.temp=res;
      console.log('t2',this.temp.length);
      this.patients=this.temp;


      this.patients.forEach(element => {
        this.ranked=element.rank
        if(this.ranked.includes("ضابط صف")){

          if((this.ranked.split(' ')[2]+" "+this.ranked.split(' ')[3]).includes(" ")&&this.ranked.split(' ')[3]!=undefined)
          element.rank=this.ranked.split(' ')[2]+" "+this.ranked.split(' ')[3]
          else
          element.rank=this.ranked.split(' ')[2]

        }else if((this.ranked.split(' ')[1]+" "+this.ranked.split(' ')[2]).includes('ملازم اول')){
          element.rank=this.ranked.split(' ')[1]+" "+this.ranked.split(' ')[2]
        }
        else{
          element.rank=this.ranked.split(' ')[1] || this.ranked.split(' ')[0]
        }
      });
    })

  }


  getPatientById(p:Patient){
    this.returendPatient=p;
    this.fullName=`${p.fname} ${p.mname} ${p.mname2} ${p.lname}`
    this.patientID=this.returendPatient.id
  }

  addRecom(){
    this.doctor.addPresc(this.returendPatient.id,this.chooseClinic,localStorage.getItem("docID"), this.descrption,this.recommandation,this.checked,this.p).subscribe(res=>{
      location.reload();
    },err=>console.log(err))
   }

   savePre(){

    this.p[this.p.length]={
      'duration':this.duration,
      'drugName':this.drugName,
      'drugAmount':this.drugAmount,
      'drugAmountPday': this.drugAmountPday,
      'patientID':this.returendPatient.id,
      'doctorId':Number(localStorage.getItem("docID"))
    }

    this.drugName=""
    this.drugAmount=null
    this.drugAmountPday=null
    this.duration=null
  }

  exit(){
    console.log("1")
    this.router.navigate(['']);
    localStorage.setItem("con2","false")
  }


}
