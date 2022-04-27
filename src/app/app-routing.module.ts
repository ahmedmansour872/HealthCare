import { EditRecepComponent } from './components/edit-recep/edit-recep.component';
import { RecepDetailsComponent } from './components/admin/recep-details/recep-details.component';
// import { ExistRecepComponent } from './components/admin/exist-recep/exist-recep.component';
// import { SearchRecpComponent } from './components/admin/search-recp/search-recp.component';
import { AddphComponent } from './components/admin/addph/addph.component';
import { EditPhComponent } from './components/admin/edit-ph/edit-ph.component';
import { PhDetailsComponent } from './components/admin/ph-details/ph-details.component';
import { ExistPharmacistComponent } from './components/admin/exist-pharmacist/exist-pharmacist.component';
import { SearchPharmacistComponent } from './components/admin/search-pharmacist/search-pharmacist.component';
import { EditDoctorComponent } from './components/admin/edit-doctor/edit-doctor.component';
import { UpdateDoctorComponent } from './components/admin/update-doctor/update-doctor.component';
import { ExistDoctorComponent } from './components/admin/exist-doctor/exist-doctor.component';
import { DoctorAdminComponent } from './components/admin/doctor-admin/doctor-admin.component';
import { PhAuthGuardS } from './services/guards/ph-auth-guard';
import { DocAuthGuardS } from './services/guards/doc-auth-guard';

import { PatientHistoryinClinicComponent } from './components/patient-historyin-clinic/patient-historyin-clinic.component';
import { UpdateDrugComponent } from './components/update-drug/update-drug.component';
import { AddNewDrugComponent } from './components/add-new-drug/add-new-drug.component';
import { AddDrugComponent } from './add-drug/add-drug.component';
import { PhHomePageComponent } from './ph-home-page/ph-home-page.component';
import { PharmacyComponent } from './components/pharmacy/pharmacy.component';
import { DoctorComponent } from './components/doctor/doctor.component';
import { UpdatePatientComponent } from './components/update-patient/update-patient.component';
import { DateofpatientComponent } from './components/dateofpatient/dateofpatient.component';
import { DiseasHistoryComponent } from './components/diseas-history/diseas-history.component';
import { ExistPatientComponent } from './components/exist-patient/exist-patient.component';
import { TicketComponent } from './components/ticket/ticket.component';
import { ClinicsComponent } from './components/clinics/clinics.component';
import { AddPaComponent } from './components/reception/add-pa/add-pa.component';
import { SearchPaComponent } from './components/reception/search-pa/search-pa.component';
import { LoginComponent } from './components/login/login.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryComponent } from './components/category/category.component';
import { ReceptionHomePageComponent } from './components/reception-home-page/reception-home-page.component';
import { ResAuthGuardS } from './services/guards/res-auth-guard';
import { HomePageComponent } from './components/admin/home-page/home-page.component';
import { AddDoctorComponent } from './components/admin/add-doctor/add-doctor.component';
import { SearchRecpComponent } from './components/admin/search-recp/search-recp.component';
import { ExistRecepComponent } from './components/admin/exist-recep/exist-recep.component';
import { AddRecpComponent } from './components/admin/add-recp/add-recp.component';

const routes: Routes = [
  {path:'',component:CategoryComponent},
  {path:'login/:id',component:LoginComponent},
  {path:'reception',component:SearchPaComponent,canActivate:[ResAuthGuardS]},
  {path:'addPatient',component:AddPaComponent,canActivate:[ResAuthGuardS]},
  {path:'clinics',component:ClinicsComponent,canActivate:[ResAuthGuardS]},
  {path:'ticket',component:TicketComponent,canActivate:[ResAuthGuardS]},
  {path:'existPatient',component:ExistPatientComponent,canActivate:[ResAuthGuardS]},
  {path:'diseashistory',component:DiseasHistoryComponent,canActivate:[ResAuthGuardS]},
  {path:'diseasdate',component:DateofpatientComponent,canActivate:[ResAuthGuardS]},
  {path:'updatepatient',component:UpdatePatientComponent,canActivate:[ResAuthGuardS]},
  {path:'doctor',component:DoctorComponent,canActivate:[DocAuthGuardS]},
  {path:'pharmacy',component:PharmacyComponent,canActivate:[PhAuthGuardS]},
  {path:'PhHomePage',component:PhHomePageComponent,canActivate:[PhAuthGuardS]},
  {path:'Drug',component:AddDrugComponent,canActivate:[PhAuthGuardS]},
  {path:'addNewDrug',component:AddNewDrugComponent,canActivate:[PhAuthGuardS]},
  {path:'updateDrug',component:UpdateDrugComponent,canActivate:[PhAuthGuardS]},
  {path:'receptionHomePage',component:ReceptionHomePageComponent,canActivate:[ResAuthGuardS]},
  {path:'patientHistory',component:PatientHistoryinClinicComponent,canActivate:[ResAuthGuardS]},
  {path:'admin',component:HomePageComponent},
  {path:'admin/serarchDoctor',component:DoctorAdminComponent},
  {path:'admin/existDoctor',component:ExistDoctorComponent},
  {path:'admin/updateDoctor',component:UpdateDoctorComponent},
  {path:'admin/editDoctor',component:EditDoctorComponent},
  {path:'admin/addDoctor',component:AddDoctorComponent},
  {path:'admin/SearchPharmacist',component:SearchPharmacistComponent},
  {path:'admin/existPharmacist',component:ExistPharmacistComponent},
  {path:'admin/phDetails',component:PhDetailsComponent},
  {path:'admin/editPh',component:EditPhComponent},
  {path:'admin/addph',component:AddphComponent},
  {path:'admin/searchRecp',component:SearchRecpComponent},
  {path:'admin/existRecep',component:ExistRecepComponent},
  {path:'admin/recepDetails',component:RecepDetailsComponent},
  {path:'admin/editRecep',component:EditRecepComponent},
  {path:'admin/addRecep',component:AddRecpComponent},

  {path:'**',component:NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
 }
