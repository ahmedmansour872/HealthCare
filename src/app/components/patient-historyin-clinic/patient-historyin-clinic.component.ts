import { PatientHistory } from './../../interfaces/patient-history';
import { DateofpatientComponent } from './../dateofpatient/dateofpatient.component';
import { PatientService } from 'src/app/services/patient.service';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-patient-historyin-clinic',
  templateUrl: './patient-historyin-clinic.component.html',
  styleUrls: ['./patient-historyin-clinic.component.css']
})
export class PatientHistoryinClinicComponent implements OnInit {

  patientId:any;
  clinicId:any;
  temp:any;
  dates:any[]=[];
  desc:any[]=[];
  doctornames:any[]=[];
  drugs:any[]=[];
  patientHistory:PatientHistory[]=[];
  chooseClinic:any;

  constructor(private ActivatedRoute:ActivatedRoute ,private p :PatientService) { }

  ngOnInit(): void {

    this.patientId=this.ActivatedRoute.snapshot.queryParamMap.get("patientid");
    this.clinicId=this.ActivatedRoute.snapshot.queryParamMap.get("clinicId");
    console.log('e',typeof this.clinicId)

    this.p.getPatientHistoriesInClinic(this.patientId,this.clinicId).subscribe(res=>{

      console.log(res);
      this.temp=res;
      this.patientHistory=this.temp;


      console.log( this.temp[0].drugsnames)

      // this.patientHistory=this.temp;

      // console.log ( "s",this.patientHistory[3].drugsnames?.name)
    })

    switch (this.clinicId) {

      case '1':
        this.chooseClinic='القلب'
        break;
      case '2':
        this.chooseClinic='الرمد'
        break;
      case '3' :
        this.chooseClinic='انف واذن وحنجرة'
        break;
      case '4':
        this.chooseClinic='جراحة عامة';
        break;
      case '5':
        this.chooseClinic='باطنة'
        break;
      case '6':
        this.chooseClinic='اسنان'
        break;
      case '7':
        this.chooseClinic= 'المخ و الاعصاب'
        break;
      case '8':
        this.chooseClinic='مسالك'
        break;
      case '9':
        this.chooseClinic='عظام'
        break;
      case '10':
        this.chooseClinic='علاج-طبيعى'
        break;
      default:
        break;
    }

    console.log(this.chooseClinic);


  }

}
