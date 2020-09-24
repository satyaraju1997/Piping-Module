import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogStructuralMinThkComponent } from './dialog-structural-min-thk.component';

describe('DialogStructuralMinThkComponent', () => {
  let component: DialogStructuralMinThkComponent;
  let fixture: ComponentFixture<DialogStructuralMinThkComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogStructuralMinThkComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogStructuralMinThkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
