import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPhComponent } from './edit-ph.component';

describe('EditPhComponent', () => {
  let component: EditPhComponent;
  let fixture: ComponentFixture<EditPhComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditPhComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPhComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
