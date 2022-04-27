import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchRecpComponent } from './search-recp.component';

describe('SearchRecpComponent', () => {
  let component: SearchRecpComponent;
  let fixture: ComponentFixture<SearchRecpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchRecpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchRecpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
