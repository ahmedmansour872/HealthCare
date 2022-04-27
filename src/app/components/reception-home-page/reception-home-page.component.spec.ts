import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceptionHomePageComponent } from './reception-home-page.component';

describe('ReceptionHomePageComponent', () => {
  let component: ReceptionHomePageComponent;
  let fixture: ComponentFixture<ReceptionHomePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReceptionHomePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReceptionHomePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
