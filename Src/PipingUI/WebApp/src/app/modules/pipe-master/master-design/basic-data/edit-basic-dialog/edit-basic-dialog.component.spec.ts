import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditBasicDialogComponent } from './edit-basic-dialog.component';

describe('EditBasicDialogComponent', () => {
  let component: EditBasicDialogComponent;
  let fixture: ComponentFixture<EditBasicDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditBasicDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditBasicDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
