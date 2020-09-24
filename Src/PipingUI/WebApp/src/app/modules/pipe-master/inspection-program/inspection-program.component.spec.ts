import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionProgramComponent } from './inspection-program.component';

describe('InspectionProgramComponent', () => {
  let component: InspectionProgramComponent;
  let fixture: ComponentFixture<InspectionProgramComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionProgramComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionProgramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
