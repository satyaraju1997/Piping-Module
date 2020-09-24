import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNonTrendableDmsComponent } from './add-non-trendable-dms.component';

describe('AddNonTrendableDmsComponent', () => {
  let component: AddNonTrendableDmsComponent;
  let fixture: ComponentFixture<AddNonTrendableDmsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddNonTrendableDmsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddNonTrendableDmsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
