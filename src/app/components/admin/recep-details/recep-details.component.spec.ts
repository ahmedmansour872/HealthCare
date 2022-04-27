import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecepDetailsComponent } from './recep-details.component';

describe('RecepDetailsComponent', () => {
  let component: RecepDetailsComponent;
  let fixture: ComponentFixture<RecepDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecepDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecepDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
