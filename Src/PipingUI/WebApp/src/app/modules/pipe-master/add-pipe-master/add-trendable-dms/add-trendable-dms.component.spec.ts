import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTrendableDmsComponent } from './add-trendable-dms.component';

describe('AddTrendableDmsComponent', () => {
  let component: AddTrendableDmsComponent;
  let fixture: ComponentFixture<AddTrendableDmsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddTrendableDmsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTrendableDmsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
