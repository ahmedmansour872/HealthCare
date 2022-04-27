import { Prescription } from './prescription';
import { Drug } from 'src/app/interfaces/drug';

export interface PatientDetails {
  doctor_Name?:any;
  clinc_Name?:any;
  patientFull_Name?:any;
  age?:any;
  rank?:any;
  religion?:any;
  prescriptions?:Prescription[];
  patientID?:any;
}

