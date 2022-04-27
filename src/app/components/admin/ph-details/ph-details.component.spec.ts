import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhDetailsComponent } from './ph-details.component';

describe('PhDetailsComponent', () => {
  let component: PhDetailsComponent;
  let fixture: ComponentFixture<PhDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PhDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PhDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
