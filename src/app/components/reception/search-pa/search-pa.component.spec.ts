import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchPaComponent } from './search-pa.component';

describe('SearchPaComponent', () => {
  let component: SearchPaComponent;
  let fixture: ComponentFixture<SearchPaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchPaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchPaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
