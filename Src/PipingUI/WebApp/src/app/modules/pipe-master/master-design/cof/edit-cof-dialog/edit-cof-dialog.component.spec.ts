import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCofDialogComponent } from './edit-cof-dialog.component';

describe('EditCofDialogComponent', () => {
  let component: EditCofDialogComponent;
  let fixture: ComponentFixture<EditCofDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditCofDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCofDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
