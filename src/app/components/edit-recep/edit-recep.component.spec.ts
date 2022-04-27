import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditRecepComponent } from './edit-recep.component';

describe('EditRecepComponent', () => {
  let component: EditRecepComponent;
  let fixture: ComponentFixture<EditRecepComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditRecepComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditRecepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
