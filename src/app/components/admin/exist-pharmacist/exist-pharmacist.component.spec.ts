import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExistPharmacistComponent } from './exist-pharmacist.component';

describe('ExistPharmacistComponent', () => {
  let component: ExistPharmacistComponent;
  let fixture: ComponentFixture<ExistPharmacistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExistPharmacistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExistPharmacistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
