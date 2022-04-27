import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DateofpatientComponent } from './dateofpatient.component';

describe('DateofpatientComponent', () => {
  let component: DateofpatientComponent;
  let fixture: ComponentFixture<DateofpatientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DateofpatientComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DateofpatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
