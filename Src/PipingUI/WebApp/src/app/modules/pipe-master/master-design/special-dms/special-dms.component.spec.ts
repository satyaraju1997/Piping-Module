import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecialDMsComponent } from './special-dms.component';

describe('SpecialDMsComponent', () => {
  let component: SpecialDMsComponent;
  let fixture: ComponentFixture<SpecialDMsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpecialDMsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpecialDMsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
