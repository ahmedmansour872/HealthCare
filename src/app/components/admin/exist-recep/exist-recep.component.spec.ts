import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExistRecepComponent } from './exist-recep.component';

describe('ExistRecepComponent', () => {
  let component: ExistRecepComponent;
  let fixture: ComponentFixture<ExistRecepComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExistRecepComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExistRecepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
