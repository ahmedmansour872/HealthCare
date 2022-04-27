import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRecpComponent } from './add-recp.component';

describe('AddRecpComponent', () => {
  let component: AddRecpComponent;
  let fixture: ComponentFixture<AddRecpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddRecpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddRecpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
