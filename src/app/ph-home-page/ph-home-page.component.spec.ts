import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhHomePageComponent } from './ph-home-page.component';

describe('PhHomePageComponent', () => {
  let component: PhHomePageComponent;
  let fixture: ComponentFixture<PhHomePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PhHomePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PhHomePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
