import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExistDoctorComponent } from './exist-doctor.component';

describe('ExistDoctorComponent', () => {
  let component: ExistDoctorComponent;
  let fixture: ComponentFixture<ExistDoctorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExistDoctorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExistDoctorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
