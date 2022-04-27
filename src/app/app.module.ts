import { UpdateDrugComponent } from './components/update-drug/update-drug.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './components/login/login.component';
import { CategoryComponent } from './components/category/category.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { SearchPaComponent } from './components/reception/search-pa/search-pa.component';
import { AddPaComponent } from './components/reception/add-pa/add-pa.component';
import { ClinicsComponent } from './components/clinics/clinics.component';
import { TicketComponent } from './components/ticket/ticket.component';
import { ExistPatientComponent } from './components/exist-patient/exist-patient.component';
import { HttpClientModule } from '@angular/common/http';
import { DiseasHistoryComponent } from './components/diseas-history/diseas-history.component';
import { DateofpatientComponent } from './components/dateofpatient/dateofpatient.component';
import { UpdatePatientComponent } from './components/update-patient/update-patient.component';
import { DoctorComponent } from './components/doctor/doctor.component';
import { PharmacyComponent } from './components/pharmacy/pharmacy.component';
import { PhHomePageComponent } from './ph-home-page/ph-home-page.component';
import { AddDrugComponent } from './add-drug/add-drug.component';
import { AddNewDrugComponent } from './components/add-new-drug/add-new-drug.component';
import { ReceptionHomePageComponent } from './components/reception-home-page/reception-home-page.component';
import { PatientHistoryinClinicComponent } from './components/patient-historyin-clinic/patient-historyin-clinic.component';
import { ExitComponent } from './components/exit/exit.component';
import { HomePageComponent } from './components/admin/home-page/home-page.component';
import { NgChartsModule } from 'ng2-charts';
import { DoctorAdminComponent } from './components/admin/doctor-admin/doctor-admin.component';
import { ExistDoctorComponent } from './components/admin/exist-doctor/exist-doctor.component';
import { UpdateDoctorComponent } from './components/admin/update-doctor/update-doctor.component';
import { EditDoctorComponent } from './components/admin/edit-doctor/edit-doctor.component';
import { AddDoctorComponent } from './components/admin/add-doctor/add-doctor.component';
import { SearchPharmacistComponent } from './components/admin/search-pharmacist/search-pharmacist.component';
import { ExistPharmacistComponent } from './components/admin/exist-pharmacist/exist-pharmacist.component';
import { PhDetailsComponent } from './components/admin/ph-details/ph-details.component';
import { EditPhComponent } from './components/admin/edit-ph/edit-ph.component';
import { AddphComponent } from './components/admin/addph/addph.component';
import { SearchRecpComponent } from './components/admin/search-recp/search-recp.component';
import { ExistRecepComponent } from './components/admin/exist-recep/exist-recep.component';
import { RecepDetailsComponent } from './components/admin/recep-details/recep-details.component';
import { EditRecepComponent } from './components/edit-recep/edit-recep.component';
import { AddRecpComponent } from './components/admin/add-recp/add-recp.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CategoryComponent,
    NotFoundComponent,
    SearchPaComponent,
    AddPaComponent,
    ClinicsComponent,
    TicketComponent,
    ExistPatientComponent,
    DiseasHistoryComponent,
    DateofpatientComponent,
    UpdatePatientComponent,
    DoctorComponent,
    PharmacyComponent,
    PhHomePageComponent,
    AddDrugComponent,
    AddNewDrugComponent,
    UpdateDrugComponent,
    ReceptionHomePageComponent,
    PatientHistoryinClinicComponent,
    ExitComponent,
    HomePageComponent,
    DoctorAdminComponent,
    ExistDoctorComponent,
    UpdateDoctorComponent,
    EditDoctorComponent,
    AddDoctorComponent,
    SearchPharmacistComponent,
    ExistPharmacistComponent,
    PhDetailsComponent,
    EditPhComponent,
    AddphComponent,
    SearchRecpComponent,
    ExistRecepComponent,
    RecepDetailsComponent,
    EditRecepComponent,
    AddRecpComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    NgChartsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
