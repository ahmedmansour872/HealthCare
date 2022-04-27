import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPaComponent } from './add-pa.component';

describe('AddPaComponent', () => {
  let component: AddPaComponent;
  let fixture: ComponentFixture<AddPaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
