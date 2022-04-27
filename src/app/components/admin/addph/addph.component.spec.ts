import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddphComponent } from './addph.component';

describe('AddphComponent', () => {
  let component: AddphComponent;
  let fixture: ComponentFixture<AddphComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddphComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddphComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
