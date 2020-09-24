import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPipeReportComponent } from './edit-pipe-report.component';

describe('EditPipeReportComponent', () => {
  let component: EditPipeReportComponent;
  let fixture: ComponentFixture<EditPipeReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditPipeReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPipeReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
