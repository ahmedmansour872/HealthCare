import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExistPatientComponent } from './exist-patient.component';

describe('ExistPatientComponent', () => {
  let component: ExistPatientComponent;
  let fixture: ComponentFixture<ExistPatientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExistPatientComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExistPatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
