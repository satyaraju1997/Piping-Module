import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StructuralMinThkComponent } from './structural-min-thk.component';

describe('StructuralMinThkComponent', () => {
  let component: StructuralMinThkComponent;
  let fixture: ComponentFixture<StructuralMinThkComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StructuralMinThkComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StructuralMinThkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
