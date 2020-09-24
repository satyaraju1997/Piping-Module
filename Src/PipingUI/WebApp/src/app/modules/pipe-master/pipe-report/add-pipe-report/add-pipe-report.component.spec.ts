import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPipeReportComponent } from './add-pipe-report.component';

describe('AddPipeReportComponent', () => {
  let component: AddPipeReportComponent;
  let fixture: ComponentFixture<AddPipeReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPipeReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPipeReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
