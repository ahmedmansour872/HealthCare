import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientHistoryinClinicComponent } from './patient-historyin-clinic.component';

describe('PatientHistoryinClinicComponent', () => {
  let component: PatientHistoryinClinicComponent;
  let fixture: ComponentFixture<PatientHistoryinClinicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatientHistoryinClinicComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PatientHistoryinClinicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
