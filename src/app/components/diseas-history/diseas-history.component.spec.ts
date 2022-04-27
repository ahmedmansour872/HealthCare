import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiseasHistoryComponent } from './diseas-history.component';

describe('DiseasHistoryComponent', () => {
  let component: DiseasHistoryComponent;
  let fixture: ComponentFixture<DiseasHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DiseasHistoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DiseasHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
