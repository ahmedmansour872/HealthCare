import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchPharmacistComponent } from './search-pharmacist.component';

describe('SearchPharmacistComponent', () => {
  let component: SearchPharmacistComponent;
  let fixture: ComponentFixture<SearchPharmacistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchPharmacistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchPharmacistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
