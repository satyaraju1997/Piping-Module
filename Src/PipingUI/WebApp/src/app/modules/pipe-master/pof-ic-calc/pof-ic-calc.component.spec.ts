import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PofIcCalcComponent } from './pof-ic-calc.component';

describe('PofIcCalcComponent', () => {
  let component: PofIcCalcComponent;
  let fixture: ComponentFixture<PofIcCalcComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PofIcCalcComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PofIcCalcComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
