import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PipeReportComponent } from './pipe-report.component';

describe('PipeReportComponent', () => {
  let component: PipeReportComponent;
  let fixture: ComponentFixture<PipeReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PipeReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PipeReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
