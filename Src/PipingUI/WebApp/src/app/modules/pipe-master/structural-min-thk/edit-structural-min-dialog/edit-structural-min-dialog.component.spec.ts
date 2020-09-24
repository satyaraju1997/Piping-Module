import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditStructuralMinDialogComponent } from './edit-structural-min-dialog.component';

describe('EditStructuralMinDialogComponent', () => {
  let component: EditStructuralMinDialogComponent;
  let fixture: ComponentFixture<EditStructuralMinDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditStructuralMinDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditStructuralMinDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
